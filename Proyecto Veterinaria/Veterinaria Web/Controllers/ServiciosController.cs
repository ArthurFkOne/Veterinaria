using Microsoft.AspNetCore.Mvc;

namespace Veterinaria_Web.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
