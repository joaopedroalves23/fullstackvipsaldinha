using Microsoft.AspNetCore.Mvc;
using Movies.API.Request;
using Movies.API.Request.Movies;
using Movies.API.Services;

namespace Movies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieService _service = new();

    [HttpPost]
    public IActionResult Create([FromBody] MovieCreateRequest request)
    {
        return _service.Create(request)
            ? Ok("Movie created with success!")
            : BadRequest("Failed to create movie");
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _service.GetById(id);
        return movie == null ? NotFound() : Ok(movie);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] MovieUpdateRequest request)
    {
        return _service.Update(id, request)
            ? Ok("Updated!")
            : BadRequest("Failed to update");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _service.Delete(id) ? Ok("Deleted!") : BadRequest("Failed to delete");
    }

    [HttpGet("get-all")]
    public IActionResult GetAll() => Ok(_service.GetAll());
}