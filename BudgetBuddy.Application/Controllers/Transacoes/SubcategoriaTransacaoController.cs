using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Entities.Validators;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Transacoes
{
    [Authorize]
    [Route("api/subcategorias-transacao")]
    [ApiController]
    public class SubcategoriaTransacaoController : Controller
    {
        private readonly ISubcategoriaTransacaoService _service;

        public SubcategoriaTransacaoController(ISubcategoriaTransacaoService service)
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
        [HttpGet("validar-existente")]
        public async Task<IActionResult> IsSubcategoriaExistente([FromHeader] string userId, [FromQuery] string nome, [FromQuery]int? idCategoria = null)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("Nome é obrigatório.");
            }

            var existe = new ValidatorExistente
            {
                Existe = await _service.IsSubcategoriaExistenteAsync(userId, nome, idCategoria)
            };
            return Ok(existe);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPatch("{id}")]
        public async Task<IActionResult> Apagar(int id, [FromHeader] string userId)
        {
            try
            {
                await _service.DeleteAsync(userId, id);
                return NoContent();
            }
            catch 
            {
                return BadRequest();
            }
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] SubcategoriaTransacaoFormInsertDto dto, [FromHeader] string userId)
        {
            var id = await _service.AddAsync(userId, dto);
            var result = new { id = id, nome = dto.Nome };
            return CreatedAtAction(nameof(Consultar), new { id = id }, result);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] SubcategoriaTransacaoFormUpdateDto dto, [FromHeader] string userId)
        {
            try
            {
                await _service.UpdateAsync(userId, dto);
                return NoContent();
            }
            catch 
            {
                return BadRequest();
            }
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpGet("dropdown/{categoriaId}")]
        public async Task<IActionResult> ConsultarDropdownPorCategoriaId(int categoriaId, [FromHeader] string userId)
        {
            var dto = await _service.GetByCategoriaIdAsync(userId, categoriaId);
            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }
    }
}
