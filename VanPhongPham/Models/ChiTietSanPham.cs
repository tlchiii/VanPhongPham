using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class ChiTietSanPham
    {
        public string MaChiTietSanPham { get; set; } = null!;
        public string? MaSanPham { get; set; }
        public string? MaMauSac { get; set; }
        public string? AnhDaiDien { get; set; }
        public string? Video { get; set; }
        public double? DonGiaBan { get; set; }
        public double? GiamGia { get; set; }
        public int? SoLuongTon { get; set; }

        public virtual SanPham? MaSanPhamNavigation { get; set; }
    }
}
