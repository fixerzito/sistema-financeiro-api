﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.Domain.Entities.Transactions
{
    public class SubcategoriaTransacao : EntityBase
    {
        public string Nome { get; set; }
        public int Categoria { get; set; }
    }
}
