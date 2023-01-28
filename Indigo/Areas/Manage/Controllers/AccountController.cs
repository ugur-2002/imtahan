using Microsoft.AspNetCore.Mvc;

namespace Indigo.Areas.Manage.Controllers
{
    public class AcountController : Controller
    {
        [Area("manage")]
        public IActionResult Login()
        {
            return View();
        }
    }
}



