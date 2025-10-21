using ER_Stock_Management_DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "ER-Stock Management-DataAcessLayer");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer());

app.Run();
