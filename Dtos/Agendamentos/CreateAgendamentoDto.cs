namespace SistemaAgendamentos.Api.Dtos.Agendamentos;

public class CreateAgendamentoDto
{
  public Guid ClienteId { get; set; }
  public Guid ServicoId { get; set; }
  public DateTime DataHora { get; set; }
}