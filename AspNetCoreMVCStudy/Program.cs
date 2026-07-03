using AspNetCoreMVCStudy.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// https://learn.microsoft.com/ja-jp/ef/core/miscellaneous/connection-strings
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(optionsAction => optionsAction.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

#region DB のマイグレーション

IDbContextFactory<ApplicationDbContext> dbContextFactory = app.Services.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
await using ApplicationDbContext dbContext = await dbContextFactory.CreateDbContextAsync();
await dbContext.Database.MigrateAsync();

#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
