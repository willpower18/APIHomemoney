using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiHomeMoney.Models
{
    public class HomeMoneyDatabaseSettings : IHomeMoneyDatabaseSettings
    {
        public string ReceitasCollectionName { get; set; }
        public string DespesasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
       
    }

    public interface IHomeMoneyDatabaseSettings
    {
        string ReceitasCollectionName { get; set; }
        string DespesasCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
