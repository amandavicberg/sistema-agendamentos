using SistemaAgendamentos.Api.Enums;

namespace SistemaAgendamentos.Api.Dtos.Agendamentos;

public class UpdateAgendamentoDto
{
  public Guid Id { get; set; }
  public DateTime DataHora { get; set; }
  public StatusAgendamento Status { get; set; }
}
