using Microsoft.EntityFrameworkCore;

namespace HighStakes.Storing.Entities
{
public class HighStakesContext : DbContext
{
    public HighStakesContext()
    {
    }

    public HighStakesContext(DbContextOptions<HighStakesContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<User> Users { get; set; }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().ToTable("Account");
        modelBuilder.Entity<Card>().ToTable("Card");
        modelBuilder.Entity<User>().ToTable("User");
    }
}
}