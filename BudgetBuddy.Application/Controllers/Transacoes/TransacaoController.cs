using BudgetBuddy.Application.ViewModels.Transacoes;
using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Enums;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Transacoes
{
    [Route("api/transacoes")]
    [ApiController]
    public class TransacaoController : Controller
    {
        private readonly ITransacaoService _service;
        private readonly IContaBancariaService _contaBancariaService;

        public TransacaoController(ITransacaoService service, IContaBancariaService contaBancariaService)
        {
            _service = service;
            _contaBancariaService = contaBancariaService;
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var dtos = _service.GetAll();

            return Ok(dtos);
        }
        
        [HttpGet]
        [Route("dropdown")]
        public IActionResult ConsultarDropdown()
        {
            var dtos = _service.GetAllDropdown();

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

        [HttpPost("despesa")]
        public IActionResult CadastrarDespesa([FromBody] TransacaoFormInsertDto dto)
        {
            var id = _service.Add(dto);

            return CreatedAtAction(nameof(Consultar), new { id = id }, dto);
        }
        
        [HttpPost("receita")]
        public IActionResult CadastrarReceita([FromBody] TransacaoFormInsertDto dto)
        {
            var id = _service.Add(dto);

            return CreatedAtAction(nameof(Consultar), new { id = id }, dto);
        }

        [HttpPatch("{id}")]
        public IActionResult Apagar(int id)
        {
            var transacaoApagar = _service.GetById(id);
            var variavelAlteracao = -1;
            if (transacaoApagar.TipoTransacao is TipoTransacao.Saida)
            {
                variavelAlteracao = 1;
            }
            var valorDiferenca = transacaoApagar.Valor * variavelAlteracao;
            
            try
            {
                _service.Delete(id);
                _contaBancariaService.UpdateSaldo(transacaoApagar.IdContaBancaria, valorDiferenca);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromRoute] int id, [FromBody] TransacaoFormUpdateViewModel viewModel)
        {
            try
            {
                var dto = new TransacaoFormUpdateDto
                {
                    Id = id,
                    Status = viewModel.Status.GetValueOrDefault(),
                    DataPrevista = viewModel.DataPrevista.HasValue ? viewModel.DataPrevista.Value : null,
                    DataEfetivacao = viewModel.DataEfetivacao.HasValue ? viewModel.DataEfetivacao.Value : null,
                    IdSubcategoriaTransacao = viewModel.IdSubcategoriaTransacao.GetValueOrDefault(),
                    IdContaBancaria = viewModel.IdContaBancaria.GetValueOrDefault(),
                    TipoTransacao = (TipoTransacao)Enum.ToObject(typeof(TipoTransacao), viewModel.TipoTransacao!),
                    Valor = viewModel.Valor.GetValueOrDefault(),
                    Nome = viewModel.Nome!,
                };
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
