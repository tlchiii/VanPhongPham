using VanPhongPham.Models;

namespace VanPhongPham.Service
{
    public class LoaiSP  : ILoaiHang
    {
        private QLVanPhongPhamContext _context;

        public LoaiSP(QLVanPhongPhamContext context)
        {
            _context = context;
        }
        public IEnumerable<LoaiHang> GetLoaiSP()
        {
            return _context.LoaiHangs;
        }

        public void Sua(LoaiHang loaiHang)
        {
            throw new NotImplementedException();
        }

        public void Them(LoaiHang loaiHang)
        {
            throw new NotImplementedException();
        }

        public void Xoa(LoaiHang loaiHang)
        {
            throw new NotImplementedException();
        }
    }
}
