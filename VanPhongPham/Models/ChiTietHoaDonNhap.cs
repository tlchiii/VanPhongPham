using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class ChiTietHoaDonNhap
    {
        public string MaHoaDonNhap { get; set; } = null!;
        public string MaSanPham { get; set; } = null!;
        public int? SoLuongNhap { get; set; }
        public decimal? GiaNhap { get; set; }
        public int? PhuongThucThanhToan { get; set; }

        public virtual HoaDonNhap MaHoaDonNhapNavigation { get; set; } = null!;
        public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
    }
}
