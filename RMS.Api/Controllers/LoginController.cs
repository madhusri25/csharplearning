using Microsoft.AspNetCore.Mvc;
using RMS.Api.Models;
using RMS.Common.Models.Interfaces;
using RestaurantManagementSystem.Models;

namespace RMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ICustomerLoginService loginService;

    public AuthController(ICustomerLoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpPost("login")]
    public ActionResult<LoginResult> Login(LoginRequest request)
    {
        LoginResult result = loginService.Login(
            request.UserName,
            request.Password);

        if (!result.IsSuccessful)
        {
            return Unauthorized(result);
        }

        return Ok(result);
    }
}