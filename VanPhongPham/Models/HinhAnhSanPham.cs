using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class HinhAnhSanPham
    {
        public string MaSanPham { get; set; } = null!;
        public string TenHinhAnh { get; set; } = null!;

        public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
    }
}
