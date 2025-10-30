using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class KhachHangDTO
    {
        private string maKH;
        private string tenKH;
        private string soDT;
        List<SanPhamDTO> dssp;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public List<SanPhamDTO> Dssp { get => dssp; set => dssp = value; }
        public KhachHangDTO()
        {
            Dssp = new List<SanPhamDTO>();
        }

        public KhachHangDTO(string maKH, string tenKH, string soDT, List<SanPhamDTO> dssp)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soDT = soDT;
            this.dssp = dssp;
        }


        //Khach hang mua nhieu san pham (>3)
        public static void InKhachHangMuaNhieuSanPham(List<KhachHangDTO> danhSachKhachHang)
        {
            Console.WriteLine("=== DANH SACH KHACH HANG MUA NHIEU HON 3 SAN PHAM ===");

            List<KhachHangDTO> khachHangNhieuSanPham = danhSachKhachHang
                .Where(kh => kh.Dssp != null && kh.Dssp.Count > 3)
                .ToList();

            if (khachHangNhieuSanPham.Count > 0)
            {
                foreach (KhachHangDTO kh in khachHangNhieuSanPham)
                {
                    Console.WriteLine($"Ma KH: {kh.MaKH}, Ten: {kh.TenKH}, So DT: {kh.SoDT}");
                    Console.WriteLine($"So san pham da mua: {kh.Dssp.Count}");
                    Console.WriteLine("Cac san pham da mua:");
                    foreach (SanPhamDTO sp in kh.Dssp)
                    {
                        Console.WriteLine($"  - {sp.TenSP} ({sp.GiaBan} VND)");
                    }
                    Console.WriteLine("---");
                }
            }
            else
            {
                Console.WriteLine("Khong co khach hang nao mua nhieu hon 3 san pham.");
            }
        }

        //Khach hang mua nhieu tien nhat
        public static void InKhachHangMuaNhieuTienNhat(List<KhachHangDTO> danhSachKhachHang)
        {
            Console.WriteLine("=== THONG TIN KHACH HANG MUA NHIEU TIEN NHAT ===");

            if (danhSachKhachHang == null || danhSachKhachHang.Count == 0)
            {
                Console.WriteLine("Khong co du lieu khach hang.");
                return;
            }

            KhachHangDTO khachHangNhieuTienNhat = null;
            double tongTienCaoNhat = 0;

            foreach (KhachHangDTO kh in danhSachKhachHang)
            {
                double tongTien = 0;

                if (kh.Dssp != null)
                {
                    foreach (SanPhamDTO sp in kh.Dssp)
                    {
                        tongTien += sp.GiaBan;
                    }
                }

                if (tongTien > tongTienCaoNhat)
                {
                    tongTienCaoNhat = tongTien;
                    khachHangNhieuTienNhat = kh;
                }
            }

            if (khachHangNhieuTienNhat != null && tongTienCaoNhat > 0)
            {
                Console.WriteLine($"Ma KH: {khachHangNhieuTienNhat.MaKH}");
                Console.WriteLine($"Ten KH: {khachHangNhieuTienNhat.TenKH}");
                Console.WriteLine($"So DT: {khachHangNhieuTienNhat.SoDT}");
                Console.WriteLine($"Tong so san pham da mua: {khachHangNhieuTienNhat.Dssp.Count}");
                Console.WriteLine($"Tong so tien da mua: {tongTienCaoNhat} VND");
            }
            else
            {
                Console.WriteLine("Khong co khach hang nao mua hang.");
            }
        }
    }
}