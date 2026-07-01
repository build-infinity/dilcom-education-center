using DilcomEducationCenter.Domain.Common;
using DilcomEducationCenter.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DilcomEducationCenter.Api.Controllers;

public static class ResultExtension
{
    public static IActionResult ToProblemResult(this Error error) =>
    
        error.ErrorType switch
        {
            ErrorType.Validation   => new BadRequestObjectResult(error),
            ErrorType.NotFound     => new NotFoundObjectResult(error),
            ErrorType.Conflict     => new ConflictObjectResult(error),
            ErrorType.Unauthorized => new UnauthorizedObjectResult(error),
            ErrorType.Forbidden    => new ObjectResult(error) { StatusCode = 403 },

            _ => new ObjectResult(error) { StatusCode = 500}
        };
    
}