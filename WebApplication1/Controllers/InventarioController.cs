using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
