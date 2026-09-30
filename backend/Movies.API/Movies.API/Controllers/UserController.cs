using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Request.Users;
using Movies.API.Services;
using Movies.API.Users;

namespace Movies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly UserService _service = new();

    [HttpPost]
    public IActionResult Create([FromBody] UserCreateRequest request)
    {
        return _service.Create(request)
            ? Ok("User created with success!")
            : BadRequest("Failed");
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _service.GetById(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UserUpdateRequest request)
    {
        return _service.Update(id, request) ? Ok("Updated!") : BadRequest("Failed");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _service.Delete(id) ? Ok("Deleted!") : BadRequest("Failed");
    }

    [HttpGet("get-all")]
    public IActionResult GetAll() => Ok(_service.GetAll());
}