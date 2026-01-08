using SistemaAgendamentos.Api.Dtos.Clientes;
using SistemaAgendamentos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaAgendamentos.Api.Service;

public class ClienteService
{
  private static readonly List<Cliente> _clientes = new();

  public List<ClienteResponseDto> GetAll()
  {
    return _clientes.Select(MapToResponse).ToList();
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

    _clientes.Add(cliente);

    return MapToResponse(cliente);
  }

  public ClienteResponseDto? GetById(Guid id)
  {
    var cliente = _clientes.FirstOrDefault(c => c.Id == id);

    return cliente == null ? null : MapToResponse(cliente);
  }

  public ClienteResponseDto? Update(UpdateClienteDto dto)
  {
    var cliente = _clientes.FirstOrDefault(c => c.Id == dto.Id);

    if (cliente == null)
      return null;

    cliente.Nome = dto.Nome;
    cliente.Email = dto.Email;
    cliente.Telefone = dto.Telefone;

    return MapToResponse(cliente);
  }

  public bool Delete(Guid id)
  {
    var cliente = _clientes.FirstOrDefault(c => c.Id == id);

    if (cliente == null)
      return false;

    _clientes.Remove(cliente);
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
