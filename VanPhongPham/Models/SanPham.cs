using System;
using System.Collections.Generic;

namespace VanPhongPham.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDonBans = new HashSet<ChiTietHoaDonBan>();
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
            HinhAnhSanPhams = new HashSet<HinhAnhSanPham>();
        }

        public string MaSanPham { get; set; } = null!;
        public string? TenSanPham { get; set; }
        public decimal? GiaToiThieu { get; set; }
        public decimal? GiaToiDa { get; set; }
        public int? SoLuongTon { get; set; }
        public string? HinhAnhSanPham { get; set; }
        public string? ChiTiet { get; set; }
        public string MaLoaiHang { get; set; } = null!;

        public virtual LoaiHang MaLoaiHangNavigation { get; set; } = null!;
        public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual ICollection<HinhAnhSanPham> HinhAnhSanPhams { get; set; }
    }
}
