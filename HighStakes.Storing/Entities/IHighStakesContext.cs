using HighStakes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HighStakes.Storing.Entities
{
  public interface IHighStakesContext
  {
    DbSet<DAccount> Account { get; set; }
    DbSet<DCard> Card { get; set; }
    DbSet<DUser> User { get; set; }
    int SaveChanges();
  }
}