using Microsoft.AspNetCore.Mvc;
using TrabajadoresFinish.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajadoresFinish.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly DataContext _context;

        public TrabajadoresController(DataContext dataContext)
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

