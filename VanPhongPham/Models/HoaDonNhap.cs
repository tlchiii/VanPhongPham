using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class HoaDonNhap
    {
        public HoaDonNhap()
        {
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
        }

        public string MaHoaDonNhap { get; set; } = null!;
        public DateTime? NgayNhap { get; set; }
        public decimal? TongTien { get; set; }
        public string? MaNhaCungCap { get; set; }

        public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
    }
}
