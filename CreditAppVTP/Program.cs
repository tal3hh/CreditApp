using CreditAppVTP.Contexts;
using CreditAppVTP.Models;
using CreditAppVTP.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddDbContext<CreditDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:Mssql"]);
});

builder.Services.AddScoped<IValidator<AppUser>, AppUserValidation>();
builder.Services.AddScoped<IValidator<Credit>, CreditValidation>();
builder.Services.AddScoped<IValidator<Work>, WorkValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
