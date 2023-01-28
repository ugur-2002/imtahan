using Indigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Indigo.Areas.Manage.Controllers;
[Area("Manage")]
public class DashboardController : Controller
{
    private readonly IndigoContext _indigoContext;
    public DashboardController(IndigoContext _indigoContext)
    {
        this._indigoContext = _indigoContext;
    }
    public IActionResult Index()
    {
        List<Post> posts = _indigoContext.Posts.ToList();


        return View(posts);
    }
}
