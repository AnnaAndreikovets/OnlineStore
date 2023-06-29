using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using OnlineStore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IAllGoods, GoodRepository>();
builder.Services.AddTransient<IGoodsCategory, CategoryRepository>();

builder.Services.AddDbContext<ApplicationDBContent>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseStaticFiles();
app.UseMvc();
app.UseMvcWithDefaultRoute();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

//app.MapGet("/", () => "Hello World!");

app.Run();