using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Machine> Machines { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}