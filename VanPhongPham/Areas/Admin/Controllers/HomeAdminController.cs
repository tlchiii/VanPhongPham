using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pj_session.Models.Authentication;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using VanPhongPham.Models;

namespace VanPhongPham.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QLVanPhongPhamContext db = new QLVanPhongPhamContext();
        int pagesize = 8;

    
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("danhmucsp")]
        public  IActionResult DanhMucSanPham()
        {
            var lstSanPham = db.SanPhams.ToList();

            /*var learners = (IQueryable<Learner>)db.Learners.Include(m => m.Major);
            if (mid != null)
            {
                learners = (IQueryable<Learner>)db.Learners.Where(l => l.MajorID == mid).Include(m => m.MajorID);
            }*/

            //tính số trang
            int pageNum = (int)Math.Ceiling(lstSanPham.Count() / (float)pagesize);
            //trả số trang về view để hiển thị nav-trang
            ViewBag.pageNum = pageNum;
            //lấy dữ liệu trang đầu
            var result = lstSanPham .Take(pagesize).ToList();
            //return View(result);

            return View("DanhMucSanPham",result);
        }


        [Route("ProductFilter")]
        public IActionResult ProductFilter(string? maloai, string? tentk, int? pageindex)
        {
            //lay toan bo san pham
            var sanphams = (IQueryable<SanPham>)db.SanPhams;

            //lay so trang , neu null thi gan = 1
            int page = (int)(pageindex == null || pageindex <= 0 ? 1 : pageindex);

            //neu co ma loai thi loc theo ma loai
            if (maloai != null)
            {
                //loc
                sanphams = sanphams.Where(x => x.MaLoaiHang == maloai);
                //luu lai bang viewbang
                ViewBag.maloai = maloai;
            }

            //neu co tu khoa tim kiem theo ten
            if (tentk != null)
            {
                //tim kiem
                sanphams = sanphams.Where(x => x.TenSanPham.ToLower()
                .Contains(tentk.ToLower()));
                //luu tu khoa tim kie bang viwbag
                ViewBag.TenTK = tentk;
            }

            //tinh so trang
            int pageNum = (int)Math.Ceiling(sanphams.Count() / (float)pagesize);
            //luu lai bang viewbag
            ViewBag.pageNum = pageNum;

            //chọn dữ liệu hiên thi cho trang hien tại
            var ketqua = sanphams.Skip(pagesize * (page - 1))
                         .Take(pagesize).Include(m => m.MaLoaiHangNavigation);

            return PartialView("ProductTable", ketqua);
        }

        [Route("spByMaLoai")]
        public IActionResult spByMaLoai(string? maloai)
        {
            var sanpham = (IQueryable<SanPham>) db.SanPhams
                .Where(l => l.MaLoaiHang == maloai)
                .Include(m => m.MaLoaiHangNavigation);
            return PartialView("ProductTable", sanpham);
        }


        //create
        [Route("ThemSanPham")]
        [HttpGet]
        public IActionResult ThemSanPham()
        {
            //dùng 1 trong 2 cách để tạo SelecList gửi về VIew qua VIewBag để
            //hiển thị danh sách chuyên ngành(Major)
            //cach 1
            //var majors = new List<SelectListItem>();
            //foreach (var item in db.Majors)
            //{
            //    majors.Add(new SelectListItem
            //    {
            //        Text = item.MajorName,
            //        Value = item.MajorID.ToString()
            //    });

            //}
            //ViewBag.MajorsID = majors;
            //cach 2
            //ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs, "MaLoaiHang", "TenLoaiHang");

            return View();

        }


        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                //db.Learners.Add(learner);
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham","HomeAdmin");

            }
            //dùng 1 trong 2 cahcs tạo SelectList gửi về View để hiển thị danh sách Majors
            //ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs,"MaLoaiHang","TenLoaiHang");
            return View(sp);
        }


        //EDIT
        [Route("SuaSanPham")]
        public IActionResult SuaSanPham(string masp)
        {
            if (masp == null || db.SanPhams == null)
            {
                return NotFound();
            }

            var sanpham = db.SanPhams.Find(masp);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewBag.MaLoaiHang = new SelectList(db.LoaiHangs, "MaLoaiHang", "TenLoaiHang",sanpham.MaLoaiHang);


            return View(sanpham);
        }


        [Authentication]
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(SanPham sp)
        {
            //if ( masp != sp.MaSanPham)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {             
                    db.Update(sp);
                    db.Entry(sp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("DanhMucSanPham", "HomeAdmin");
                
               
            }

            //ViewBag.MaLoaiHang = new SelectList(db.SanPhams, "MaLoaiHang", "TenLoaiHang", sp.MaSanPham);
            return View(sp);
        }

        private bool SanPhamExists(string masp)
        {
            return (db.SanPhams?.Any(e => e.MaSanPham == masp)).GetValueOrDefault();
        }

        [Authentication]
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.ChiTietSanPhams.Where(x => x.MaSanPham == maSanPham).ToList();
            if (chiTietSanPham.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");

            }
            var anhSanPhams = db.HinhAnhSanPhams.Where(x => x.Equals(maSanPham)).ToList();
            if (anhSanPhams.Any()) db.RemoveRange(anhSanPhams);
            db.Remove(db.SanPhams.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Xóa thành công sản phẩm này";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }
    }
}
