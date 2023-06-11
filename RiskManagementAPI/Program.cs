using Microsoft.EntityFrameworkCore;
using RiskManagementAPI.DBContext;
using RiskManagementAPI.Repositories;
using RiskManagementAPI.Services;
using RiskManagementAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RiskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRiskService, RiskService>();
builder.Services.AddScoped<IRiskRepository, RiskRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IRiskHistoryService, RiskHistoryService>();
builder.Services.AddScoped<IRiskHistoryRepository, RiskHistoryRepository>();

builder.Services.AddScoped<IControlService, ControlService>();
builder.Services.AddScoped<IControlRepository, ControlRepository>();

builder.Services.AddScoped<INormService, NormService>();
builder.Services.AddScoped<INormRepository, NormRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
