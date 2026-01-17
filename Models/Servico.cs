namespace SistemaAgendamentos.Api.Models;

public class Servico
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = null!;
  public decimal Preco { get; set; }
  public int DuracaoMinutos { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}