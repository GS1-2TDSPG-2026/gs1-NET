using Microsoft.AspNetCore.Mvc;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsuarioController(
    IUsuarioService service)
    : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(service.GetAll());
    }

    [HttpGet("{id:long}")]
    public IActionResult GetById(long id)
    {
        return Ok(service.GetById(id));
    }
}