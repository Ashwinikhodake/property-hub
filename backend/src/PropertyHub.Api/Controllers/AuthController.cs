using System.Data;
using Microsoft.AspNetCore.Mvc;
using PropertyHub.Application.Features.Authentication.Register;

namespace PropertyHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IRegisterUserService _registerUserService;

    public AuthController(IRegisterUserService registerUserService)
    {
        _registerUserService = registerUserService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterUserResponse>> Register(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _registerUserService.RegisterAsync(request, cancellationToken);
            return Ok(response);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new
            {
                message = ex.Message
            });
        }
    }
}