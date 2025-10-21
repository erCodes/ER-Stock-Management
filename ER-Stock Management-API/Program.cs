using ER_Stock_Management_DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<ER_Stock_Management_DAL.Repositories.StoreRepository.IGet, ER_Stock_Management_DAL.Repositories.StoreRepository.Get>();
builder.Services.AddScoped<ER_Stock_Management_DAL.Repositories.StoreRepository.IPost, ER_Stock_Management_DAL.Repositories.StoreRepository.Post>();
builder.Services.AddScoped<ER_Stock_Management_DAL.Repositories.StoreRepository.IPut, ER_Stock_Management_DAL.Repositories.StoreRepository.Put>();
builder.Services.AddScoped<ER_Stock_Management_DAL.Repositories.StoreRepository.IDelete, ER_Stock_Management_DAL.Repositories.StoreRepository.Delete>();

builder.Services.AddScoped<ER_Stock_Management_DAL.Repositories.CategoryRepository.IGet, ER_Stock_Management_DAL.Repositories.CategoryRepository.Get>();
builder.Services.AddScoped<ER_Stock_Management_DAL.Repositories.CategoryRepository.IPost, ER_Stock_Management_DAL.Repositories.CategoryRepository.Post>();
builder.Services.AddScoped<ER_Stock_Management_DAL.Repositories.CategoryRepository.IPut, ER_Stock_Management_DAL.Repositories.CategoryRepository.Put>();
builder.Services.AddScoped<ER_Stock_Management_DAL.Repositories.CategoryRepository.IDelete, ER_Stock_Management_DAL.Repositories.CategoryRepository.Delete>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
