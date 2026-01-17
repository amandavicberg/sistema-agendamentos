namespace SistemaAgendamentos.Api.Models;

public class Cliente
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string Telefone { get; set; } = null!;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}