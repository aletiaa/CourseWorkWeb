using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configures required services: 
//  - registers DbContextof shop, repositories, etc in Depencency Injection container
ConfigureServices(builder.Services);

var app = builder.Build();

// fill database with default products on first time if database is empty.
// otherwise, the data will not be added to database because already exists
ShopDbInitializer.Seed(app);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ShopContext>(options =>
        options.UseSqlServer(@$"Server=.\SQLEXPRESS;Database=ShopDBCourseWork;Trusted_Connection=True;Encrypt=False"));

    services.AddScoped<ProductsRepository>();
    services.AddScoped<OrdersRepository>();
}