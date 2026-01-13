namespace SistemaAgendamentos.Api.Models;

public class Servico
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public decimal Preco { get; set; }
  public int DuracaoMinutos { get; set; }
  public DateTime CreatedAt { get; set; }

  public Servico()
  {
    Id = Guid.NewGuid();
    CreatedAt = DateTime.UtcNow;
  }
}