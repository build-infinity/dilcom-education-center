using System.Security.Claims;
using DilcomEducationCenter.Application.DTOs;
using DilcomEducationCenter.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DilcomEducationCenter.Api.Controllers;

[ApiController]
[Route("dilcom/users")]
public sealed class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest createUserRequest, CancellationToken cancellationToken)
    {
        var result = await _userService.CreateUserAsync(createUserRequest, GetCurrentUser().Role, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess : user => CreatedAtAction(nameof(GetUser), new { id = user.Id }, user),
            onFailure : error => error.ToProblemResult()
        );
    }
    // place holder
    public void GetUser() {}

    private (Guid Id, string Role) GetCurrentUser ()
    {
        var id = Guid.Parse(User.FindFirstValue("sub")!);
        var role = User.FindFirstValue("role")!;

        return (id, role);
    }
}