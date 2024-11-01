using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VanPhongPham.Models;

namespace VanPhongPham.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QLVanPhongPhamContext db = new QLVanPhongPhamContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            var listSanPham = db.SanPhams.Take(5).ToList();

            return View(listSanPham);
        }

        private int pageSize = 6;
        public IActionResult Products(string? maloai)
        {
            //var listSanPham = db.SanPhams.ToList();
            var listSanPham = (IQueryable<SanPham>)db.SanPhams.Include(m => m.MaLoaiHangNavigation);
            if (maloai != null)
            {
                listSanPham = (IQueryable<SanPham>)db.SanPhams.Where(m => m.MaLoaiHang == maloai).Include(l => l.MaLoaiHangNavigation);
            }


            //tinh so trang
            int pageNum = (int)Math.Ceiling(listSanPham.Count() / (float)pageSize);
            //luu so trang bang viewbag
            ViewBag.pageNum = pageNum;
            //lay du lieu trang dau
            var page1 = listSanPham.Take(pageSize).ToList();

            return View("Products",page1);

        }

        public IActionResult ProductFilter(string? maloai, string? tentk, int? pageindex)
        {
            //lay toan bo san pham
            var sanphams = (IQueryable<SanPham>)db.SanPhams;

            //lay so trang , neu null thi gan = 1
            int page = (int)(pageindex == null || pageindex <= 0 ? 1 : pageindex);

            //neu co ma loai thi loc theo ma loai
            if(maloai != null)
            {
                //loc
                sanphams = sanphams.Where(x => x.MaLoaiHang == maloai);
                //luu lai bang viewbang
                ViewBag.maloai = maloai;
            }

            //neu co tu khoa tim kiem theo ten
            if(tentk != null)
            {
                //tim kiem
                sanphams = sanphams.Where(x => x.TenSanPham.ToLower()
                .Contains(tentk.ToLower()));
                //luu tu khoa tim kie bang viwbag
                ViewBag.TenTK = tentk;
            }

            //tinh so trang
            int pageNum = (int)Math.Ceiling(sanphams.Count() / (float)pageSize);
            //luu lai bang viewbag
            ViewBag.pageNum = pageNum;

            //chọn dữ liệu hiên thi cho trang hien tại
            var ketqua = sanphams.Skip(pageSize * (page - 1))
                         .Take(pageSize).Include(m => m.MaLoaiHangNavigation);

            return PartialView("dsSanPham", ketqua);

        }
        public IActionResult check()
        {
            //string a = "Hello";
            //return PartialView("Check", a);
            return RedirectToAction("Cart");
        }

        public IActionResult Search()
        {
            //var sanphams = (IQueryable<SanPham>)db.SanPhams;
            ////neu co tu khoa tim kiem theo ten
            //if (tentimkiem != null)
            //{
            //    //tim kiem
            //    sanphams = sanphams.Where(x => x.TenSanPham.ToLower()
            //    .Contains(tentimkiem.ToLower()));
            //    //luu tu khoa tim kie bang viwbag
            //    //ViewBag.tentimkiem = tentimkiem;
            //    //return RedirectToAction("Products", new { tentk = tentimkiem });
            //    return RedirectToAction("Cart");
            //}
            //else
            //{
            //    return View("Index");
            //}

            //return PartialView("dsSanPham");
            //return RedirectToAction("ProductFilter");

            //return View();
            return RedirectToAction("Cart");


        }

        public IActionResult ProductDetail(string masp)
        {
            var sanpham = db.SanPhams.SingleOrDefault(x => x.MaSanPham == masp);
            var anhsp = db.HinhAnhSanPhams.Where(x => x.MaSanPham == masp).ToList();

            ViewBag.AnhSP = anhsp;

            return View("ProductDetail",sanpham);
        }
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
