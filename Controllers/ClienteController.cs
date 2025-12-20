using Microsoft.AspNetCore.Mvc;
using SistemaAgendamentos.Api.Dtos.Clientes;
using SistemaAgendamentos.Api.Models;
using SistemaAgendamentos.Api.Service;
using System.Collections.Generic;

namespace SistemaAgendamentos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
  private readonly ClienteService _clienteService;

  public ClienteController(ClienteService clienteService)
  {
    _clienteService = clienteService;
  }

  [HttpGet]
  public IActionResult<List<Cliente>> GetAll()
  {
    var clientes = _clienteService.Listar();
    return Ok(clientes);
  }

  [HttpPut("{id:guid}")]
  public IActionResult GetById(Guid id, [FromBody] UpdateClienteDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    dto.Id = id;

    var cliente = _clienteService.Update(dto);

    if (cliente is null)
      return NotFound();

    return Ok(cliente);
  }

  [HttpPost]
  public ActionResult<Cliente> Criar([FromBody] CreateClienteDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var cliente = _clienteService.Criar(dto);

    return CreatedAtAction(nameof(Criar), new { id = cliente.Id }, cliente);
  }

  [HttpDelete("{id:guid}")]
  public ActionResult Delete(Guid id)
  {
    if (!ModelState.isValid)
      return BadRequest(ModelState);

    var removido = _clienteService.Delete(id);

    if(!removido)
      return NotFound();

    return NoContent();
  }
}
