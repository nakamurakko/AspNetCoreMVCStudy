using AspNetCoreMVCStudy.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AspNetCoreMVCStudy.DB;

// https://learn.microsoft.com/ja-jp/ef/core/dbcontext-configuration/#dbcontext-in-dependency-injection-for-aspnet-core
// https://learn.microsoft.com/ja-jp/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio#update-the-database-context-class

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        this.ChangeTracker.StateChanged += this.TimestampsChanged;
        this.ChangeTracker.Tracked += this.TimestampsChanged;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(author => author.Books)
            .WithOne(book => book.Author)
            .HasPrincipalKey(author => author.AuthorId)
            .HasForeignKey(book => book.AuthorId);
    }

    /// <summary>
    /// 日時更新のイベント。
    /// </summary>
    /// <param name="sender">通知元のオブジェクト。</param>
    /// <param name="e">イベントデータ。</param>
    /// <remarks>
    /// https://learn.microsoft.com/ja-jp/ef/core/logging-events-diagnostics/events
    /// </remarks>
    private void TimestampsChanged(object? sender, EntityEntryEventArgs e)
    {
        if (e.Entry.Entity is IHasDbTimestamps entityWithTimestamps)
        {
            switch (e.Entry.State)
            {
                case EntityState.Added:
                    DateTime now = DateTime.Now;
                    entityWithTimestamps.CreatedAt = now;
                    entityWithTimestamps.UpdatedAt = now;
                    break;
                case EntityState.Modified:
                    entityWithTimestamps.UpdatedAt = DateTime.Now;
                    break;
            }
        }
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

}
