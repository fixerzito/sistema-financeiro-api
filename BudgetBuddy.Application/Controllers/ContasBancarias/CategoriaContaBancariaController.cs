
using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.ContasBancarias
{
    [Route("api/categorias-contas-bancarias")]
    [ApiController]
    public class CategoriaContaBancariaController : Controller
    {
        private readonly ICategoriaContaBancariaService _service;

        public CategoriaContaBancariaController(ICategoriaContaBancariaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var result = _service.GetAll();
            //var result = await _service.GetAllAsync(filtro);

            //var response = new
            //{
            //    Dados = result.Data,
            //    QuantidadeRegistros = result.TotalRecords
            //};

            return Ok(result);
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

            return CreatedAtAction(nameof(Consultar), new { id = id}, new {id});
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            try
            {
                _service.Delete(id);
            return NoContent();
            }
            catch 
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
            catch 
            {
                return BadRequest();
            }
        }
    }
}
