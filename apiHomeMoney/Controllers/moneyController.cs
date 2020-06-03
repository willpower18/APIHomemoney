using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiHomeMoney.Services;
using apiHomeMoney.Models;
using apiHomeMoney.Coomon;

namespace apiHomeMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class moneyController : ControllerBase
    {
        private readonly HomeService _context;

        public moneyController (HomeService context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Calculo> Index()
        {
            DateTime Hoje = Util.BrasilDate();
            string dataReq = Hoje.ToString("MM/yyyy");
            List<Receitas> receitas = _context.GetReceitas(dataReq);
            List<Despesas> despesas = _context.GetDespesas(dataReq);
            decimal TotalReceitas = receitas.Sum(r => r.Valor);
            decimal TotalDespesas = despesas.Sum(r => r.Valor);
            decimal Saldo = TotalReceitas - TotalDespesas;
            Calculo calculo = new Calculo
            {
                Referencia = dataReq,
                TotalReceitas = TotalReceitas.ToString("C"),
                TotalDespesas = TotalDespesas.ToString("C"),
                Saldo = Saldo.ToString("C")
            };

            return calculo;
        }
    }
}