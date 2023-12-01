using Microsoft.AspNetCore.Mvc;

namespace Veterinaria_Web.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
