using SistemaAgendamentos.Api.Dtos.Clientes;
using SistemaAgendamentos.Api.Models;

namespace SistemaAgendamentos.Api.Service;

public class ClienteService
{
  public List<Cliente> Listar()
  {
    return _clientes;
  }

  public Cliente? Update(UpdateClienteDto dto)
  {
    var cliente = _clientes.FirstOrDefault(c => c.Id == dto.Id);

    if (cliente is null)
      return null;

    cliente.Nome = dto.Nome;
    cliente.Email = dto.Email;
    cliente.Telefone = dto.Telefone;

    return cliente;
  }

  public Cliente Criar(CreateClienteDto dto)
  {
    var cliente = new Cliente
    {
      Id = Guid.NewGuid(),
      Nome = dto.Nome,
      Email = dto.Email,
      Telefone = dto.Telefone,
      CreatedAt = DateTime.UtcNow
    };

    return cliente;
  }

  public bool Delete(Guid id)
  {
    var cliente = new _clientes.FirstOrDefault(c => c.Id == id);

    if (cliente is null)
      return false;

    _clientes.Remove(cliente);
    return true;
  }
}
