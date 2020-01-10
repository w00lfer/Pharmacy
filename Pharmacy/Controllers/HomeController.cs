using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() => await Task.Run(() => View());
    }
}
