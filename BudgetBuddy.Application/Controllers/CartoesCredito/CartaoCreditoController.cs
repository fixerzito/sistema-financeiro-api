using BudgetBuddy.Application.ViewModels.CartoesCredito;
using BudgetBuddy.Domain.Entities.CreditCards;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Application.Controllers.CartoesCredito
{
    [ApiController]
    [Route("cartoes")]
    public class CartaoCreditoController : Controller
    {
        private readonly BudgetBuddyContext _contexto;

        public CartaoCreditoController(BudgetBuddyContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]

        public IActionResult Consultar()
        {
            var cartoesCredito = _contexto.CartaoCredito
                 .Include(c => c.ContaBancaria).ToList();

            var cartoesCreditoViewModel = new List<CartaoCreditoViewModel>();

            foreach (var cartaoCredito in cartoesCredito)
            {
                var cartaoCreditoViewModel = new CartaoCreditoViewModel
                {
                    Id = cartaoCredito.Id,
                    Nome = cartaoCredito.Nome,
                    DigBandeira = cartaoCredito.DigBandeira,
                    Saldo = cartaoCredito.Saldo,
                    Limite = cartaoCredito.Limite,
                    DiaFechamento = cartaoCredito.DiaFechamento,
                    DiaVencimento = cartaoCredito.DiaVencimento,
                    ContaVinculada = cartaoCredito.ContaBancaria?.Nome
                };

                cartoesCreditoViewModel.Add(cartaoCreditoViewModel);
            }

            return Ok(cartoesCreditoViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var cartaoCreditoBuscado = _contexto.CartaoCredito.Find(id);
            if (cartaoCreditoBuscado == null) return BadRequest();

            return Ok(cartaoCreditoBuscado);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CartaoCredito cartaoCredito)
        {
            if (cartaoCredito is null) return BadRequest();

            _contexto.CartaoCredito.Add(cartaoCredito);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(Consultar), new { id = cartaoCredito.Id }, cartaoCredito);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var cartaoCreditoApagar = _contexto.CartaoCredito.Find(id);
            if (cartaoCreditoApagar is null) return NotFound();

            _contexto.CartaoCredito.Remove(cartaoCreditoApagar);
            _contexto.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] CartaoCredito cartaoCreditoRecebido)
        {
            var cartaoCredito = _contexto.CartaoCredito.Find(cartaoCreditoRecebido.Id);
            if (cartaoCredito is null)
            {
                return BadRequest();
            }

            cartaoCredito.Nome = cartaoCreditoRecebido.Nome;
            cartaoCredito.DigBandeira = cartaoCreditoRecebido.DigBandeira;
            cartaoCredito.Saldo = cartaoCreditoRecebido.Saldo;
            cartaoCredito.Limite = cartaoCreditoRecebido.Limite;
            cartaoCredito.DiaFechamento = cartaoCreditoRecebido.DiaFechamento;
            cartaoCredito.DiaVencimento = cartaoCreditoRecebido.DiaVencimento;
            cartaoCredito.IdContaVinculada = cartaoCreditoRecebido.IdContaVinculada;
            _contexto.SaveChanges();

            return Ok(cartaoCredito);
        }
    }
}
