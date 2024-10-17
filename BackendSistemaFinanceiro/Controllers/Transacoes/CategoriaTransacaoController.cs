using BackendSistemaFinanceiro.Database;
using BackendSistemaFinanceiro.Entidades.Transacoes;
using BackendSistemaFinanceiro.ViewModels.Transacoes;
using Microsoft.AspNetCore.Mvc;

namespace BackendSistemaFinanceiro.Controllers.Transacoes
{
    [ApiController]
    [Route("/categorias-transacao")]
    public class CategoriaTransacaoController : Controller
    {
        private readonly SistemaFinanceiroContext _contexto;

        public CategoriaTransacaoController(SistemaFinanceiroContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            //recebe do contexto, buscando de categorias, todos os items da tabela
            var categorias = _contexto.CategoriaTransacao.ToList();

            //instancia uma lista de CategoriViewModel
            var categoriasViewModel = new List<CategoriaTransacaoViewModel>();

            // criaco um loop para que para cada item de 'categorias', seja atribuido um item na lista de ViewModels
            foreach (var categoria in categorias)
            {
                var categoriaViewModel = new CategoriaTransacaoViewModel
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };
                categoriasViewModel.Add(categoriaViewModel);
            }
            //retorno do da lista buscada
            return Ok(categoriasViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            // Verifica se a categoria existe no contexto
            var categoriaParaEditar = _contexto.CategoriaTransacao.Find(id);
            if (categoriaParaEditar == null)
            {
                return NotFound();
            }

            return Ok(categoriaParaEditar);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCategoria([FromBody] CategoriaTransacao categoriaRecebida)
        {
            //recebe a categoria no id
            var categoriaParaEditar = _contexto.CategoriaTransacao.Find(categoriaRecebida.Id);
            if (categoriaParaEditar == null)
            {
                return NotFound();
            }
            //atribui as novas propriedades a categoria
            categoriaParaEditar.Nome = categoriaRecebida.Nome;
            _contexto.SaveChanges();

            return Ok(categoriaParaEditar);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CategoriaTransacao categoriaCadastrar)
        {
            if (categoriaCadastrar is null)
            {
                return BadRequest("Categoria inválida.");
            }

            _contexto.CategoriaTransacao.Add(categoriaCadastrar);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(Consultar), new { id = categoriaCadastrar.Id }, categoriaCadastrar);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var categoriaApagada = _contexto.CategoriaTransacao.Find(id);
            if (categoriaApagada == null)
            {
                return NotFound();
            }

            _contexto.CategoriaTransacao.Remove(categoriaApagada);
            _contexto.SaveChanges();

            return NoContent();
        }

    }
}

