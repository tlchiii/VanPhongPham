using Microsoft.AspNetCore.Mvc;
using VanPhongPham.Service;

namespace VanPhongPham.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ILoaiHang _loaiSP;
        public CategoryViewComponent(ILoaiHang loaiSP)
        {
            _loaiSP = loaiSP;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var category = _loaiSP.GetLoaiSP().OrderBy(x => x.MaLoaiHang);
        //    return View("Default",category);
        //}

        public IViewComponentResult Invoke()
        {
            var category = _loaiSP.GetLoaiSP().OrderBy(x => x.MaLoaiHang);
            return View(category);
        }
    }
}
