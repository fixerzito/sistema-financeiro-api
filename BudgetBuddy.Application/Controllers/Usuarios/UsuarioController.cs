using System.Net;
using System.Security.Claims;
using BudgetBuddy.Application.DTO.Login;
using BudgetBuddy.Domain.Dtos.Requests;
using BudgetBuddy.Domain.Dtos.Response;
using BudgetBuddy.Domain.Dtos.Usuarios;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ConfirmarEmailRequest = BudgetBuddy.Application.DTO.Login.ConfirmarEmailRequest;

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
    
    [AllowAnonymous]
    [HttpPost("cadastro")]
    public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var resultado = await _identityService.CadastroInicialAsync(usuarioCadastro);
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
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin)
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
    
    [AllowAnonymous]
    [HttpGet("verificar-email")]
    public async Task<ActionResult<UsuarioVerifyResponse>> VerificarEmail([FromQuery] string email)
    {
        var usuarioResponse = await _identityService.VerificarEmail(email);
        return Ok(usuarioResponse);
    }

    [AllowAnonymous]
    [HttpPost("confirmar-email")]
    public async Task<IActionResult> ConfirmarEmail([FromBody] ConfirmarEmailRequest request)
    {
        Console.WriteLine($"Recebida requisição: Token={request.Token}, Email={request.Email}");

        if (string.IsNullOrEmpty(request.Token) || string.IsNullOrEmpty(request.Email))
        {
            Console.WriteLine("Erro: Token ou e-mail não fornecidos.");
            return BadRequest("Token ou e-mail não fornecidos.");
        }

        var tokenDecoded = WebUtility.UrlDecode(request.Token);

        var resultado = await _identityService.ConfirmarEmailAsync(request.Token, request.Email);

        if (!resultado) 
        {
            Console.WriteLine("Erro ao confirmar e-mail.");
            return BadRequest("Erro ao confirmar e-mail.");
        }

        Console.WriteLine("E-mail confirmado com sucesso.");
        return Ok(new { message = "E-mail confirmado com sucesso." });
    }

    [AllowAnonymous]
    [HttpPost("cadastrar-senha")]
    public async Task<IActionResult> CadastrarSenha([FromBody] CadastroSenhaRequest request)
    {
        var resultado = await _identityService.CadastrarSenhaAsync(request);
        if (!resultado) return BadRequest();
        return Ok( new { message = "Senha cadastrada com sucesso. Agora você pode fazer login." });
    }
}