using Indigo.Helpers;
using Indigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Indigo.Areas.Manage.Controllers;
[Area("Manage")]
public class PostController : Controller
{
    private readonly IndigoContext _indigoContext;
    public IWebHostEnvironment _Env { get; }

    public PostController(IndigoContext _indigoContext, IWebHostEnvironment env)
    {
        this._indigoContext = _indigoContext;
        _Env = env;
    }
    public IActionResult Index()
    {
        List<Post> posts = _indigoContext.Posts.ToList();
        return View(posts);
    }
    public IActionResult Create(Post post)
    {

        if (post.ImageFile is null)
        {
            ModelState.AddModelError("ImageFile", "do it again");
            return View();
        }
        if (post.ImageFile.ContentType != "image/png" && post.ImageFile.ContentType != "image/jpeg")
        {
            ModelState.AddModelError("ImageFile", "you can only upload png and jpeg files");
            return View();
        }
        if (post.ImageFile.Length > 2097152)
        {
            ModelState.AddModelError("ImageFile", "you can only upload image size lower than 2 mb");
            return View();
        }


        post.ImageUrl = FileManager.SaveFile(_Env.WebRootPath, "uploads/posts", post.ImageFile);


        if (!ModelState.IsValid) return View();

        _indigoContext.Posts.Add(post);
        _indigoContext.SaveChanges();
        return RedirectToAction("index");
    }

    public IActionResult Delete(int id)
    {

        _indigoContext.Posts.Remove(_indigoContext.Posts.Find(id));
        _indigoContext.SaveChanges();


        return RedirectToAction("Index");
    }



    [HttpGet]
    public IActionResult Update(int id)
    {
        Post post = _indigoContext.Posts.Find(id);
        if (post is null) return NotFound();
        return View(post);
    }


    [HttpPost]
    public IActionResult Update(Post post)
    {
        Post ExistPost = _indigoContext.Posts.Find(post.Id);
        if (ExistPost is null) return NotFound();



        if (post.ImageFile != null)
        {
            if (post.ImageFile.ContentType != "image/png" && post.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "you can only upload png and jpeg files");
                return View();
            }
            if (post.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "you can only upload image size lower than 2 mb");
                return View();
            }
            FileManager.SaveFile(_Env.WebRootPath, "uploads/posts", post.ImageFile);
            string deletePath = Path.Combine(_Env.WebRootPath, "uploads/posts", post.ImageUrl);

            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }

            ExistPost.ImageUrl = FileManager.SaveFile(_Env.WebRootPath, "uploads/posts", post.ImageFile);
        }


        ExistPost.Title = post.Title;
        ExistPost.Desc = post.Desc;
        ExistPost.Button = post.Button;
        if (!ModelState.IsValid) return View();

        _indigoContext.SaveChanges();
        return RedirectToAction("index");
    }





}
