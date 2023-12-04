using Microsoft.AspNetCore.Mvc;

namespace Veterinaria_Web.Controllers
{
    public class SobreNosotrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
