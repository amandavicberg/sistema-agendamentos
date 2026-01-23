using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaAgendamentos.Api.Data;
using SistemaAgendamentos.Api.Dtos;
using SistemaAgendamentos.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using SistemaAgendamentos.Api.Helpers;

namespace SistemaAgendamentos.Api.Service
{
  public class AuthService
  {
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthService(AppDbContext context, IConfiguration config)
    {
      _context = context;
      _config = config;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
      var exists = await _context.Usuarios.AnyAsync(u => u.Email == dto.Email);
      if (exists)
        throw new Exception("Email já cadastrado.");

      var usuario = new Usuario
      {
        Id = Guid.NewGuid(),
        Nome = dto.Nome,
        Email = dto.Email,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
        Role = "User"
      };

      _context.Usuarios.Add(usuario);
      await _context.SaveChangesAsync();

      return GenerateToken(usuario);
    }

    public async Task<AuthResponseDto?> Login(LoginDto dto)
    {
      var passwordHash = PasswordHelper.Hash(dto.Password);

      var usuario = await _context.Usuarios
          .FirstOrDefaultAsync(u => u.Email == dto.Email && u.PasswordHash == passwordHash);

      if (usuario == null) return null;

      return new AuthResponseDto
      {
        Token = "token-fake-por-enquanto",
        Email = usuario.Email
      };
    }

    private AuthResponseDto GenerateToken(Usuario usuario)
    {
      var claims = new[]
      {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Role)
            };

      var key = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
      );

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
          claims: claims,
          expires: DateTime.UtcNow.AddHours(8),
          signingCredentials: creds
      );

      return new AuthResponseDto
      {
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Email = usuario.Email,
        Role = usuario.Role
      };
    }
  }
}