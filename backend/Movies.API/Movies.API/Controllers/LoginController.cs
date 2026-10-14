using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.API.Authentication;
using Movies.API.DatabaseContext;
using Movies.API.Encrypt;
using Movies.API.Request;
using Movies.API.Request.Login;

namespace Movies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] AuthRequest request)
    {
        using var connection = new DataContext();

        var hash = PasswordEncryptor.EncryptPassword(request.Password);

        var user = connection.Users
            .AsNoTracking()
            .FirstOrDefault(u => u.Username == request.Username && u.Password == hash);

        if (user == null)
            return BadRequest("Login failed!");

        var token = JwtAuthManager.GenerateToken(user.Username);
        return Ok($"Login successfull! Jwt: {token}");
    }
}