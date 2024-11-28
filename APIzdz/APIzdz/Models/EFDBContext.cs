using APIzdz.Models;
using Microsoft.EntityFrameworkCore;

public class EFDBContext : DbContext
{
  public DbSet<Equipamento> Equipamento { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    // Configura o banco de dados em memória
    optionsBuilder.UseInMemoryDatabase("EquipamentosDB");
  }
}
