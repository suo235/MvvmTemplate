using Microsoft.EntityFrameworkCore;

namespace MvvmTemplate;

public class MvvmTemplateContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=test.db");
        optionsBuilder.UseLazyLoadingProxies();
    }
}