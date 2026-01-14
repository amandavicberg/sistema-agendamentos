using SistemaAgendamentos.Api.Dtos.Agendamentos;
using SistemaAgendamentos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaAgendamentos.Api.Enums;
using SistemaAgendamentos.Api.Data;

namespace SistemaAgendamentos.Api.Service;

public class AgendamentoService
{
  private readonly AppDbContext _context;

  public AgendamentoService(AppDbContext context)
  {
    _context = context;
  }

  public List<AgendamentoResponseDto> GetAll()
  {
    return _context.Agendamentos.Select(MapToResponse).ToList();
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

    _context.Agendamentos.Add(agendamento);
    _context.SaveChanges();

    return MapToResponse(agendamento);
  }

  public AgendamentoResponseDto? GetById(Guid id)
  {
    var agendamento = _context.Agendamentos.FirstOrDefault(a => a.Id == id);

    return agendamento == null ? null : MapToResponse(agendamento);
  }

  public AgendamentoResponseDto? Update(UpdateAgendamentoDto dto)
  {
    var agendamento = _context.Agendamentos.FirstOrDefault(a => a.Id == dto.Id);
    if (agendamento == null)
      return null;

    agendamento.DataHora = dto.DataHora;
    agendamento.Status = dto.Status;

    return MapToResponse(agendamento);
  }


  public bool Delete(Guid id)
  {
    var agendamento = _context.Agendamentos.FirstOrDefault(a => a.Id == id);

    if (agendamento == null)
      return false;

    _context.Agendamentos.Remove(agendamento);
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