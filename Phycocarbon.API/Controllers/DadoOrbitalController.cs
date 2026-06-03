using Microsoft.AspNetCore.Mvc;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class DadoOrbitalController(
    IDadoOrbitalService dadoOrbitalService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<DadoOrbitalResponseDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(dadoOrbitalService.GetAll());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(DadoOrbitalResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var dado = dadoOrbitalService.GetById(id);

        if (dado is null)
            return NotFound();

        return Ok(dado);
    }

    [HttpPost]
    [ProducesResponseType(typeof(DadoOrbitalResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(
        [FromBody] DadoOrbitalRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var dado = dadoOrbitalService.Create(request);

        return Ok(dado);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return dadoOrbitalService.Delete(id)
            ? NoContent()
            : NotFound();
    }
}