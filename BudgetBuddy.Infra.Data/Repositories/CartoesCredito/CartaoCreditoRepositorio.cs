using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Entities.CreditCards;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BudgetBuddy.Infra.Data.Repositories.CartoesCredito
{
    public class CartaoCreditoRepositorio : ICartaoCreditoRepositorio
    {
        private readonly BudgetBuddyContext _context;
        private readonly DbSet<CartaoCredito> _dbSet;

        public CartaoCreditoRepositorio(BudgetBuddyContext context)
        {
            _context = context;
            _dbSet = _context.Set<CartaoCredito>();
        }
        public CartaoCredito Add(CartaoCredito cartao)
        {
            _dbSet.Add(cartao);
            _context.SaveChanges();

            return cartao;
        }

        public void Delete(CartaoCredito cartao)
        {
            _dbSet.Remove(cartao);
            _context.SaveChanges();
        }

        public List<CartaoCredito> GetAll()
        {
            return _dbSet.Include(c => c.ContaBancaria).ToList();
        }

        public CartaoCredito? GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Update(CartaoCredito cartao)
        {
            _dbSet.Update(cartao);
            _context.SaveChanges(); ;
        }
    }
}
