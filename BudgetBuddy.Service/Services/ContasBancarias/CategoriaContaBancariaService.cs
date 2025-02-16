﻿using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Tables;
using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;

namespace BudgetBuddy.Service.Services.ContasBancarias
{
    public class CategoriaContaBancariaService : ICategoriaContaBancariaService
    {
        private readonly ICategoriaContaBancariaRepositorio _repository;

        public CategoriaContaBancariaService(ICategoriaContaBancariaRepositorio repository)
        {
            _repository = repository;
        }

        public int Add(CategoriaContaBancariaFormInsertDto dto)
        {
            var categoria = new CategoriaContaBancaria
            {
                Nome = dto.Nome,
            };
            _repository.Add(categoria);
            return categoria.Id;
        }

        public void Delete(int id)
        {
            var categoria = _repository.GetById(id);
            if (categoria is null)
                throw new Exception("Categoria não encontrada");

            categoria.RegistroAtivo = false;
            _repository.Delete(categoria);
        }

        public List<CategoriaContaBancariaTableDto> GetAll()
        {
            var categorias = _repository.GetAll();
            var dtos = new List<CategoriaContaBancariaTableDto>();

            foreach (var categoria in categorias)
            {
                var dto = new CategoriaContaBancariaTableDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };

                dtos.Add(dto);
            }

            return dtos;
            //var quantidadeRegistros = _repository.Count();

            //return new TableDto
            //{
            //    QuantidadeRegistros = quantidadeRegistros,
            //    Dados = categorias
            //};
        }

        public CategoriaContaBancariaTableDto? GetById(int id)
        {
            var categoria = _repository.GetById(id);
            if (categoria is null)
                return null;

            return new CategoriaContaBancariaTableDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };
        }

        public void Update(CategoriaContaBancariaFormUpdateDto dto)
        {
            var categoria = _repository.GetById(dto.Id);
            if (categoria is null)
                throw new Exception("Categoria não encontrada");


            categoria.Nome = dto.Nome;

            _repository.Update(categoria);
        }
    }
}
