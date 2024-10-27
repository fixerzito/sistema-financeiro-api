using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.Filters;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Service.Services.ContasBancarias;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.ContasBancarias
{
    [ApiController]
    [Route("/categorias-contas-bancarias")]
    public class CategoriaContaBancariaController : Controller
    {
        private readonly ICategoriaContaBancariaService _service;

        public CategoriaContaBancariaController(BudgetBuddyContext contexto)
        {
            _service = new CategoriaContaBancariaService(contexto);
        }

        [HttpGet]
        public IActionResult Consultar([FromQuery] TableFilter filtro )
        {
            var tableDto = _service.GetAll(filtro);

            return Ok(tableDto);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var dto =_service.GetById(id);
             
            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CategoriaContaBancariaFormInsertDto dto)
        {
            var id = _service.Add(dto);

            return CreatedAtAction(nameof(Consultar), new { id = id}, dto);
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
        public IActionResult Atualizar([FromBody] CategoriaContaBancariaFormUpdateDto dto)
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
