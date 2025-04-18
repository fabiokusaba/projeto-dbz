using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Personagem> Dbz { get; set; }
}