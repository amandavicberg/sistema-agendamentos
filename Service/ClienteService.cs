using SistemaAgendamentos.Api.Dtos.Clientes;
using SistemaAgendamentos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaAgendamentos.Api.Data;

namespace SistemaAgendamentos.Api.Service;

public class ClienteService
{
  private readonly AppDbContext _context;

  public ClienteService(AppDbContext context)
  {
    _context = context;
  }

  public List<ClienteResponseDto> GetAll()
  {
    return _context.Clientes.Select(MapToResponse).ToList();
  }

  public ClienteResponseDto Create(CreateClienteDto dto)
  {
    var cliente = new Cliente
    {
      Id = Guid.NewGuid(),
      Nome = dto.Nome,
      Email = dto.Email,
      Telefone = dto.Telefone,
      CreatedAt = DateTime.UtcNow
    };

    _context.Clientes.Add(cliente);
    _context.SaveChanges();

    return MapToResponse(cliente);
  }

  public ClienteResponseDto? GetById(Guid id)
  {
    var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

    return cliente == null ? null : MapToResponse(cliente);
  }

  public ClienteResponseDto? Update(UpdateClienteDto dto)
  {
    var cliente = _context.Clientes.FirstOrDefault(c => c.Id == dto.Id);

    if (cliente == null)
      return null;

    cliente.Nome = dto.Nome;
    cliente.Email = dto.Email;
    cliente.Telefone = dto.Telefone;

    return MapToResponse(cliente);
  }

  public bool Delete(Guid id)
  {
    var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

    if (cliente == null)
      return false;

    _context.Clientes.Remove(cliente);
    return true;
  }

  private static ClienteResponseDto MapToResponse(Cliente cliente)
  {
    return new ClienteResponseDto
    {
      Id = cliente.Id,
      Nome = cliente.Nome,
      Email = cliente.Email,
      Telefone = cliente.Telefone,
      CreatedAt = cliente.CreatedAt
    };
  }
}
