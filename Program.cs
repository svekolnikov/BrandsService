using System.Reflection;
using BrandsService.DAL.Context;
using BrandsService.DAL.Repositories;
using BrandsService.DAL.Repositories.Interfaces;
using BrandsService.Services;
using BrandsService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    var xmlFilename = "api.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//Database
services.AddDbContext<ApplicationDbContext>(optionsAction => optionsAction
    .UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//Mapper
services.AddAutoMapper(Assembly.GetEntryAssembly());

services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

services.AddScoped<IBrandsService, BrandService>();
services.AddScoped<IBrandsRepository, BrandsRepository>();
services.AddScoped<IAllowedSizesRepository, AllowedSizesRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowCredentials();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
