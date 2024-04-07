var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the CategoryAPIService with HttpClient
builder.Services.AddHttpClient<CategoryAPIService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/categories/");
});

// Register the TaskAPIService with HttpClient
builder.Services.AddHttpClient<TaskAPIService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/tasks/");
});

// Register the UserAPIService with HttpClient
builder.Services.AddHttpClient<UserAPIService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/users/");
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();