using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class LoaiHang
    {
        public LoaiHang()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string MaLoaiHang { get; set; } = null!;
        public string? TenLoaiHang { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
