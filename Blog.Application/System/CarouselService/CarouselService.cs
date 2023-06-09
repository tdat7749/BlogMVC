﻿using Blog.Application.Common.FileStorageService;
using Blog.Data.EF;
using Blog.Data.Entities;
using Blog.ViewModel.Common;
using Blog.ViewModel.System.Carousel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.System.CarouselService
{
    public class CarouselService : ICarouselService
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly BlogDbContext _context;
        public CarouselService(IFileStorageService fileStorageService,BlogDbContext context)
        {
            _fileStorageService = fileStorageService;
            _context = context;
        }
        public async Task<JsonResponse> CreateCarousel(CreateCarouselModel model)
        {
            try
            {
                var carousel = new Carousel()
                {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Name = model.Name,
                    SortOrder = model.SortOrder,
                    Status = Data.Enums.Status.Disable,
                    Url = await _fileStorageService.SaveThumbnailAsync(model.Url, model.Name)
                };

                _context.Carousels.Add(carousel);
                await _context.SaveChangesAsync();

                return new JsonResponse()
                {
                    Message = "Tạo thành công",
                    Success = true
                };
                
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra, vui lòng thử lại sau",
                    Success = false
                };
            }


        }

        public async Task<JsonResponse> DeleteCarouse(int id)
        {
            try
            {
                var carousel = await _context.Carousels.FindAsync(id);

                if (carousel == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại với id = {id}",
                        Success = false
                    };
                }

                _fileStorageService.DeleteThumbnail(carousel.Url);
                _context.Carousels.Remove(carousel);
                await _context.SaveChangesAsync();

                return new JsonResponse()
                {
                    Message = "Xóa thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = $"Có lỗi xảy ra, vui lòng thử lại sau",
                    Success = false
                };
            }

        }

        public async Task<PagingResponse<List<CarouselVm>>> GetAllCarousel(PagingRequest request)
        {
            int TotalPage, TotalRecord;
            var query = from c in _context.Carousels
                        select c;


            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            TotalRecord = query.Count();

            query = query.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize);


            TotalPage = (int)Math.Ceiling((double)TotalRecord / request.PageSize);

            var result = await query.Select(x => new CarouselVm()
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url,
                SortOrder = x.SortOrder,
                Status = x.Status
            }).ToListAsync();

            return new PagingResponse<List<CarouselVm>>()
            {
                Data = result,
                TotalPage = TotalPage,
                TotalRecord = TotalRecord
            };
        }

        public async Task<Carousel> GetCarousel(int id)
        {
            try
            {
                var carousel = await _context.Carousels.FindAsync(id);

                if (carousel == null)
                {
                    return null;
                }

                return carousel;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<List<CarouselVm>> GetPublicCarousel()
        {
            try
            {
                var query = from c in _context.Carousels
                            where c.Status == Data.Enums.Status.Enable
                            select c;

                var result = await query.Select(x => new CarouselVm()
                {
                    Id = x.Id,
                    SortOrder = x.SortOrder,
                    Name = x.Name,
                    Url = x.Url,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt
                }).OrderByDescending(x => x.SortOrder).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<JsonResponse> UpdateCarousel(UpdateCarouselModel model)
        {
            try
            {
                var carousel = await _context.Carousels.FindAsync(model.Id);

                if (carousel == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại với id = {model.Id}",
                        Success = false
                    };
                }

                carousel.Name = model.Name;
                carousel.Status = model.Status;
                carousel.SortOrder = model.SortOrder;
                carousel.UpdatedAt = DateTime.Now;

                if(model.Url != null)
                {
                    _fileStorageService.DeleteThumbnail(carousel.Url);
                    carousel.Url = await _fileStorageService.SaveThumbnailAsync(model.Url, model.Name);
                }

                _context.Carousels.Update(carousel);
                await _context.SaveChangesAsync();

                return new JsonResponse()
                {
                    Message = "Cập nhật thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra, vui lòng thử lại sau",
                    Success = false
                };
            }
        }

        public async Task<JsonResponse> UpdateCarouselStatus(UpdateCarouselStatusModel model)
        {
            try
            {
                var carousel = await _context.Carousels.FindAsync(model.Id);

                if (carousel == null)
                {
                    return new JsonResponse()
                    {
                        Message = $"Không tồn tại với id = {model.Id}",
                        Success = false
                    };
                }
                carousel.Status = model.Status;


                _context.Carousels.Update(carousel);
                await _context.SaveChangesAsync();

                return new JsonResponse()
                {
                    Message = "Cập nhật thành công",
                    Success = true
                };
            }
            catch (Exception)
            {
                return new JsonResponse()
                {
                    Message = "Có lỗi xảy ra, vui lòng thử lại sau",
                    Success = false
                };
            }
        }
    }
}
