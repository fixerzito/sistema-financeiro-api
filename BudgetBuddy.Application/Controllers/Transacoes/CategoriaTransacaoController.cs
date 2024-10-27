using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Service.Services.Transacoes;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Transacoes
{
    [ApiController]
    [Route("/categorias-transacao")]
    public class CategoriaTransacaoController : Controller
    {
        private readonly ICategoriaTransacaoService _service;

        public CategoriaTransacaoController(BudgetBuddyContext contexto)
        {
            _service = new CategoriaTransacaoService(contexto);
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

        [HttpPut("{id}")]
        public IActionResult AtualizarCategoria([FromBody] CategoriaTransacaoFormUpdateDto dto)
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

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CategoriaTransacaoFormInsertDto dto)
        {
            var id = _service.Add(dto);

            return CreatedAtAction(nameof(Consultar), new { id = id }, dto);
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

    }
}

