using DataLibrary.Data;
using DataLibrary.InternalDataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataAccess, SqlDB>();
builder.Services.AddSingleton<IFoodData, FoodData>();
builder.Services.AddSingleton<IOrderData, OrderData>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyOpenCorsPolicy", builder => 
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyOpenCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
