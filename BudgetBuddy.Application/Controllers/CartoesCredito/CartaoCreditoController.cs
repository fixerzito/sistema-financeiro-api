using BudgetBuddy.Application.ViewModels.CartoesCredito;
using BudgetBuddy.Domain.Dtos.CartoesCredito.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Entities.CreditCards;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Service.Services.CartoesCredito;
using BudgetBuddy.Service.Services.ContasBancarias;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Application.Controllers.CartoesCredito
{
    [ApiController]
    [Route("cartoes")]
    public class CartaoCreditoController : Controller
    {
        private readonly ICartaoCreditoService _service;

        public CartaoCreditoController(BudgetBuddyContext contexto)
        {
            _service = new CartaoCreditoService(contexto);
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
        public IActionResult Cadastrar([FromBody] CartaoCreditoFormInsertDto dto)
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
        public IActionResult Atualizar([FromBody] CartaoCreditoFormUpdateDto dto)
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
