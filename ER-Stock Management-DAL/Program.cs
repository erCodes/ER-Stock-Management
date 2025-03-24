var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "ER-Stock Management-DataAcessLayer");

app.Run();
