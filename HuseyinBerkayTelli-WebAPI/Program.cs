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
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(appSettings.ConnectionStrings.DefaultConnection, ServerVersion.AutoDetect(appSettings.ConnectionStrings.DefaultConnection));
});


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICityBusinessService, CityBusinessService>();
builder.Services.AddScoped<ICityRepositoryService, CityRepositoryService>();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
