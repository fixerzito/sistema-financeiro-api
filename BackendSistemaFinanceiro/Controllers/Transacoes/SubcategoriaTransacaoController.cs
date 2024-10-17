using BackendSistemaFinanceiro.Database;
using BackendSistemaFinanceiro.Entidades.Transacoes;
using BackendSistemaFinanceiro.ViewModels.Transacoes;
using Microsoft.AspNetCore.Mvc;

namespace BackendSistemaFinanceiro.Controllers.Transacoes
{
    [ApiController]
    [Route("subcategorias-transacao")]
    public class SubcategoriaTransacaoController : Controller
    {
        private readonly SistemaFinanceiroContext _contexto;

        public SubcategoriaTransacaoController(SistemaFinanceiroContext contexto)
        {
            _contexto = contexto;
        }
            
        [HttpGet]
        public IActionResult Consultar()
        {
            var subcategorias = _contexto.SubcategoriaTransacao.ToList();

            var subcategoriasViewModel = new List<SubcategoriaTransacaoViewModel>();

            foreach(var subcategoria in subcategorias)
            {
                var subcategoriaViewModel = new SubcategoriaTransacaoViewModel
                {
                    Id = subcategoria.Id,
                    Nome = subcategoria.Nome,
                    Categoria = subcategoria.Categoria
                };

                subcategoriasViewModel.Add(subcategoriaViewModel);
            }

            return Ok(subcategoriasViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            var subcategoriaBuscada = _contexto.SubcategoriaTransacao.Find(id);
            if(subcategoriaBuscada is null)
            {
                return NotFound();
            }

            return Ok(subcategoriaBuscada);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var subcategoriaApagada = _contexto.SubcategoriaTransacao.Find(id);
            if(subcategoriaApagada == null)
            {
                return NotFound();
            }

            _contexto.SubcategoriaTransacao.Remove(subcategoriaApagada);
            _contexto.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]SubcategoriaTransacao subcategoriaCadastrar)
        {
            if (subcategoriaCadastrar is null)
            {
                return BadRequest("Categoria inválida.");
            }

            _contexto.SubcategoriaTransacao.Add(subcategoriaCadastrar);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(Consultar), new { id = subcategoriaCadastrar.Id }, subcategoriaCadastrar);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSubcategoria([FromBody]SubcategoriaTransacao subcategoriaRecebida)
        {
            var subcategoriaEditar = _contexto.SubcategoriaTransacao.Find(subcategoriaRecebida.Id);
            if (subcategoriaEditar is null)
            {
                return NotFound();
            }

            subcategoriaEditar.Nome = subcategoriaRecebida.Nome;
            subcategoriaEditar.Categoria = subcategoriaRecebida.Categoria;

            _contexto.SaveChanges();

            return Ok(subcategoriaEditar);
        }
    }
}
