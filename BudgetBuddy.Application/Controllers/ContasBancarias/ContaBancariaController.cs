using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.ContasBancarias
{
    [Authorize]
    [Route("api/contas")]
    [ApiController]
    public class ContaBancariaController : Controller
    {
        private readonly IContaBancariaService _service;

        public ContaBancariaController(IContaBancariaService service)
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
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] ContaBancariaFormInsertDto dto, [FromHeader] string userId)
        {
            var id = await _service.AddAsync(userId, dto);

            return CreatedAtAction(nameof(Consultar), new { id = id }, dto);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ContaBancariaFormUpdateDto dto, [FromHeader] string userId)
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
    }
}
