using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Service.Services.Transacoes;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Transacoes
{
    [ApiController]
    [Route("subcategorias-transacao")]
    public class SubcategoriaTransacaoController : Controller
    {
        private readonly ISubcategoriaTransacaoService _service;

        public SubcategoriaTransacaoController(BudgetBuddyContext contexto)
        {
            _service = new SubcategoriaTransacaoService(contexto);
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var dtos = _service.GetAll();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var dto = _service.GetById(id);
            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] SubcategoriaTransacaoFormInsertDto dto)
        {
            var id = _service.Add(dto);

            return CreatedAtAction(nameof(Consultar), new { id = id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] SubcategoriaTransacaoFormUpdateDto dto)
        {
            try
            {
                _service.Update(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
