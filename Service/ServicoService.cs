using SistemaAgendamentos.Api.Dtos.Servicos;
using SistemaAgendamentos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaAgendamentos.Api.Data;

namespace SistemaAgendamentos.Api.Service;

public class ServicoService
{
  private readonly AppDbContext _context;

  public ServicoService(AppDbContext context)
  {
    _context = context;
  }

  public List<ServicoResponseDto> GetAll()
  {
    return _context.Servicos.Select(MapToResponse).ToList();
  }

  public ServicoResponseDto Create(CreateServicoDto dto)
  {
    var servico = new Servico
    {
      Id = Guid.NewGuid(),
      Nome = dto.Nome,
      Preco = dto.Preco,
      DuracaoMinutos = dto.DuracaoMinutos,
      CreatedAt = DateTime.UtcNow
    };

    _context.Servicos.Add(servico);
    _context.SaveChanges();

    return MapToResponse(servico);
  }

  public ServicoResponseDto? GetById(Guid id)
  {
    var servico = _context.Servicos.FirstOrDefault(s => s.Id == id);

    return servico == null ? null : MapToResponse(servico);
  }

  public ServicoResponseDto? Update(UpdateServicoDto dto)
  {
    var servico = _context.Servicos.FirstOrDefault(s => s.Id == dto.Id);

    if (servico == null)
      return null;

    servico.Nome = dto.Nome;
    servico.Preco = dto.Preco;
    servico.DuracaoMinutos = dto.DuracaoMinutos;

    return MapToResponse(servico);
  }

  public bool Delete(Guid id)
  {
    var servico = _context.Servicos.FirstOrDefault(s => s.Id == id);

    if (servico == null)
      return false;

    _context.Servicos.Remove(servico);
    return true;
  }

  public static ServicoResponseDto MapToResponse(Servico servico)
  {
    return new ServicoResponseDto
    {
      Id = servico.Id,
      Nome = servico.Nome,
      Preco = servico.Preco,
      DuracaoMinutos = servico.DuracaoMinutos,
      CreatedAt = servico.CreatedAt
    };
  }
}