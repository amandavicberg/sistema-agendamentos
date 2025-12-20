namespace SistemaAgendamentos.Api.Models;

public class Cliente
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Telefone { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }

  public Cliente()
  {
    Id = Guid.NewGuid();
    CreatedAt = DateTime.UtcNow;
  }
}