using Microsoft.AspNetCore.Mvc;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class MetricaTanqueController(
    IMetricaTanqueService metricaService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<MetricaTanqueResponseDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(metricaService.GetAll());
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(MetricaTanqueResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(long id)
    {
        var metrica = metricaService.GetById(id);

        if (metrica is null)
            return NotFound();

        return Ok(metrica);
    }

    [HttpPost]
    [ProducesResponseType(typeof(MetricaTanqueResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(
        [FromBody] MetricaTanqueRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var metrica = metricaService.Create(request);

        return Ok(metrica);
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(long id)
    {
        return metricaService.Delete(id)
            ? NoContent()
            : NotFound();
    }
}