using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Phycocarbon.API.Exceptions;

public sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(
            exception,
            "Erro não tratado: {Message}",
            exception.Message);

        var (statusCode, title) = exception switch
        {
            ArgumentNullException =>
                (StatusCodes.Status400BadRequest,
                    "Parâmetro obrigatório não informado"),

            ArgumentException =>
                (StatusCodes.Status400BadRequest,
                    "Requisição inválida"),

            KeyNotFoundException =>
                (StatusCodes.Status404NotFound,
                    "Recurso não encontrado"),

            UnauthorizedAccessException =>
                (StatusCodes.Status401Unauthorized,
                    "Acesso não autorizado"),

            _ =>
                (StatusCodes.Status500InternalServerError,
                    "Erro interno do servidor")
        };

        var problem = new ProblemDetails
        {
            Title = title,
            Status = statusCode,
            Detail = statusCode == StatusCodes.Status500InternalServerError
                ? "Ocorreu um erro interno."
                : exception.Message,
            Instance = httpContext.Request.Path
        };

        problem.Extensions["traceId"] =
            httpContext.TraceIdentifier;

        problem.Extensions["timestamp"] =
            DateTime.UtcNow;

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(
            problem,
            cancellationToken);

        return true;
    }
}