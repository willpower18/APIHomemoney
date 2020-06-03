using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiHomeMoney.Models;
using MongoDB.Driver;
using apiHomeMoney.Coomon;

namespace apiHomeMoney.Services
{
    public class HomeService
    {
        private readonly IMongoCollection<Receitas> _receitas;
        private readonly IMongoCollection<Despesas> _despesas;

        public HomeService(IHomeMoneyDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _receitas = database.GetCollection<Receitas>(settings.ReceitasCollectionName);
            _despesas = database.GetCollection<Despesas>(settings.DespesasCollectionName);
        }

        public List<Receitas> GetReceitas(string MesAno) {
            int Mes =  Convert.ToInt32(MesAno.Substring(0, 2));
            int Ano =  Convert.ToInt32(MesAno.Substring(3, 4));
            DateTime dtiInicio = new DateTime(Ano, Mes, 1);
            int UltimoDia = Util.getLastDay(Mes);
            if(UltimoDia == 0)
            {
                UltimoDia = 30;
            }
            DateTime dtFim = new DateTime(Ano, Mes, UltimoDia);

            List<Receitas> receitas = _receitas.Find(r => r.DtLancamento >= dtiInicio & r.DtLancamento <= dtFim).ToList();
            return receitas;
        }
            
        public Receitas GetReceita(string id) =>
           _receitas.Find<Receitas>(r => r.Id == id).FirstOrDefault();

        public Receitas CreateReceita(Receitas Receita)
        {
            _receitas.InsertOne(Receita);
            return Receita;
        }

        public void RemoveReceita(string id) =>
           _receitas.DeleteOne(r => r.Id == id);

        public List<Despesas> GetDespesas(string MesAno)
        {
            int Mes = Convert.ToInt32(MesAno.Substring(0, 2));
            int Ano = Convert.ToInt32(MesAno.Substring(3, 4));
            DateTime dtiInicio = new DateTime(Ano, Mes, 1);
            int UltimoDia = Util.getLastDay(Mes);
            if (UltimoDia == 0)
            {
                UltimoDia = 30;
            }
            DateTime dtFim = new DateTime(Ano, Mes, UltimoDia);

            List<Despesas> despesas = _despesas.Find(r => r.DtLancamento >= dtiInicio & r.DtLancamento <= dtFim).ToList();
            return despesas;
        }

        public Despesas GetDespesa(string id) =>
           _despesas.Find<Despesas>(d => d.Id == id).FirstOrDefault();

        public Despesas CreateDespesa(Despesas Despesa)
        {
            _despesas.InsertOne(Despesa);
            return Despesa;
        }

        public void RemoveDespesa(string id) =>
           _despesas.DeleteOne(r => r.Id == id);
    }
}
