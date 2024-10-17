using BackendSistemaFinanceiro.Database;
using BackendSistemaFinanceiro.Entidades.ContasBancarias;
using BackendSistemaFinanceiro.ViewModels.ContasBancarias;
using Microsoft.AspNetCore.Mvc;

namespace BackendSistemaFinanceiro.Controllers.ContasBancarias
{
    [ApiController]
    [Route("/categorias-contas-bancarias")]
    public class CategoriaContaBancariaController : Controller
    {
        public readonly SistemaFinanceiroContext _contexto;

        public CategoriaContaBancariaController(SistemaFinanceiroContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var categorias = _contexto.CategoriaContaBancaria.ToList();
            var categoriasViewModel = new List<CategoriaContaBancariaViewModel>();

            foreach (var categoria in categorias)
            {
                var categoriaViewModel = new CategoriaContaBancariaViewModel
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };

                categoriasViewModel.Add(categoriaViewModel);
            }

            return Ok(categoriasViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var categoriaBuscada = _contexto.CategoriaContaBancaria.Find(id);

            if(categoriaBuscada is null)
            {
                return BadRequest();
            }

            return Ok(categoriaBuscada);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CategoriaContaBancaria categoriaContabancaria)
        {
            if (categoriaContabancaria is null) return BadRequest();

            _contexto.CategoriaContaBancaria.Add(categoriaContabancaria);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(Consultar), new { id = categoriaContabancaria.Id }, categoriaContabancaria);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var categoriaApagar = _contexto.CategoriaContaBancaria.Find(id);
            if(categoriaApagar is null) return NotFound();

            _contexto.CategoriaContaBancaria.Remove(categoriaApagar);
            _contexto.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] CategoriaContaBancaria categoriaRecebida)
        {
            var categoriaParaEditar = _contexto.CategoriaContaBancaria.Find(categoriaRecebida.Id);
            if (categoriaParaEditar is null)
            {
                return BadRequest();
            }

            categoriaParaEditar.Nome = categoriaRecebida.Nome;
            _contexto.SaveChanges();

            return Ok(categoriaParaEditar);
        }

    }
}
