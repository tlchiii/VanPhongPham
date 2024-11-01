using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VanPhongPham.Models
{
    public partial class QLVanPhongPhamContext : DbContext
    {
        public QLVanPhongPhamContext()
        {
        }

        public QLVanPhongPhamContext(DbContextOptions<QLVanPhongPhamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; } = null!;
        public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; } = null!;
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; } = null!;
        public virtual DbSet<HinhAnhSanPham> HinhAnhSanPhams { get; set; } = null!;
        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; } = null!;
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; } = null!;
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=QLVanPhongPham;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDonBan, e.MaSanPham });

                entity.ToTable("ChiTietHoaDonBan");

                entity.Property(e => e.MaHoaDonBan).HasMaxLength(25);

                entity.Property(e => e.MaSanPham).HasMaxLength(25);

                entity.Property(e => e.GiaBan).HasColumnType("money");

                entity.HasOne(d => d.MaHoaDonBanNavigation)
                    .WithMany(p => p.ChiTietHoaDonBans)
                    .HasForeignKey(d => d.MaHoaDonBan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonBan_HoaDonBan");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietHoaDonBans)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonBan_SanPham");
            });

            modelBuilder.Entity<ChiTietHoaDonNhap>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDonNhap, e.MaSanPham });

                entity.ToTable("ChiTietHoaDonNhap");

                entity.Property(e => e.MaHoaDonNhap).HasMaxLength(25);

                entity.Property(e => e.MaSanPham).HasMaxLength(25);

                entity.Property(e => e.GiaNhap).HasColumnType("money");

                entity.HasOne(d => d.MaHoaDonNhapNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.MaHoaDonNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonNhap_HoaDonNhap");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietHoaDonNhaps)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonNhap_SanPham");
            });

            modelBuilder.Entity<ChiTietSanPham>(entity =>
            {
                entity.HasKey(e => e.MaChiTietSanPham);

                entity.ToTable("ChiTietSanPham");

                entity.Property(e => e.MaChiTietSanPham).HasMaxLength(25);

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaMauSac)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaSanPham).HasMaxLength(25);

                entity.Property(e => e.Video)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK_ChiTietSanPham_SanPham");
            });

            modelBuilder.Entity<HinhAnhSanPham>(entity =>
            {
                entity.HasKey(e => new { e.MaSanPham, e.TenHinhAnh });

                entity.ToTable("HinhAnhSanPham");

                entity.Property(e => e.MaSanPham).HasMaxLength(25);

                entity.Property(e => e.TenHinhAnh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.HinhAnhSanPhams)
                    .HasForeignKey(d => d.MaSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HinhAnhSanPham_SanPham");
            });

            modelBuilder.Entity<HoaDonBan>(entity =>
            {
                entity.HasKey(e => e.MaHoaDonBan);

                entity.ToTable("HoaDonBan");

                entity.Property(e => e.MaHoaDonBan).HasMaxLength(25);

                entity.Property(e => e.MaNguoiDung).HasMaxLength(25);

                entity.Property(e => e.NgayBan).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.HoaDonBans)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_HoaDonBan_NguoiDung");
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaHoaDonNhap);

                entity.ToTable("HoaDonNhap");

                entity.Property(e => e.MaHoaDonNhap).HasMaxLength(25);

                entity.Property(e => e.MaNhaCungCap).HasMaxLength(25);

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .HasConstraintName("FK_HoaDonNhap_NhaCungCap");
            });

            modelBuilder.Entity<LoaiHang>(entity =>
            {
                entity.HasKey(e => e.MaLoaiHang);

                entity.ToTable("LoaiHang");

                entity.Property(e => e.MaLoaiHang).HasMaxLength(25);

                entity.Property(e => e.TenLoaiHang).HasMaxLength(100);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung);

                entity.ToTable("NguoiDung");

                entity.Property(e => e.MaNguoiDung).HasMaxLength(25);

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaiKhoan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenNguoiDung).HasMaxLength(100);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap);

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MaNhaCungCap).HasMaxLength(25);

                entity.Property(e => e.DiaChiNhaCungCap).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenNhaCungCap).HasMaxLength(100);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham);

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSanPham).HasMaxLength(25);

                entity.Property(e => e.ChiTiet).HasMaxLength(300);

                entity.Property(e => e.GiaToiDa).HasColumnType("money");

                entity.Property(e => e.GiaToiThieu).HasColumnType("money");

                entity.Property(e => e.HinhAnhSanPham)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaLoaiHang).HasMaxLength(25);

                entity.Property(e => e.TenSanPham).HasMaxLength(100);

                entity.HasOne(d => d.MaLoaiHangNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLoaiHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_LoaiHang");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
