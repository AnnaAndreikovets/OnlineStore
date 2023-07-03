using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Repository;
using OnlineStore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContent>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IAllGoods, GoodRepository>();
builder.Services.AddTransient<IGoodsCategory, CategoryRepository>();


builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseStaticFiles();
app.UseMvc();

app.UseMvc(routes => {
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    routes.MapRoute(name: "categoryFilter", template: "Good/{action}/", defaults: new {controller = "Good", action = "List"});
});

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