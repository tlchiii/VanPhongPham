using Microsoft.AspNetCore.Mvc;
using VanPhongPham.Models;

namespace VanPhongPham.Controllers
{
    public class ProductController : Controller
    {
        QLVanPhongPhamContext db = new QLVanPhongPhamContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }

       
        
    }
}
