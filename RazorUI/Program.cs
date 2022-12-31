using DataLibrary.Data;
using DataLibrary.InternalDataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IFoodData, FoodData>();
builder.Services.AddSingleton<IOrderData, OrderData>();
builder.Services.AddSingleton<IDataAccess, SqlDB>();
builder.Services.AddSingleton<IDataAccess, SqlDB>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
