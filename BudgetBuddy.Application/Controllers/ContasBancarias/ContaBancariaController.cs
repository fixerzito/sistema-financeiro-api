using BudgetBuddy.Application.ViewModels.ContasBancarias;
using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.ContasBancarias
{
    [ApiController]
    [Route("/contas")]
    public class ContaBancariaController : Controller
    {
        private readonly BudgetBuddyContext _contexto;

        public ContaBancariaController(BudgetBuddyContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]

        public IActionResult Consultar()
        {
            var contasBancarias = _contexto.ContaBancaria.ToList();
            var contasBancariasViewModel = new List<ContaBancariaViewModel>();

            foreach (var contaBancaria in contasBancarias)
            {
                var contaBancariaViewModel = new ContaBancariaViewModel
                {
                    Id = contaBancaria.Id,
                    Nome = contaBancaria.Nome,
                    Saldo = contaBancaria.Saldo,
                    Icon = contaBancaria.Icon,
                    IdCategoria = contaBancaria.IdCategoria
                };

                contasBancariasViewModel.Add(contaBancariaViewModel);
            }

            return Ok(contasBancariasViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var contaBancariasBuscada = _contexto.ContaBancaria.Find(id);
            if (contaBancariasBuscada == null) return BadRequest();

            return Ok(contaBancariasBuscada);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] ContaBancaria contabancaria)
        {
            if (contabancaria is null) return BadRequest();

            _contexto.ContaBancaria.Add(contabancaria);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(Consultar), new { id = contabancaria.Id }, contabancaria);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var contaBancariaApagar = _contexto.ContaBancaria.Find(id);
            if (contaBancariaApagar is null) return NotFound();

            _contexto.ContaBancaria.Remove(contaBancariaApagar);
            _contexto.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] ContaBancaria contaBancariaRecebida)
        {
            var contaBancariaParaEditar = _contexto.ContaBancaria.Find(contaBancariaRecebida.Id);
            if (contaBancariaParaEditar is null)
            {
                return BadRequest();
            }

            contaBancariaParaEditar.Nome = contaBancariaRecebida.Nome;
            contaBancariaParaEditar.Saldo = contaBancariaRecebida.Saldo;
            contaBancariaParaEditar.Icon = contaBancariaRecebida.Icon;
            contaBancariaParaEditar.IdCategoria = contaBancariaRecebida.IdCategoria;
            _contexto.SaveChanges();

            return Ok(contaBancariaParaEditar);
        }

    }
}
