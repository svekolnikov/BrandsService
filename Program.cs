using System.Reflection;
using BrandsService.DAL.Context;
using BrandsService.DAL.Repositories;
using BrandsService.Services;
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

services.AddAutoMapper(Assembly.GetEntryAssembly());

services.AddScoped<IBrandsService, BrandService>();
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
