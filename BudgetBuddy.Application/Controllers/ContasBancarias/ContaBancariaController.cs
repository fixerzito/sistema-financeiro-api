using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.ContasBancarias
{
    [Route("api/contas")]
    [ApiController]
    public class ContaBancariaController : Controller
    {
        private readonly IContaBancariaService _service;

        public ContaBancariaController(IContaBancariaService service)
        {
            _service = service;
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

        [HttpPatch("{id}")]
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
        public IActionResult Atualizar([FromBody] ContaBancariaFormUpdateDto dto)
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
