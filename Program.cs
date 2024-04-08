using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskTrackerMVC.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the CategoryAPIService with HttpClient
builder.Services.AddHttpClient<CategoryAPIService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5170/api/categories/");
});

// Register the TaskAPIService with HttpClient
builder.Services.AddHttpClient<TaskAPIService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5170/api/tasks/");
});

// Register the UserAPIService with HttpClient
// Assuming you have an API endpoint for user operations
builder.Services.AddHttpClient<UserAPIService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5170/api/users/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// No need for app.UseAuthentication() or app.UseAuthorization() if you're not
// doing any direct authentication or authorization in the MVC app.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();