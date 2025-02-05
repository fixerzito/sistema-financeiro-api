using System.Security.Claims;
using BudgetBuddy.Domain.Dtos.Requests;
using BudgetBuddy.Domain.Dtos.Response;
using BudgetBuddy.Domain.Dtos.Usuarios;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Usuarios;

[Route("api/usuario")]
[ApiController]
public class UsuarioController : Controller
{
    private readonly IIdentityService _identityService;

    public UsuarioController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    [Authorize]
    [HttpPost("cadastro")]
    public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var resultado = await _identityService.CadstrarUsuario(usuarioCadastro);
        if (resultado.Sucesso)
        {
            return Ok(resultado);
        }
        else if (resultado.Erros.Count > 0)
        {
            return BadRequest(resultado);
        }
            
        
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    
    [Authorize]
    [HttpPost("login")]
    public async Task<ActionResult<UsuarioLoginResponse>> Cadastrar(UsuarioLoginRequest usuarioLogin)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var resultado = await _identityService.Login(usuarioLogin);
        if (resultado.Sucesso)
        {
            return Ok(resultado);
        }
        
        return Unauthorized(resultado);
    }

    [Authorize]
    [HttpPost("refresh-login")]
    public async Task<ActionResult<UsuarioLoginResponse>> RefreshLogin()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var usuarioId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (usuarioId == null)
        {
            return BadRequest();
        }
        
        var resultado = await _identityService.LoginSemSenha(usuarioId);
        if (resultado.Sucesso)
            return Ok(resultado);
        
        return Unauthorized();
    }
    
    [HttpGet("verificar-email")]
    public async Task<ActionResult<UsuarioVerifyResponse>> VerificarEmail([FromQuery] string email)
    {
        var usuarioResponse = await _identityService.VerificarEmail(email);
        return Ok(usuarioResponse);
    }
}