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
  public IActionResult GetAll()
  {
    var clientes = _clienteService.GetAll();
    return Ok(clientes);
  }

  [HttpGet("{id:guid}")]
  public IActionResult GetById(Guid id)
  {
    var cliente = _clienteService.GetById(id);

    if (cliente == null)
      return NotFound();

    return Ok(cliente);
  }

  [HttpPost]
  public IActionResult Create([FromBody] CreateClienteDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var cliente = _clienteService.Create(dto);

    return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
  }

  [HttpPut]
  public IActionResult Update([FromBody] UpdateClienteDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var cliente = _clienteService.Update(dto);

    if (cliente == null)
      return NotFound();

    return Ok(cliente);
  }

  [HttpDelete("{id:guid}")]
  public IActionResult Delete(Guid id)
  {
    var removido = _clienteService.Delete(id);

    if (!removido)
      return NotFound();

    return NoContent();
  }
}
