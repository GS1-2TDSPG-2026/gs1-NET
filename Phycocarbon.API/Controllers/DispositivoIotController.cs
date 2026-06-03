using Microsoft.AspNetCore.Mvc;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class DispositivoIotController(
    IDispositivoIotService dispositivoService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<DispositivoIotResponseDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(dispositivoService.GetAll());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(DispositivoIotResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var dispositivo = dispositivoService.GetById(id);

        if (dispositivo is null)
            return NotFound();

        return Ok(dispositivo);
    }

    [HttpPost]
    [ProducesResponseType(typeof(DispositivoIotResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(
        [FromBody] DispositivoIotRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var dispositivo = dispositivoService.Create(request);

        return Ok(dispositivo);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return dispositivoService.Delete(id)
            ? NoContent()
            : NotFound();
    }
}