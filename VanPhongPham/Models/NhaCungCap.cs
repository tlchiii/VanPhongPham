using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            HoaDonNhaps = new HashSet<HoaDonNhap>();
        }

        public string MaNhaCungCap { get; set; } = null!;
        public string TenNhaCungCap { get; set; } = null!;
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChiNhaCungCap { get; set; }

        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
    }
}
