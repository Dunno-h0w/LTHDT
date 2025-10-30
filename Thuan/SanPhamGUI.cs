using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public  class SanPhamGUI
    {
        private SanPhamBLL spBLL;
        public void Doc_file()
        {
            try
            {
                spBLL = new SanPhamBLL();
                Console.WriteLine("Đọc file sản phẩm thành công");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đọc file: " + ex.Message);
            }
        }
        public void showSanPhams()
        {
            if (spBLL != null)
            {
                List<SanPhamDTO> sps = spBLL.GetSanPhamDTOs();
                foreach (SanPhamDTO sp in sps)
                    Console.WriteLine(sp);
            }
            else Console.WriteLine("Danh sách sản phẩm rỗng");
        }
        public void ThemSanPham()
        {
            Console.WriteLine("===== NHẬP THÔNG TIN SẢN PHẨM MỚI =====");
            string loai;
            while (true)
            {
                Console.Write("Nhập loại sản phẩm (Trang điểm / Chống nắng / Chăm sóc da): ");
                loai = Console.ReadLine();
                string loaiLower = loai.ToLower();
                if (loaiLower == "trang điểm" || loaiLower == "chong nang" || loaiLower == "chăm sóc da" || loaiLower == "cham soc da")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Loại sản phẩm không hợp lệ! Vui lòng nhập lại.\n");
                }
            }
            Console.Write("Nhập mã sản phẩm: ");
            string ma = Console.ReadLine();
            Console.Write("Nhập tên sản phẩm: ");
            string ten = Console.ReadLine();
            Console.Write("Nhập trọng lượng (kg): ");
            double trongLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhập giá bán (VNĐ): ");
            double giaBan = double.Parse(Console.ReadLine());
            Console.Write("Nhập nơi xuất xứ: ");
            string xuatXu = Console.ReadLine();
            Console.Write("Nhập ngày sản xuất (dd/MM/yyyy): ");
            DateTime ngaySanXuat = DateTime.Parse(Console.ReadLine());
            SanPhamDTO sp = null;
            if (loai == "Trang điểm")
            {
                sp = new TrangDiemDTO(ma, ten, trongLuong, giaBan, xuatXu, ngaySanXuat);
            }
            else if (loai == "Chăm sóc da")
            {
                sp = new ChamSocDaDTO(ma, ten, trongLuong, giaBan, xuatXu, ngaySanXuat);
            }
            else
            {
                sp = new ChongNangDTO(ma, ten, trongLuong, giaBan, xuatXu, ngaySanXuat);
            }
            bool themThanhCong = spBLL.ThemSanPham(sp);
            if (themThanhCong)
                Console.WriteLine("Đã thêm sản phẩm mới thành công!");
            else Console.WriteLine("Thêm thất bại mã sản phẩm đã tồn tại!");

        }


    }
}