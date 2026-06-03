using Microsoft.AspNetCore.Mvc;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class PrevisaoIaController(
    IPrevisaoIaService previsaoService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PrevisaoIaResponseDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(previsaoService.GetAll());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PrevisaoIaResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var previsao = previsaoService.GetById(id);

        if (previsao is null)
            return NotFound();

        return Ok(previsao);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PrevisaoIaResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(
        [FromBody] PrevisaoIaRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var previsao = previsaoService.Create(request);

        return Ok(previsao);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        return previsaoService.Delete(id)
            ? NoContent()
            : NotFound();
    }
}