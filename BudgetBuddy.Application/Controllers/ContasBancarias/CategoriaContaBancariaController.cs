using BudgetBuddy.Application.ViewModels.ContasBancarias;
using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Repositories.ContasBancarias;
using Microsoft.AspNetCore.Mvc;

namespace BudgetBuddy.Application.Controllers.ContasBancarias
{
    [ApiController]
    [Route("/categorias-contas-bancarias")]
    public class CategoriaContaBancariaController : Controller
    {
        private readonly IBankAccountCategoryRepository _repository;

        public CategoriaContaBancariaController(BudgetBuddyContext contexto)
        {
            _repository = new BankAccountCategoryRepository(contexto);
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            var categorias = _repository.GetAll();
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
            var categoriaBuscada =_repository.GetById(id);

            if (categoriaBuscada is null)
            {
                return NotFound();
            }

            return Ok(categoriaBuscada);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CategoriaContaBancaria categoriaContaBancaria)
        {
            if (categoriaContaBancaria is null) return BadRequest();

            categoriaContaBancaria = _repository.Add(categoriaContaBancaria);

            return CreatedAtAction(nameof(Consultar), new { id = categoriaContaBancaria.Id }, categoriaContaBancaria);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id)
        {
            var categoriaApagar = _repository.GetById(id);
            if (categoriaApagar is null) return NotFound();

            _repository.Delete(categoriaApagar);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] CategoriaContaBancaria categoriaRecebida)
        {
            var categoriaParaEditar = _repository.GetById(categoriaRecebida.Id);
            if (categoriaParaEditar is null)
            {
                return BadRequest();
            }

            categoriaParaEditar.Nome = categoriaRecebida.Nome;
            _repository.Update(categoriaParaEditar);

            return Ok(categoriaParaEditar);
        }

    }
}
