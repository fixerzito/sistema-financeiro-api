using BudgetBuddy.Application.ViewModels.Transacoes;
using BudgetBuddy.Domain.Dtos.CartoesCredito.Forms;
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
        public IActionResult Cadastrar([FromBody] TransacaoFormInsertDto dto)
        {
            var id = _service.Add(dto);

            if (dto.TipoTransacao == 2)
            {
                dto.Valor = -(dto.Valor); 
            }
            
            _contaBancariaService.UpdateSaldo(dto.IdContaBancaria, dto.Valor);

            return CreatedAtAction(nameof(Consultar), new { id = id }, dto);
        }

        [HttpPatch("{id}")]
        public IActionResult Apagar(int id)
        {
            var transacaoApagar = _service.GetById(id);
            var variavelAlteracao = -1;
            if (transacaoApagar.TipoTransacao == 2)
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
