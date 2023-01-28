using Indigo.HomeViewModel;
using Indigo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Indigo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IndigoContext _indigoContext;

        public HomeController(IndigoContext indigoContext)
        {
            _indigoContext = indigoContext;
        }

        public IActionResult Index()
        {
            ViewModels viewModels = new ViewModels
            {
                Posts = _indigoContext.Posts.ToList()
                
            };


            return View(viewModels);
        }
    }
}