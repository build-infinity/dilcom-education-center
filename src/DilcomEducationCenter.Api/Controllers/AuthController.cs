using DilcomEducationCenter.Application.DTOs;
using DilcomEducationCenter.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DilcomEducationCenter.Api.Controllers;

[ApiController]
[Route("dilcom/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var result = await _authService.Login(loginRequest, cancellationToken);

        if(result.IsSuccess)
            return Ok(result.Data);
        
        return Unauthorized(result.Error);
    }
}