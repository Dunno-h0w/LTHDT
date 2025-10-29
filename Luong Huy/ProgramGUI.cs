using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class ProgramGUI
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHUONG TRINH QUAN LY KHACH HANG VA SAN PHAM");
            Console.WriteLine("===========================================");

            // Tao du lieu mau de test
            List<KhachHangDTO> danhSachKhachHang = TaoDuLieuMauKhachHang();
            List<SanPhamDTO> danhSachSanPham = TaoDuLieuMauSanPham();

            // Goi cac chuc nang
            Console.WriteLine("\n1. Khach hang mua nhieu hon 3 san pham:");
            KhachHangDTO.InKhachHangMuaNhieuSanPham(danhSachKhachHang);

            Console.WriteLine("\n2. San pham co ngay san xuat tren 3 thang:");
            SanPhamDTO.InSanPhamNgaySanXuatTren3Thang(danhSachSanPham);

            Console.WriteLine("\n3. Khach hang mua nhieu tien nhat:");
            KhachHangDTO.InKhachHangMuaNhieuTienNhat(danhSachKhachHang);

            Console.WriteLine("\nNhan phim bat ky de thoat...");
            Console.ReadKey();
        }

        // Ham tao du lieu mau de test
        private static List<KhachHangDTO> TaoDuLieuMauKhachHang()
        {
            List<KhachHangDTO> ketQua = new List<KhachHangDTO>();

            // Tao san pham
            ChamSocDaDTO sanPham1 = new ChamSocDaDTO("SP001", "Kem duong am", 0.1, 150000, "Han Quoc", new DateTime(2024, 1, 15));
            TrangDiemDTO sanPham2 = new TrangDiemDTO("SP002", "Son moi", 0.05, 250000, "Phap", new DateTime(2024, 2, 20));
            ChongNangDTO sanPham3 = new ChongNangDTO("SP003", "Kem chong nang", 0.08, 180000, "My", new DateTime(2023, 12, 10));
            ChamSocDaDTO sanPham4 = new ChamSocDaDTO("SP004", "Serum", 0.03, 350000, "Nhat", new DateTime(2024, 3, 5));
            TrangDiemDTO sanPham5 = new TrangDiemDTO("SP005", "Phan", 0.12, 280000, "Han Quoc", new DateTime(2024, 1, 30));
            ChamSocDaDTO sanPham6 = new ChamSocDaDTO("SP006", "Tay te bao chet", 0.02, 120000, "Viet Nam", new DateTime(2024, 2, 10));

            // Khach hang 1: mua 5 san pham (nhieu hon 3)
            List<SanPhamDTO> danhSachSP1 = new List<SanPhamDTO>();
            danhSachSP1.Add(sanPham1);
            danhSachSP1.Add(sanPham2);
            danhSachSP1.Add(sanPham3);
            danhSachSP1.Add(sanPham4);
            danhSachSP1.Add(sanPham5);
            KhachHangDTO khachHang1 = new KhachHangDTO("KH001", "Nguyen Van A", "0912345678", danhSachSP1);

            // Khach hang 2: mua 2 san pham (it hon 3)
            List<SanPhamDTO> danhSachSP2 = new List<SanPhamDTO>();
            danhSachSP2.Add(sanPham1);
            danhSachSP2.Add(sanPham3);
            KhachHangDTO khachHang2 = new KhachHangDTO("KH002", "Tran Thi B", "0923456789", danhSachSP2);

            // Khach hang 3: mua 3 san pham (bang 3)
            List<SanPhamDTO> danhSachSP3 = new List<SanPhamDTO>();
            danhSachSP3.Add(sanPham2);
            danhSachSP3.Add(sanPham4);
            danhSachSP3.Add(sanPham5);
            KhachHangDTO khachHang3 = new KhachHangDTO("KH003", "Le Van C", "0934567890", danhSachSP3);

            // Khach hang 4: mua 6 san pham (nhieu hon 3 va nhieu tien nhat)
            List<SanPhamDTO> danhSachSP4 = new List<SanPhamDTO>();
            danhSachSP4.Add(sanPham1);
            danhSachSP4.Add(sanPham2);
            danhSachSP4.Add(sanPham3);
            danhSachSP4.Add(sanPham4);
            danhSachSP4.Add(sanPham5);
            danhSachSP4.Add(sanPham6);
            KhachHangDTO khachHang4 = new KhachHangDTO("KH004", "Pham Thi D", "0945678901", danhSachSP4);

            ketQua.Add(khachHang1);
            ketQua.Add(khachHang2);
            ketQua.Add(khachHang3);
            ketQua.Add(khachHang4);

            return ketQua;
        }

        private static List<SanPhamDTO> TaoDuLieuMauSanPham()
        {
            List<SanPhamDTO> danhSach = new List<SanPhamDTO>();

            // San pham moi (duoi 3 thang)
            danhSach.Add(new ChamSocDaDTO("SP001", "Kem duong am", 0.1, 150000, "Han Quoc", new DateTime(2024, 1, 15)));
            danhSach.Add(new TrangDiemDTO("SP002", "Son moi", 0.05, 250000, "Phap", new DateTime(2024, 2, 20)));
            danhSach.Add(new ChongNangDTO("SP007", "Xit khoang", 0.15, 200000, "My", new DateTime(2024, 3, 1)));

            // San pham cu (tren 3 thang)
            danhSach.Add(new ChongNangDTO("SP003", "Kem chong nang", 0.08, 180000, "My", new DateTime(2023, 10, 10)));
            danhSach.Add(new ChamSocDaDTO("SP004", "Serum cu", 0.03, 350000, "Nhat", new DateTime(2023, 9, 5)));
            danhSach.Add(new TrangDiemDTO("SP005", "Phan cu", 0.12, 280000, "Han Quoc", new DateTime(2023, 8, 30)));
            danhSach.Add(new ChamSocDaDTO("SP006", "Tay te bao chet", 0.02, 120000, "Viet Nam", new DateTime(2023, 7, 20)));

            return danhSach;
        }
    }
}
