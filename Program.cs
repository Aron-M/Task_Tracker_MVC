var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add ASP.NET Core Identity services and configure the Identity options
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configure Identity options as needed
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>() // Add EF stores
.AddDefaultTokenProviders();

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

// Add Entity Framework and the ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseAuthentication(); // Ensure UseAuthentication is called
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();