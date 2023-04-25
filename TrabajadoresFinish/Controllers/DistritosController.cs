using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrabajadoresFinish.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajadoresFinish.Controllers
{
    public class DistritosController : Controller
    {
        // GET: /<controller>/
        private readonly DataContext _context;

        public DistritosController(DataContext dataContext)
        {
            _context = dataContext;
        }


        public IActionResult Index()
        {
            var departamentos = _context.Departamento.ToList();
            return View(departamentos);
        }
    }
}

