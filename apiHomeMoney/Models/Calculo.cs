using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiHomeMoney.Models
{
    public class Calculo
    {
        public string Referencia { get; set; }
        public string TotalReceitas { get; set; }
        public string TotalDespesas { get; set; }
        public string Saldo { get; set; }
    }
}
