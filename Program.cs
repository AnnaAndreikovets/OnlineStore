using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Models;
using OnlineStore.Data.Repository;
using OnlineStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContent>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IAllGoods, GoodRepository>();
builder.Services.AddTransient<IGoodsCategory, CategoryRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //добавляем работу с сессиями
builder.Services.AddScoped(sp => ShopCart.GetCart(sp)); //добавляем вывод для разных пользователей (для корзин)

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseMvc();
app.UseSession();
app.UseMvcWithDefaultRoute();

using(var scope = app.Services.CreateScope())
{
    ApplicationDBContent content = scope.ServiceProvider.GetRequiredService<ApplicationDBContent>()!;

    DBobjects.Initial(content);
}

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.Run();