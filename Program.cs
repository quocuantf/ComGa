using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ComGa.Data;
using ComGa.Models;
using ComGa.Repository;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

#region "Add services to the container."
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<ComGa.Data.ComGaContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
);
//Add identity to Service
// builder.Services.AddDefaultIdentity<ComGa.Models.User>(option => option.SignIn.RequireConfirmedAccount = false)
//     .AddEntityFrameworkStores<ComGaContext>();
builder.Services.AddIdentity<ComGa.Models.User, IdentityRole>(option => option.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ComGaContext>();
// builder.Services.AddScoped<ComGa.Repository.IProductRepository, ComGa.Repository.ProductRepositoryx>();
// builder.Services.AddScoped<ComGa.Repository.IProductCategoryReposity, ComGa.Repository.ProductCategoryReposity>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(typeof(IGenericReposity<>),typeof(GenericRepository<>));
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryReposity, ProductCategoryReposity>();
builder.Services.AddScoped<IUserReposity, UserReposity>();

builder.Services.AddHttpContextAccessor();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
