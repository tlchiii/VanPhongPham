using Microsoft.AspNetCore.Mvc;
using VanPhongPham.Service;

namespace VanPhongPham.ViewComponents
{
    public class LoaiHangViewComponent : ViewComponent
    {
        private readonly ILoaiHang _loaiSP;
        public LoaiHangViewComponent(ILoaiHang loaiSP)
        {
            _loaiSP = loaiSP;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaihang = _loaiSP.GetLoaiSP().OrderBy(x => x.MaLoaiHang);
            return View("Default",loaihang );
        }


    }
}
