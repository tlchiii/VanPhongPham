using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            HoaDonBans = new HashSet<HoaDonBan>();
        }

        public string MaNguoiDung { get; set; } = null!;
        public string? TenNguoiDung { get; set; }
        public string TaiKhoan { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? AnhDaiDien { get; set; }
        public int? LoaiNguoiDung { get; set; }

        public virtual ICollection<HoaDonBan> HoaDonBans { get; set; }
    }
}
