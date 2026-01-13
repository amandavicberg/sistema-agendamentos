using Microsoft.AspNetCore.Mvc;
using SistemaAgendamentos.Api.Dtos.Servicos;
using SistemaAgendamentos.Api.Models;
using SistemaAgendamentos.Api.Service;
using System.Collections.Generic;

namespace SistemaAgendamentos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ServicoController : ControllerBase
{
  private readonly ServicoService _servicoService;

  public ServicoController(ServicoService servicoService)
  {
    _servicoService = servicoService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    var servico = _servicoService.GetAll();
    return Ok(servico);
  }

  [HttpGet("{id:guid}")]
  public IActionResult GetById(Guid id)
  {
    var servico = _servicoService.GetById(id);

    if (servico == null)
      return NotFound();

    return Ok(servico);
  }

  [HttpPost]
  public IActionResult Create(CreateServicoDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var servico = _servicoService.Create(dto);

    return CreatedAtAction(nameof(GetById), new { id = servico.Id }, servico);
  }

  [HttpPut]
  public IActionResult Update([FromBody] UpdateServicoDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var servico = _servicoService.Update(dto);

    if (servico == null)
      return NotFound();

    return Ok(servico);
  }

  [HttpDelete("{id:guid}")]
  public IActionResult Delete(Guid id)
  {
    var removido = _servicoService.Delete(id);

    if (!removido)
      return NotFound();

    return NoContent();
  }
}