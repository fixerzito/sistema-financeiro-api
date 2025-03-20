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

        public async Task<int> AddAsync(string userId, CartaoCreditoFormInsertDto dto)
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
                // Aqui você pode adicionar a lógica de atribuição do userId se necessário
            };
            await _repositorio.AddAsync(userId, cartao);
            return cartao.Id;
        }

        public async Task DeleteAsync(string userId, int id)
        {
            var cartao = await _repositorio.GetByIdAsync(userId, id);
            if (cartao is null)
                throw new Exception("Cartão de crédito não encontrado");

            cartao.RegistroAtivo = false;
            await _repositorio.DeleteAsync(userId, cartao);
        }

        public async Task<List<CartaoCreditoTableDto>> GetAllAsync(string userId)
        {
            var cartoes = await _repositorio.GetAllAsync(userId);
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

        public async Task<CartaoCreditoFormUpdateDto?> GetByIdAsync(string userId, int id)
        {
            var cartao = await _repositorio.GetByIdAsync(userId, id);
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

        public async Task UpdateAsync(string userId, CartaoCreditoFormUpdateDto dto)
        {
            var cartao = await _repositorio.GetByIdAsync(userId, dto.Id);
            if (cartao is null)
                throw new Exception("Conta bancária não encontrada");

            cartao.Nome = dto.Nome;
            cartao.DigBandeira = dto.DigBandeira;
            cartao.Saldo = dto.Saldo;
            cartao.Limite = dto.Limite;
            cartao.DiaFechamento = dto.DiaFechamento;
            cartao.DiaVencimento = dto.DiaVencimento;
            cartao.IdContaVinculada = dto.IdContaVinculada;

            await _repositorio.UpdateAsync(userId, cartao);
        }
    }
}
