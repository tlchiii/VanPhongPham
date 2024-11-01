using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class ChiTietHoaDonBan
    {
        public string MaHoaDonBan { get; set; } = null!;
        public string MaSanPham { get; set; } = null!;
        public int? SoLuongBan { get; set; }
        public decimal? GiaBan { get; set; }
        public double? KhuyenMai { get; set; }
        public int? PhuongThucThanhToan { get; set; }

        public virtual HoaDonBan MaHoaDonBanNavigation { get; set; } = null!;
        public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
    }
}
