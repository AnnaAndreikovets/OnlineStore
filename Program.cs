using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;
using OnlineStore.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddTransient<IAllGoods, MockGoods>();
builder.Services.AddTransient<IGoodsCategory, MockCategory>();

var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.MapGet("/", () => "Hello World!");

app.Run();