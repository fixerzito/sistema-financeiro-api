using BudgetBuddy.Domain.Dtos.CartoesCredito.Forms;
using BudgetBuddy.Domain.Dtos.CartoesCredito.Tables;
using BudgetBuddy.Domain.Entities.CreditCards;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.CartoesCredito;

namespace BudgetBuddy.Service.Services.CartoesCredito
{
    public class CartaoCreditoService : ICartaoCreditoService
    {
        private readonly ICartaoCreditoRepositorio _repositorio;

        public CartaoCreditoService(ICartaoCreditoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public int Add(CartaoCreditoFormInsertDto dto)
        {
            var cartao = new CartaoCredito
            {
                Nome = dto.Nome,
                DigBandeira = dto.DigBandeira,
                Saldo = dto.Saldo,
                Limite = dto.Limite,
                DiaFechamento = dto.DiaFechamento,
                DiaVencimento = dto.DiaVencimento,
                IdContaVinculada = dto.IdContaVinculada,
            };
            _repositorio.Add(cartao);
            return cartao.Id;
        }

        public void Delete(int id)
        {
            var cartao = _repositorio.GetById(id);
            if (cartao is null)
                throw new Exception("Cartão de crédito não encontrado");

            cartao.RegistroAtivo = false;
            _repositorio.Delete(cartao);
        }

        public List<CartaoCreditoTableDto> GetAll()
        {
            var cartoes = _repositorio.GetAll();
            var dtos = new List<CartaoCreditoTableDto>();

            foreach (var cartao in cartoes)
            {
                var dto = new CartaoCreditoTableDto
                {
                    Id = cartao.Id,
                    Nome = cartao.Nome,
                    DigBandeira = cartao.DigBandeira,
                    Saldo = cartao.Saldo,
                    Limite = cartao.Limite,
                    DiaFechamento = cartao.DiaFechamento,
                    DiaVencimento = cartao.DiaVencimento,
                    ContaVinculada = cartao.ContaBancaria?.Nome,
                };

                dtos.Add(dto);
            }
            return dtos;
        }

        public CartaoCreditoFormUpdateDto? GetById(int id)
        {
            var cartao = _repositorio.GetById(id);
            if (cartao is null)
                return null;

            return new CartaoCreditoFormUpdateDto
            {
                Id = cartao.Id,
                Nome = cartao.Nome,
                DigBandeira = cartao.DigBandeira,
                Saldo = cartao.Saldo,
                Limite = cartao.Limite,
                DiaFechamento = cartao.DiaFechamento,
                DiaVencimento = cartao.DiaVencimento,
                IdContaVinculada = cartao.IdContaVinculada,
            };
        }

        public void Update(CartaoCreditoFormUpdateDto dto)
        {
            var cartao = _repositorio.GetById(dto.Id);
            if (cartao is null)
                throw new Exception("Conta bancária não encontrada");


            cartao.Id = dto.Id;
            cartao.Nome = dto.Nome;
            cartao.DigBandeira = dto.DigBandeira;
            cartao.Saldo = dto.Saldo;
            cartao.Limite = dto.Limite;
            cartao.DiaFechamento = dto.DiaFechamento;
            cartao.DiaVencimento = dto.DiaVencimento;
            cartao.IdContaVinculada = dto.IdContaVinculada;

            _repositorio.Update(cartao);
        }
    }
}
