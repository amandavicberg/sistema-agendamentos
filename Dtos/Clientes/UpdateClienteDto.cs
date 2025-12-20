using System.ComponentModel.DataAnnotations;

namespace SistemaAgendamentos.Api.Dtos.Clientes;

public class UpdateClienteDto
{
  public Guid Id { get; set; }
  [Required]
  [StringLength(100)]
  public string Nome { get; set; } = string.Empty;
  [Required]
  [EmailAddress]
  public string Email { get; set; } = string.Empty;
  [Required]
  [StringLength(20)]
  public string Telefone { get; set; } = string.Empty;
}