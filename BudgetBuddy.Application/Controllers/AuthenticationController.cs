using BudgetBuddy.Application.DTO.Login;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/token")]
[ApiController]
public class AuthenticationController : Controller
{
    private readonly ITokenService _tokenService;

    public AuthenticationController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult AdicionarUsuario(LoginDto loginDto)
    {
        var token = _tokenService.GenerateToken(loginDto);
        
        if(token == "")
            return Unauthorized();
        
        return Ok(token);
    }
}