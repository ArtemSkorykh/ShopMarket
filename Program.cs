using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Controllers;
using ShopMarket.Data;
using ShopMarket.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connStr = builder.Configuration.GetConnectionString("DefConn") ??
    throw new InvalidOperationException("Connection string wasn't provided!");
builder.Services.AddDbContext<ShopDbContext>(options=>options.UseSqlServer(connStr));
builder.Services.AddIdentity<ShopUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ShopDbContext>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");
app.MapControllerRoute(
    name:"childCategory",
    pattern: "categories/GetChildCategories/{parentId:int?}",
    defaults: new { controller = "Categories", action= "GetChildCategories" }
    );
app.Run();
