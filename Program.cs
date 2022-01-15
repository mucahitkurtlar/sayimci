using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Stock.Areas.Identity.Data;
using MyApplication.Data;
var builder = WebApplication.CreateBuilder(args);
/*
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<StockContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("StockContext")));
}
else
{
    builder.Services.AddDbContext<StockContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionStockContext")));
}
*/
builder.Services.AddDbContext<StockContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionStockContext")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionStockContext")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StockIdentityDbContext>(); builder.Services.AddDbContext<StockIdentityDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionStockContext")));
// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
