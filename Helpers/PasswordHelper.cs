using System.Security.Cryptography;
using System.Text;

namespace SistemaAgendamentos.Api.Helpers;

public static class PasswordHelper
{
  public static string Hash(string senha)
  {
    using var sha = SHA256.Create();
    var bytes = Encoding.UTF8.GetBytes(senha);
    return Convert.ToBase64String(sha.ComputeHash(bytes));
  }
}
