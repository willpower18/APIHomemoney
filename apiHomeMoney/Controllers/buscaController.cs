using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiHomeMoney.Coomon;
using apiHomeMoney.Models;
using apiHomeMoney.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiHomeMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class buscaController : ControllerBase
    {
        private readonly HomeService _context;

        public buscaController(HomeService context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Busca> Index(string Mes)
        {
            if (string.IsNullOrEmpty(Mes))
            {
                DateTime Hoje = Util.BrasilDate();
                Mes = Hoje.ToString("MM/yyyy");
            }
            List<Receitas> receitas = _context.GetReceitas(Mes);
            List<Despesas> despesas = _context.GetDespesas(Mes);
            decimal TotalReceitas = receitas.Sum(r => r.Valor);
            decimal TotalDespesas = despesas.Sum(r => r.Valor);
            decimal Saldo = TotalReceitas - TotalDespesas;
            Busca busca = new Busca
            {
                TotalReceitas = TotalReceitas.ToString("C"),
                TotalDespesas = TotalDespesas.ToString("C"),
                Saldo = Saldo.ToString("C"),
                Receitas = receitas,
                Despesas = despesas
            };

            return busca;
        }
    }
}