using Microsoft.AspNetCore.Mvc;
using VanPhongPham.Models;

namespace VanPhongPham.Controllers
{
    public class AccessController : Controller
    {
        QLVanPhongPhamContext dbb = new QLVanPhongPhamContext();
        [HttpGet]

        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("TaiKhoan") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(NguoiDung user) 
        {
            if(HttpContext.Session.GetString("TaiKhoan") == null)
            {
                //var u = dbb.NguoiDungs.Where(x => x.TaiKhoan.Equals(user.TaiKhoan) && x.MatKhau.Equals(user.MatKhau)).FirstOrDefault();
                var u = dbb.NguoiDungs.Where(x => x.TaiKhoan.Equals(user.TaiKhoan) && x.MatKhau.Equals(user.MatKhau)).FirstOrDefault();
                if (u != null)
                {
                    //if (u.LoaiNguoiDung == 1)
                    //{
                    //    HttpContext.Session.SetString("TaiKhoan", u.TaiKhoan.ToString());
                      

                    //    string url = Url.Content("/admin/");
                    //    return RedirectToAction("Cart", "Home");
                    //    //return Redirect(url);
                    //}
                    //if (u.LoaiNguoiDung == 2)
                    //{

                    //    HttpContext.Session.SetString("TaiKhoan", u.TaiKhoan.ToString());
                    //    return RedirectToAction("Index", "Home");
                    //}

                    HttpContext.Session.SetString("TaiKhoan", u.TaiKhoan.ToString());
                    return RedirectToAction("Index", "Home");
                }

                
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("TaiKhoan");
            //return RedirectToAction("Login", "Access");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
