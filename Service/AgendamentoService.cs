using SistemaAgendamentos.Api.Dtos.Agendamentos;
using SistemaAgendamentos.Api.Models;
using SistemaAgendamentos.Api.Enums;
using SistemaAgendamentos.Api.Data;

namespace SistemaAgendamentos.Api.Service;

using Microsoft.EntityFrameworkCore;

public class AgendamentoService
{
  private readonly AppDbContext _context;

  public AgendamentoService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<AgendamentoResponseDto>> GetAllAsync()
  {
    var agendamentos = await _context.Agendamentos
      .Include(a => a.Cliente)
      .Include(a => a.Servico)
      .ToListAsync();

    return agendamentos.Select(MapToResponse).ToList();
  }

  public async Task<AgendamentoResponseDto?> GetByIdAsync(Guid id)
  {
    var agendamento = await _context.Agendamentos
      .Include(a => a.Cliente)
      .Include(a => a.Servico)
      .FirstOrDefaultAsync(a => a.Id == id);

    return agendamento == null ? null : MapToResponse(agendamento);
  }

  public async Task<AgendamentoResponseDto> CreateAsync(CreateAgendamentoDto dto)
  {
    var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == dto.ClienteId);
    if (!clienteExiste)
      throw new ArgumentException("Cliente não encontrado.");

    var servicoExiste = await _context.Servicos.AnyAsync(s => s.Id == dto.ServicoId);
    if (!servicoExiste)
      throw new ArgumentException("Serviço não encontrado.");

    var conflito = await _context.Agendamentos
      .AnyAsync(a => a.DataHora == dto.DataHora
                  && a.Status != StatusAgendamento.Cancelado);

    if (conflito)
      throw new InvalidOperationException("Já existe um agendamento para este horário.");

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
    await _context.SaveChangesAsync();

    return MapToResponse(agendamento);
  }

  public async Task<AgendamentoResponseDto?> UpdateAsync(UpdateAgendamentoDto dto)
  {
    var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == dto.Id);
    if (agendamento == null)
      return null;

    agendamento.DataHora = dto.DataHora;
    agendamento.Status = dto.Status;

    await _context.SaveChangesAsync();
    return MapToResponse(agendamento);
  }

  public async Task<bool> DeleteAsync(Guid id)
  {
    var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == id);
    if (agendamento == null)
      return false;

    _context.Agendamentos.Remove(agendamento);
    await _context.SaveChangesAsync();
    return true;
  }

  private static AgendamentoResponseDto MapToResponse(Agendamento a)
  {
    return new AgendamentoResponseDto
    {
      Id = a.Id,
      ClienteId = a.ClienteId,
      ClienteNome = a.Cliente.Nome,
      ServicoId = a.ServicoId,
      ServicoNome = a.Servico.Nome,
      DataHora = a.DataHora,
      Status = a.Status,
      CreatedAt = a.CreatedAt
    };
  }
}