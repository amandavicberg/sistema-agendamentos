using Microsoft.AspNetCore.Mvc;
using SistemaAgendamentos.Api.Dtos.Agendamentos;
using SistemaAgendamentos.Api.Models;
using SistemaAgendamentos.Api.Service;
using System.Collections.Generic;

namespace SistemaAgendamentos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AgendamentoController : ControllerBase
{
  private readonly AgendamentoService _agendamentoService;

  public AgendamentoController(AgendamentoService agendamentoService)
  {
    _agendamentoService = agendamentoService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    var agendamentos = _agendamentoService.GetAll();
    return Ok(agendamentos);
  }

  [HttpGet("{id:guid}")]
  public IActionResult GetById(Guid id)
  {
    var agendamento = _agendamentoService.GetById(id);

    if (agendamento == null)
      return NotFound();

    return Ok(agendamento);
  }

  [HttpPost]
  public IActionResult Create([FromBody] CreateAgendamentoDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var agendamento = _agendamentoService.Create(dto);

    return CreatedAtAction(nameof(GetById), new { id = agendamento.Id }, agendamento);
  }

  [HttpPut]
  public IActionResult Update([FromBody] UpdateAgendamentoDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var agendamento = _agendamentoService.Update(dto);

    if (agendamento == null)
      return NotFound();

    return Ok(agendamento);
  }

  [HttpDelete("{id:guid}")]
  public IActionResult Delete(Guid id)
  {
    var removido = _agendamentoService.Delete(id);

    if (!removido)
      return NotFound();

    return NoContent();
  }
}