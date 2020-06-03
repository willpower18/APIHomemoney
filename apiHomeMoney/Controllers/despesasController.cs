using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiHomeMoney.Models;
using apiHomeMoney.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiHomeMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class despesasController : ControllerBase
    {
        private readonly HomeService _context;

        public despesasController(HomeService context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Despesas>> Index(string Mes) =>
            _context.GetDespesas(Mes);

        [HttpPost]
        public ActionResult<Despesas> Index(Despesas despesa)
        {
            _context.CreateDespesa(despesa);

            return despesa;
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Despesa = _context.GetDespesa(id);

            if (Despesa == null)
            {
                return NotFound();
            }

            _context.RemoveDespesa(Despesa.Id);

            return StatusCode(200);
        }
    }
}