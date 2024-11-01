using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class HoaDonBan
    {
        public HoaDonBan()
        {
            ChiTietHoaDonBans = new HashSet<ChiTietHoaDonBan>();
        }

        public string MaHoaDonBan { get; set; } = null!;
        public DateTime? NgayBan { get; set; }
        public decimal? TongTien { get; set; }
        public string? MaNguoiDung { get; set; }

        public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
    }
}
