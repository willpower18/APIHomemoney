using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiHomeMoney.Models
{
    public class Busca
    {
        public string TotalReceitas { get; set; }
        public string TotalDespesas { get; set; }
        public string Saldo { get; set; }
        public List<Receitas> Receitas { get; set; }
        public List<Despesas> Despesas { get; set; }
    }
}
