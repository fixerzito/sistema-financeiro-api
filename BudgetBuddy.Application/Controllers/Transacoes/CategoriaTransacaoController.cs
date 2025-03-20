using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Entities.Validators;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Transacoes
{
    [Authorize]
    [Route("api/categorias-transacao")]
    [ApiController]
    public class CategoriaTransacaoController : Controller
    {
        private readonly ICategoriaTransacaoService _service;

        public CategoriaTransacaoController(ICategoriaTransacaoService service)
        {
            _service = service;
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpGet]
        public async Task<IActionResult> Consultar([FromHeader] string userId)
        {
            var dtos = await _service.GetAllAsync(userId);

            return Ok(dtos);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id, [FromHeader] string userId)
        {
            var dto = await _service.GetByIdAsync(userId, id);
            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCategoria(int id, [FromBody] CategoriaTransacaoFormUpdateDto dto, [FromHeader] string userId)
        {
            try
            {
                await _service.UpdateAsync(dto, userId);
                return NoContent();
            }
            catch 
            {
                return BadRequest();
            }
        }
        
        // Método assíncrono e com UserId no cabeçalho
        [HttpGet("validar-existente")]
        public async Task<IActionResult> IsCategoriaExistente([FromQuery] string nome, [FromHeader] string userId)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("Nome é obrigatório.");
            }

            var existente = new ValidatorExistente
            {
                Existe = await _service.IsCategoriaExistenteAsync(userId, nome)
            };
            return Ok(existente);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CategoriaTransacaoFormInsertDto dto, [FromHeader] string userId)
        {
            var id = await _service.AddAsync(dto, userId);
            var result = new { id = id, nome = dto.Nome };
            return CreatedAtAction(nameof(Consultar), new { id = id }, result);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPost("cadastro-rapido")]
        public async Task<IActionResult> CadastroRapido([FromBody] CategoriaTransacaoCadastroRapidoFormInsertDto dto, [FromHeader] string userId)
        {
            var categoriaTransacaoCadastroRapidoDto = await _service.CadastroRapidoAsync(dto, userId);
            return CreatedAtAction(nameof(Consultar), new { id = categoriaTransacaoCadastroRapidoDto.IdCategoria }, categoriaTransacaoCadastroRapidoDto);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPatch("{id}")]
        public async Task<IActionResult> Apagar(int id, [FromHeader] string userId)
        {
            try
            {
                await _service.DeleteAsync(id, userId);
                return NoContent();
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}
