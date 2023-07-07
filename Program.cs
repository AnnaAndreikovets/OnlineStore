using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Repository;
using OnlineStore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContent>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IAllGoods, GoodRepository>();
builder.Services.AddTransient<IGoodsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();


builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseStaticFiles();
app.UseExceptionHandler("/Error");
app.UseMvc();

app.UseStatusCodePagesWithReExecute("/Home/Index", "?code={0}");

app.UseMvc(routes => {
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    routes.MapRoute(name: "categoryFilter", template: "Goods/{action}/", defaults: new {controller = "Goods", action = "List"});
    routes.MapRoute(name: "good", template: "Good/{action}/{id}", defaults: new {controller = "Good", action = "Index"});
});

using(var scope = app.Services.CreateScope())
{
    ApplicationDBContent content = scope.ServiceProvider.GetRequiredService<ApplicationDBContent>()!;

    DBobjects.Initial(content);
}

app.Map("/Error", (HttpContext context) => 
{
    string message = "<h3>There has been a breakdown!</h3>";

    context.Response.ContentType = "text/html";

    return message;
});

app.Run();