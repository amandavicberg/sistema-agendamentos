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
  public async Task<IActionResult> GetAll()
  {
    var agendamentos = await _agendamentoService.GetAllAsync();
    return Ok(agendamentos);
  }

  [HttpGet("{id:guid}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var agendamento = await _agendamentoService.GetByIdAsync(id);
    if (agendamento == null)
      return NotFound();

    return Ok(agendamento);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateAgendamentoDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    try
    {
      var agendamento = await _agendamentoService.CreateAsync(dto);
      return CreatedAtAction(nameof(GetById), new { id = agendamento.Id }, agendamento);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(new { message = ex.Message });
    }
    catch (InvalidOperationException ex)
    {
      return Conflict(new { message = ex.Message });
    }
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody] UpdateAgendamentoDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var agendamento = await _agendamentoService.UpdateAsync(dto);
    if (agendamento == null)
      return NotFound();

    return Ok(agendamento);
  }

  [HttpDelete("{id:guid}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    var removido = await _agendamentoService.DeleteAsync(id);
    if (!removido)
      return NotFound();

    return NoContent();
  }
}