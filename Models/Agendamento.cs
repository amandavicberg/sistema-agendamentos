using SistemaAgendamentos.Api.Enums;

namespace SistemaAgendamentos.Api.Models;

public class Agendamento
{
  public Guid Id { get; set; }

  public Guid ClienteId { get; set; }
  public Cliente Cliente { get; set; } = null!;

  public Guid ServicoId { get; set; }
  public Servico Servico { get; set; } = null!;

  public DateTime DataHora { get; set; }
  public StatusAgendamento Status { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}