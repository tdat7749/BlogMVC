using Blog.Application.Catalog.CategoryService;
using Blog.Application.Catalog.PostService;
using Blog.Application.Catalog.TagService;
using Blog.Application.Common.FileStorageService;
using Blog.Application.System.AuthenService;
using Blog.Application.System.CommentService;
using Blog.Application.System.RoleService;
using Blog.Application.System.UserService;
using Blog.Data.EF;
using Blog.Data.Entities;
using Blog.ViewModel.Custom;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDb"));
});

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IAuthenService, AuthenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICommentService, CommentService>();



builder.Services.AddIdentity<UserApplication, IdentityRole>()
    .AddEntityFrameworkStores<BlogDbContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<CustomIdentityErrrorDescriber>();



builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";


    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    //Email duy nhất
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Authen";
    options.AccessDeniedPath = "/";
});


//Đăng ký policy (chính sách)
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        //Yêu cầu người dùng phải xác thực
        policy.RequireAuthenticatedUser();

        //Phải có quyền tên là ....
        policy.RequireRole("Quản Trị Viên");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();



//RequireAuthorization ở dưới là đăng ký policy(chính sách) Admin cho Route này.

app.UseEndpoints(endpoint =>
{
    endpoint.MapAreaControllerRoute(
      name: "Admin",
      areaName: "Admin",
      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
).RequireAuthorization("Admin");


    endpoint.MapControllerRoute(
        name: "Blog",
        pattern: "{controller=Blog}/{action=Index}/{slug}"
    );

    endpoint.MapControllerRoute(
        name: "Author",
        pattern: "{controller=Author}/{action=Index}/{username}"
    );

    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

});

app.Run();
