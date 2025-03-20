using BudgetBuddy.Application.ViewModels.Transacoes;
using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Enums;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.Transacoes
{
    [Authorize]
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

        // Método assíncrono e com UserId no cabeçalho
        [HttpGet]
        public async Task<IActionResult> Consultar([FromHeader] string userId)
        {
            var dtos = await _service.GetAllAsync(userId);

            return Ok(dtos);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpGet]
        [Route("dropdown")]
        public async Task<IActionResult> ConsultarDropdown([FromHeader] string userId)
        {
            var dtos = await _service.GetAllDropdownAsync(userId);

            return Ok(dtos);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id, [FromHeader] string userId)
        {
            var dto = await _service.GetByIdAsync(userId, id);

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPost("despesa")]
        public async Task<IActionResult> CadastrarDespesa([FromBody] TransacaoFormInsertDto dto, [FromHeader] string userId)
        {
            var id = await _service.AddAsync(userId, dto);

            return CreatedAtAction(nameof(Consultar), new { id = id }, dto);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPost("receita")]
        public async Task<IActionResult> CadastrarReceita([FromBody] TransacaoFormInsertDto dto, [FromHeader] string userId)
        {
            var id = await _service.AddAsync(userId, dto);

            return CreatedAtAction(nameof(Consultar), new { id = id }, dto);
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPatch("{id}")]
        public async Task<IActionResult> Apagar(int id, [FromHeader] string userId)
        {
            var transacaoApagar = await _service.GetByIdAsync(userId, id);
            var variavelAlteracao = -1;
            if (transacaoApagar.TipoTransacao is TipoTransacao.Saida)
            {
                variavelAlteracao = 1;
            }
            var valorDiferenca = transacaoApagar.Valor * variavelAlteracao;

            try
            {
                await _service.DeleteAsync(userId, id);
                await _contaBancariaService.UpdateSaldoAsync(userId, transacaoApagar.IdContaBancaria, valorDiferenca);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // Método assíncrono e com UserId no cabeçalho
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id, [FromBody] TransacaoFormUpdateViewModel viewModel, [FromHeader] string userId)
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
                await _service.UpdateAsync(userId, dto);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
