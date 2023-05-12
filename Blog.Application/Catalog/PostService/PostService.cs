using Blog.Application.Common.FileStorageService;
using Blog.Data.EF;
using Blog.Data.Entities;
using Blog.ViewModel.Catalog.Post;
using Blog.ViewModel.Catalog.Tag;
using Blog.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Catalog.PostService
{
    public class PostService : IPostService
    {
        private readonly BlogDbContext _context;
        private readonly IFileStorageService _fileStorageService;

        public PostService(BlogDbContext context, IFileStorageService fileStorageService)
        {
            _context = context;
            _fileStorageService = fileStorageService;
        }

        public async Task<JsonResponse> ChangePublished(UpdatePostPublishedModel model)
        {
            var post = await _context.Posts.FindAsync(model.Id);
            if(post == null)
            {
                return new JsonResponse()
                {
                    Message = $"Không tồn tại bài viết với Id = ${model.Id}",
                    Success = false
                };
            }

            post.Published = model.IsPublished;
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return new JsonResponse()
            {
                Success = true,
                Message = "Thay đổi trạng thái thành công"
            };
        }

        public async Task<JsonResponse> CreatePost(CreatePostModel model)
        {
            try
            {
                var checkSlug = await _context.Posts.FirstOrDefaultAsync(x => x.Slug == model.Slug);
                if (checkSlug != null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Slug = ${model.Slug} đã tồn tại",
                        Success = false
                    };
                }

                var listPostInTags = new List<PostInTag>();

                foreach (var item in model.Tags)
                {
                    listPostInTags.Add(new PostInTag()
                    {
                        TagId = item
                    });
                }

                var post = new Post()
                {
                    Title = model.Title,
                    Body = model.Body,
                    Slug = model.Slug,
                    CategoryId = model.CategoryId,
                    UserId = model.UserId,
                    Published = false,
                    PostInTags = listPostInTags,
                    Thumbnail = await _fileStorageService.SaveThumbnailAsync(model.Thumbnail, model.Slug),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Tạo bài viết thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse() { Message = "Có lỗi xảy ra",Success=false};
            }
        }

        public async Task<JsonResponse> DeletePost(int id)
        {
            try
            {
                var post = await _context.Posts.FindAsync(id);
                if (post == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại bài viết nào có Id = {id}",
                        Success = false
                    };
                }

                _context.Posts.Remove(post);
                _fileStorageService.DeleteThumbnail(post.Thumbnail);
                await _context.SaveChangesAsync();

                return new JsonResponse()
                {
                    Message = "Xóa thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse() { Message = "Có lỗi xảy ra", Success = false };
            }
        }

        public async Task<PagingResponse<List<PostListVm>>> GetAllPost(PagingRequest request)
        {
            int TotalPage, TotalRecord;
            var query = from p in _context.Posts
                        join c in _context.Categories on p.CategoryId equals c.Id
                        join u in _context.Users on p.UserId equals u.Id
                        select new {p,c,u};



            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.Title.Contains(request.Keyword) || x.c.Name.Contains(request.Keyword));
            }

            TotalRecord = query.Count();

            query = query.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize);


            TotalPage = (int)Math.Ceiling((double)TotalRecord / request.PageSize);

            var result = await query.Select(x => new PostListVm()
            {
                Id = x.p.Id,
                Title = x.p.Title,
                Body = x.p.Body,
                View = x.p.View,
                Thumbnail = x.p.Thumbnail,
                CategoryName = x.c.Name,
                Slug = x.p.Slug,
                CreatedAt = x.p.CreatedAt.ToString(),
                FirstName = x.u.FirstName,
                LastName = x.u.LastName,
                Published = x.p.Published
            }).ToListAsync();

            return new PagingResponse<List<PostListVm>>()
            {
                Data = result,
                TotalPage = TotalPage,
                TotalRecord = TotalRecord
            };
        }

        public async Task<Post> GetPostForEdit(int id)
        {
            var query = from p in _context.Posts
                        join pt in _context.PostInTags on p.Id equals pt.PostId
                        where p.Id == id
                        select new { p, pt };

            var post = await query.Select(x => new Post()
            {
                Id = x.p.Id,
                CategoryId = x.p.CategoryId,
                Title = x.p.Title,
                Slug = x.p.Slug,
                Thumbnail = x.p.Thumbnail,
                Published = x.p.Published,
                PostInTags = query.Select(z => new PostInTag()
                {
                    Id = z.pt.Id,
                    PostId = z.pt.PostId,
                    TagId = z.pt.TagId
                }).ToList(),
                Body = x.p.Body
            }).FirstOrDefaultAsync();

            return post;

        }

        public async Task<PostVm> GetPostBySlug(string slug)
        {
            var query = from p in _context.Posts
                        join c in _context.Categories on p.CategoryId equals c.Id
                        join u in _context.Users on p.UserId equals u.Id
                        where p.Slug == slug && p.Published == true
                        select new { p, c ,u};

            if (query == null) return null;

            var listTags = from p in _context.Posts
                           join pt in _context.PostInTags on p.Id equals pt.PostId
                           join t in _context.Tags on pt.TagId equals t.Id
                           where p.Slug == slug
                           select new { p, pt, t };

            var result = await query.Select(x => new PostVm()
            {
                Id = x.p.Id,
                Slug = x.p.Slug,
                Title = x.p.Title,
                Body = x.p.Body,
                Thumbnail = x.p.Thumbnail,
                CreatedAt = x.p.CreatedAt.ToString(),
                View = x.p.View,
                CategoryName = x.c.Name,
                ListTags = listTags.Select(z => new TagVm()
                {
                    Id = z.t.Id,
                    Name = z.t.Name,
                    Slug = z.t.Slug
                }).ToList(),
                FirstName = x.u.FirstName,
                LastName = x.u.LastName,
                Published = x.p.Published
            }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<PostListVm>> GetPostLatest()
        {
            var query = (from p in _context.Posts
                               join c in _context.Categories on p.CategoryId equals c.Id
                               join u in _context.Users on p.UserId equals u.Id
                               where p.Published == true
                               select new { p, c, u }).Take(10).OrderByDescending(x => x.p.CreatedAt);

            return await query.Select(x => new PostListVm()
            {
                Id = x.p.Id,
                Slug = x.p.Slug,
                Body = x.p.Body,
                CreatedAt = x.p.CreatedAt.ToString(),
                View = x.p.View,
                Thumbnail = x.p.Thumbnail,
                CategoryName = x.c.Name,
                Title = x.p.Title,
                FirstName = x.u.FirstName,
                LastName = x.u.LastName,
                Published = x.p.Published
            }).ToListAsync();
        }

        public async Task<PagingResponse<List<PostListVm>>> GetPublicAllPost(PagingRequest request)
        {
            int TotalPage, TotalRecord;
            var query = from p in _context.Posts
                        join c in _context.Categories on p.CategoryId equals c.Id
                        where p.Published == true
                        select new { p, c };



            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.Title.Contains(request.Keyword) || x.c.Name.Contains(request.Keyword));
            }

            TotalRecord = query.Count();

            query = query.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize);


            TotalPage = (int)Math.Ceiling((double)TotalRecord / request.PageSize);

            var result = await query.Select(x => new PostListVm()
            {
                Id = x.p.Id,
                Title = x.p.Title,
                Body = x.p.Body,
                View = x.p.View,
                Thumbnail = x.p.Thumbnail,
                CategoryName = x.c.Name,
                Slug = x.p.Slug,
                CreatedAt = x.p.CreatedAt.ToString()
            }).ToListAsync();

            return new PagingResponse<List<PostListVm>>()
            {
                Data = result,
                TotalPage = TotalPage,
                TotalRecord = TotalRecord
            };
        }

        public void PlusViewPost(int id)
        {
            var post = _context.Posts.Find(id);

            post.View += 1;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public async Task<JsonResponse> UpdatePost(UpdatePostModel model)
        {
            try
            {
                var post = await _context.Posts.FindAsync(model.Id);
                if (post == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại bài viết với Id = {model.Id}",
                        Success = false
                    };
                }

                var listPostInTags = new List<PostInTag>();

                var listCurrentPostTag = await _context.PostInTags.Where(x => x.PostId == model.Id).Select(x => x.TagId).ToListAsync();


                //Kiểm tra list tag update đã tồn tại trong list tag hiện tại chưa
                //nếu rồi thì continue
                //chưa có thì add vào
                foreach (var item in model.Tags)
                {
                    if (listCurrentPostTag.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        listPostInTags.Add(new PostInTag()
                        {
                            TagId = item
                        });
                    }
                }

                // Kiểm tra list tag hiện tại có phần tử nào giống với list tag muốn update không
                // nếu tồn tại thì continue
                // nếu không tồn tại thì remove nó đi

                foreach (var item in listCurrentPostTag)
                {
                    if (model.Tags.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        var postInTag = await _context.PostInTags.FirstOrDefaultAsync(x => x.TagId == item && x.PostId == model.Id);
                        _context.PostInTags.Remove(postInTag);
                    }
                }

                post.Title = model.Title;
                post.Slug = model.Slug;
                post.Body = model.Body;
                post.Published = model.IsPublished;
                post.CategoryId = model.CategoryId;
                post.PostInTags = listPostInTags;


                if (model.Thumbnail != null)
                {
                    _fileStorageService.DeleteThumbnail(post.Thumbnail);
                    post.Thumbnail = await _fileStorageService.SaveThumbnailAsync(model.Thumbnail, post.Slug);
                }

                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
                return new JsonResponse()
                {
                    Message = "Sửa bài viết thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra vui lòng thử lại sau",
                    Success = false
                };
            }
        }
    }
}
