using StockManagement.Web.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddAndConfigureAuthentication()
    .AddAndConfigureDbContext(builder.Configuration.GetConnectionString("Default"))
    .AddAndConfigureBusinessServices()
    .AddAndConfigureSmtp(builder.Configuration.GetSection("Smtp").Get<SmtpConfig>());


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller}/{action}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
