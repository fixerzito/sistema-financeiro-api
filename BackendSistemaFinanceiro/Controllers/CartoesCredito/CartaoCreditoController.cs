using BackendSistemaFinanceiro.Database;
using BackendSistemaFinanceiro.Entidades.CartoesCredito;
using BackendSistemaFinanceiro.ViewModels.CartoesCredito;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendSistemaFinanceiro.Controllers.CartoesCredito
{
    [ApiController]
    [Route("cartoes")]
    public class CartaoCreditoController : Controller
    {
        private readonly SistemaFinanceiroContext _contexto;

        public CartaoCreditoController(SistemaFinanceiroContext contexto)
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
            var cartaoCreditoParaEditar = _contexto.CartaoCredito.Find(cartaoCreditoRecebido.Id);
            if (cartaoCreditoParaEditar is null)
            {
                return BadRequest();
            }

            cartaoCreditoParaEditar.Id = cartaoCreditoRecebido.Id;
            cartaoCreditoParaEditar.Nome = cartaoCreditoRecebido.Nome;
            cartaoCreditoParaEditar.DigBandeira = cartaoCreditoRecebido.DigBandeira;
            cartaoCreditoParaEditar.Saldo = cartaoCreditoRecebido.Saldo;
            cartaoCreditoParaEditar.Limite = cartaoCreditoRecebido.Limite;
            cartaoCreditoParaEditar.DiaFechamento = cartaoCreditoRecebido.DiaFechamento;
            cartaoCreditoParaEditar.DiaVencimento = cartaoCreditoRecebido.DiaVencimento;
            cartaoCreditoParaEditar.IdContaVinculada = cartaoCreditoRecebido.IdContaVinculada;
            _contexto.SaveChanges();

            return Ok(cartaoCreditoParaEditar);
        }
    }
}
