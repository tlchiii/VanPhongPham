using VanPhongPham.Models;

namespace VanPhongPham.Service
{
    public interface ILoaiHang
    {
        void Them(LoaiHang loaiHang);
        void Sua(LoaiHang loaiHang);
        void Xoa(LoaiHang loaiHang);
        IEnumerable<LoaiHang> GetLoaiSP();
    }
}
