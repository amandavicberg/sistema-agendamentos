using Microsoft.EntityFrameworkCore;
using SistemaAgendamentos.Api.Models;

namespace SistemaAgendamentos.Api.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  { }

  public DbSet<Cliente> Clientes => Set<Cliente>();
  public DbSet<Servico> Servicos => Set<Servico>();
  public DbSet<Agendamento> Agendamentos => Set<Agendamento>();
}