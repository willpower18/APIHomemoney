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
    public class receitasController : ControllerBase
    {
        private readonly HomeService _context;

        public receitasController(HomeService context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Receitas>> Index(string Mes) =>
            _context.GetReceitas(Mes);

        [HttpPost]
        public ActionResult<Receitas> Index(Receitas receita)
        {
            _context.CreateReceita(receita);

            return receita;
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Receita = _context.GetReceita(id);

            if (Receita == null)
            {
                return NotFound();
            }

            _context.RemoveReceita(Receita.Id);

            return StatusCode(200);
        }
    }
}