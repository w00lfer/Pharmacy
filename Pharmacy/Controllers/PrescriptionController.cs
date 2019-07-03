using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Controllers
{
    public class PrescriptionController : Controller
    {
        public IActionResult Index() => View();
    }
}