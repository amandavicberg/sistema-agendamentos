using System.ComponentModel.DataAnnotations;

namespace SistemaAgendamentos.Api.Dtos.Servicos;

public class CreateServicoDto
{
  [Required]
  [StringLength(100)]
  public string Nome { get; set; } = string.Empty;
  [Required]
  public decimal Preco { get; set; }
  [Required]
  public int DuracaoMinutos { get; set; }
}