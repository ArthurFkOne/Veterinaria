using Microsoft.AspNetCore.Mvc;

namespace Veterinaria_Web.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
