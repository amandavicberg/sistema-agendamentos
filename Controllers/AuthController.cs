using Microsoft.AspNetCore.Mvc;
using SistemaAgendamentos.Api.Dtos;
using SistemaAgendamentos.Api.Service;

namespace SistemaAgendamentos.Api.Controllers
{
  [ApiController]
  [Route("api/auth")]
  public class AuthController : ControllerBase
  {
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
      var result = await _authService.RegisterAsync(dto);
      return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
      var result = await _authService.Login(dto);
      if (result == null) return Unauthorized("Email ou senha inválidos");

      return Ok(result);
    }
  }
}