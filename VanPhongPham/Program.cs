﻿using Microsoft.EntityFrameworkCore;
using VanPhongPham.Models;
using VanPhongPham.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//đăng ký QLvenphongpham context
string connectionString = builder.Configuration.GetConnectionString("QLVanPhongPhamContext");
builder.Services.AddDbContext<QLVanPhongPhamContext>(options => options.UseSqlServer(connectionString));

//them dich vu loai san pham
builder.Services.AddScoped<ILoaiHang, LoaiSP>();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
