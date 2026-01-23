using Microsoft.EntityFrameworkCore;
using SistemaAgendamentos.Api.Models;
using System.Security.Cryptography;
using System.Text;
using SistemaAgendamentos.Api.Helpers;

namespace SistemaAgendamentos.Api.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  { }

  public DbSet<Cliente> Clientes => Set<Cliente>();
  public DbSet<Servico> Servicos => Set<Servico>();
  public DbSet<Agendamento> Agendamentos => Set<Agendamento>();
  public DbSet<Usuario> Usuarios => Set<Usuario>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Cliente>(entity =>
    {
      entity.HasKey(c => c.Id);
      entity.Property(c => c.Nome).IsRequired().HasMaxLength(150);
      entity.Property(c => c.Email).IsRequired().HasMaxLength(150);
      entity.Property(c => c.Telefone).IsRequired().HasMaxLength(20);
    });

    modelBuilder.Entity<Servico>(entity =>
    {
      entity.HasKey(s => s.Id);
      entity.Property(s => s.Nome).IsRequired().HasMaxLength(150);
      entity.Property(s => s.Preco).HasColumnType("decimal(10,2)");
      entity.Property(s => s.DuracaoMinutos).IsRequired();
    });

    modelBuilder.Entity<Agendamento>(entity =>
    {
      entity.HasKey(a => a.Id);

      entity.HasOne(a => a.Cliente)
            .WithMany(c => c.Agendamentos)
            .HasForeignKey(a => a.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

      entity.HasOne(a => a.Servico)
            .WithMany(s => s.Agendamentos)
            .HasForeignKey(a => a.ServicoId)
            .OnDelete(DeleteBehavior.Restrict);

      entity.Property(a => a.Status)
            .HasConversion<int>()
            .IsRequired();
    });

    var usuarioId = Guid.Parse("11111111-1111-1111-1111-111111111111");

    modelBuilder.Entity<Usuario>().HasData(new Usuario
    {
      Id = usuarioId,
      Nome = "Admin Diva",
      Email = "admin@diva.com",
      PasswordHash = PasswordHelper.Hash("123456"),
      CreatedAt = DateTime.UtcNow
    });
  }
}