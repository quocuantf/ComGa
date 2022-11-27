using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ComGa.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

#region "Add services to the container."
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ComGa.Data.ComGaContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
);
//Add identity to Service
builder.Services.AddDefaultIdentity<IdentityUser>(option => option.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ComGaContext>();

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

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
