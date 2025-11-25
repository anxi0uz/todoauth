using Microsoft.EntityFrameworkCore;
using todoapi.Models;

namespace todoapi.DataAccess;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
    {
    }
    
    public DbSet<User>  Users { get; set; }
    public DbSet<Todo> Todos { get; set; }
}