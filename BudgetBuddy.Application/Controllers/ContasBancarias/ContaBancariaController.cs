using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Service.Services.ContasBancarias;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.ContasBancarias
{
    [ApiController]
    [Route("/contas")]
    public class ContaBancariaController : Controller
    {
        private readonly IContaBancariaService _service;

        public ContaBancariaController(BudgetBuddyContext contexto)
        {
            _service = new ContaBancariaService(contexto);
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

        [HttpPost]
        public IActionResult Cadastrar([FromBody] ContaBancariaFormInsertDto dto)
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

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] ContaBancariaFormUpdateDto dto)
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
