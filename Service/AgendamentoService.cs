using SistemaAgendamentos.Api.Dtos.Agendamentos;
using SistemaAgendamentos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaAgendamentos.Api.Enums;

namespace SistemaAgendamentos.Api.Service;

public class AgendamentoService
{
  private static readonly List<Agendamento> _agendamentos = new();

  public List<AgendamentoResponseDto> GetAll()
  {
    return _agendamentos.Select(MapToResponse).ToList();
  }

  public AgendamentoResponseDto Create(CreateAgendamentoDto dto)
  {
    var agendamento = new Agendamento
    {
      Id = Guid.NewGuid(),
      ClienteId = dto.ClienteId,
      ServicoId = dto.ServicoId,
      DataHora = dto.DataHora,
      Status = StatusAgendamento.Pendente,
      CreatedAt = DateTime.UtcNow
    };

    _agendamentos.Add(agendamento);

    return MapToResponse(agendamento);
  }

  public AgendamentoResponseDto? GetById(Guid id)
  {
    var agendamento = _agendamentos.FirstOrDefault(a => a.Id == id);

    return agendamento == null ? null : MapToResponse(agendamento);
  }

  public AgendamentoResponseDto? Update(UpdateAgendamentoDto dto)
  {
    var agendamento = _agendamentos.FirstOrDefault(a => a.Id == dto.Id);
    if (agendamento == null)
      return null;

    agendamento.DataHora = dto.DataHora;
    agendamento.Status = dto.Status;

    return MapToResponse(agendamento);
  }


  public bool Delete(Guid id)
  {
    var agendamento = _agendamentos.FirstOrDefault(a => a.Id == id);

    if (agendamento == null)
      return false;

    _agendamentos.Remove(agendamento);
    return true;
  }

  private static AgendamentoResponseDto MapToResponse(Agendamento a)
  {
    return new AgendamentoResponseDto
    {
      Id = a.Id,
      ClienteId = a.ClienteId,
      ServicoId = a.ServicoId,
      DataHora = a.DataHora,
      Status = a.Status,
      CreatedAt = a.CreatedAt
    };
  }
}