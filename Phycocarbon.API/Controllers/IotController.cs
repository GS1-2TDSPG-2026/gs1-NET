using Microsoft.AspNetCore.Mvc;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.API.Controllers;

[Route("api/iot")]
[ApiController]
[Produces("application/json")]
public class IotController(
    IIotTelemetryService iotTelemetryService,
    IIotCommandService iotCommandService)
    : ControllerBase
{
    [HttpPost("telemetria")]
    [ProducesResponseType(typeof(MetricaTanqueResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult RegistrarTelemetria(
        [FromBody] IotTelemetriaRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var metrica = iotTelemetryService.RegistrarTelemetria(request);

            return Ok(metrica);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new
            {
                erro = ex.Message
            });
        }
    }

    [HttpPost("comandos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EnviarComando(
        [FromBody] IotComandoRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await iotCommandService.EnviarComandoAsync(request);

            return Ok(new
            {
                mensagem = "Comando enviado via MQTT com sucesso."
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new
            {
                erro = ex.Message
            });
        }
    }
}