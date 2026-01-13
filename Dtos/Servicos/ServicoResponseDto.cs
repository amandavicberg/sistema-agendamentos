namespace SistemaAgendamentos.Api.Dtos.Servicos;

public class ServicoResponseDto
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public decimal Preco { get; set; }
  public int DuracaoMinutos { get; set; }
  public DateTime CreatedAt { get; set; }
}