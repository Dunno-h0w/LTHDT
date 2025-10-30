using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public abstract class SanPhamDTO
    {
        private string maSP;
        private string tenSP;
        private double trongLuong;
        private double giaBan;
        private string xuatXu;
        private DateTime ngaySanXuat;

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public double TrongLuong { get => trongLuong; set => trongLuong = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public DateTime NgaySanXuat { get => ngaySanXuat; set => ngaySanXuat = value; }


        protected SanPhamDTO(string maSP, string tenSP, double trongLuong, double giaBan, string xuatXu, DateTime ngaySanXuat)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.trongLuong = trongLuong;
            this.giaBan = giaBan;
            this.xuatXu = xuatXu;
            this.ngaySanXuat = ngaySanXuat;
        }
        protected SanPhamDTO()
        {

        }

        public abstract double GiamGia();

        public virtual void Nhap()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Xuat()
        {
            throw new System.NotImplementedException();
        }


        //San pham co ngay san xuat tren 3 thang
        public static void InSanPhamNgaySanXuatTren3Thang(List<SanPhamDTO> danhSachSanPham)
        {
            Console.WriteLine("=== DANH SACH SAN PHAM CO NGAY SAN XUAT TREN 3 THANG ===");

            if (danhSachSanPham == null || danhSachSanPham.Count == 0)
            {
                Console.WriteLine("Khong co du lieu san pham.");
                return;
            }

            DateTime ngayHienTai = DateTime.Now;
            List<SanPhamDTO> sanPhamTren3Thang = danhSachSanPham
                .Where(sp => (ngayHienTai - sp.NgaySanXuat).TotalDays > 90)
                .ToList();

            if (sanPhamTren3Thang.Count > 0)
            {
                foreach (SanPhamDTO sp in sanPhamTren3Thang)
                {
                    int soThang = (int)(ngayHienTai - sp.NgaySanXuat).TotalDays / 30;
                    Console.WriteLine($"Ma SP: {sp.MaSP}, Ten: {sp.TenSP}");
                    Console.WriteLine($"Ngay SX: {sp.NgaySanXuat:dd/MM/yyyy}, Da san xuat: {soThang} thang");
                    Console.WriteLine($"Gia ban: {sp.GiaBan} VND, Xuat xu: {sp.XuatXu}");
                    Console.WriteLine("---");
                }
                Console.WriteLine($"Tong cong: {sanPhamTren3Thang.Count} san pham");
            }
            else
            {
                Console.WriteLine("Khong co san pham nao co ngay san xuat tren 3 thang.");
            }
        }
    }

}