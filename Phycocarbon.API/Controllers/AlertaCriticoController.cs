using Microsoft.AspNetCore.Mvc;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class AlertaCriticoController(
    IAlertaCriticoService alertaService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AlertaCriticoResponseDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(alertaService.GetAll());
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(AlertaCriticoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(long id)
    {
        var alerta = alertaService.GetById(id);

        if (alerta is null)
            return NotFound();

        return Ok(alerta);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AlertaCriticoResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(
        [FromBody] AlertaCriticoRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var alerta = alertaService.Create(request);

        return Ok(alerta);
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(long id)
    {
        return alertaService.Delete(id)
            ? NoContent()
            : NotFound();
    }
}