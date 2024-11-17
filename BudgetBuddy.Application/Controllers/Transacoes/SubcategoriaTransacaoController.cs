using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Transacoes
{
    [Route("api/subcategorias-transacao")]
    [ApiController]
    public class SubcategoriaTransacaoController : Controller
    {
        private readonly ISubcategoriaTransacaoService _service;

        public SubcategoriaTransacaoController(ISubcategoriaTransacaoService service)
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
            catch 
            {
                return BadRequest();
            }
        }
        
        [HttpGet("dropdown/{categoriaId}")]
        public IActionResult ConsultarDropdownPorCategoriaId(int categoriaId)
        {
            var dto = _service.GetByCategoriaId(categoriaId);
            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }
    }
}
