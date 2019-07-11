using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
