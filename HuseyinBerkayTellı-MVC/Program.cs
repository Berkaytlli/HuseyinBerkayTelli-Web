using AppEnvironment;
using Business.CityBusinessService;
using Context;
using Entity.CityService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

var appSettings = configuration.Get<AppSettings>();
builder.Services.AddScoped<AppSettings>();
builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(appSettings.ConnectionStrings.DefaultConnection, ServerVersion.AutoDetect(appSettings.ConnectionStrings.DefaultConnection));
});
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddScoped<ICityBusinessService, CityBusinessService>();
//builder.Services.AddScoped<ICityRepositoryService, CityRepositoryService>();

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddControllersWithViews();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=City}/{action=Index}/{id?}");

app.Run();
