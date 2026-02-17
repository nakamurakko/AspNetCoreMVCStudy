using AspNetCoreMVCStudy.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCStudy.DB;

// https://learn.microsoft.com/ja-jp/ef/core/dbcontext-configuration/#dbcontext-in-dependency-injection-for-aspnet-core
// https://learn.microsoft.com/ja-jp/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio#update-the-database-context-class

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

}
