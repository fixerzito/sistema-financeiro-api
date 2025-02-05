using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Entities.Validators;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Transacoes
{
    [Route("api/categorias-transacao")]
    [ApiController]
    public class CategoriaTransacaoController : Controller
    {
        private readonly ICategoriaTransacaoService _service;

        public CategoriaTransacaoController(ICategoriaTransacaoService service)
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

        [HttpPut("{id}")]
        public IActionResult AtualizarCategoria([FromBody] CategoriaTransacaoFormUpdateDto dto)
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
        
        [HttpGet("validar-existente")]
        public async Task<IActionResult> IsCategoriaExistente([FromQuery] string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("Nome é obrigatório.");
            }

            var existente = new ValidatorExistente();
            existente.Existe = await _service.IsCategoriaExistente(nome);
            return Ok(existente);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CategoriaTransacaoFormInsertDto dto)
        {
            var id = _service.Add(dto);
            var result = new { id = id, nome = dto.Nome };
            return CreatedAtAction(nameof(Consultar), new { id = id }, result);
        }
        
        [HttpPost("cadastro-rapido")]
        public IActionResult CadastroRapido([FromBody] CategoriaTransacaoCadastroRapidoFormInsertDto dto)
        {
            var categoriaTransacaoCadastroRapidoDto = _service.CadastroRapido(dto);
            return CreatedAtAction(nameof(Consultar), new { id = categoriaTransacaoCadastroRapidoDto.IdCategoria }, categoriaTransacaoCadastroRapidoDto);
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

    }
}

