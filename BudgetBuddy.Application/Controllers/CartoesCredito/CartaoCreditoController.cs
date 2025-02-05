using BudgetBuddy.Domain.Dtos.CartoesCredito.Forms;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.CartoesCredito
{
    [Route("api/cartoes")]
    [ApiController]
    public class CartaoCreditoController : Controller
    {
        private readonly ICartaoCreditoService _service;

        public CartaoCreditoController(ICartaoCreditoService service)
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
        public IActionResult Cadastrar([FromBody] CartaoCreditoFormInsertDto dto)
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
        public IActionResult Atualizar([FromBody] CartaoCreditoFormUpdateDto dto)
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
