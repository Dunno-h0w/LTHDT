using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    public class SanPhamGUI
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
        public void LocSPGiaHon300()
        {
            if (spBLL != null)
            {
                List<SanPhamDTO> temp = spBLL.LocGiaTren300();
                Console.WriteLine("\n------------Những sản phẩm có giá hơn 300------------");
                foreach (SanPhamDTO sp in temp) Console.WriteLine(sp);
            }
            else Console.WriteLine("Danh sách sản phẩm rỗng");
        }
        public void LocTheoXuatXu()
        {
            if (spBLL != null)
            {
                Console.Write("\nNhập xuất xứ để tìm kiếm sản phẩm : ");
                string ma = Console.ReadLine();
                List<SanPhamDTO> temp = spBLL.TimKiem_XuatXu(ma);
                if (temp == null || temp.Count == 0)
                    Console.WriteLine($"Không có sản phẩm nào xuất xứ ở {ma}");
                else
                {
                    Console.WriteLine($"\n------------Những sản phẩm có xuất xứ {ma}------------");
                    foreach (SanPhamDTO sp in temp)
                        Console.WriteLine(sp);
                }
            }
            else Console.WriteLine("Danh sách sản phẩm rỗng");
        }
        public void DSTrangDiem()
        {
            if (spBLL != null)
            {
                List<SanPhamDTO> temp = spBLL.LocSanPhamTrangDiem();
                if (temp == null || temp.Count == 0)
                    Console.WriteLine("Không có sản phẩm loại trang diểm");
                else
                {
                    Console.WriteLine($"\n------------Những sản phẩm loại trang điểm------------");
                    foreach (SanPhamDTO sp in temp)
                        Console.WriteLine(sp);
                }
            }
            else Console.WriteLine("Danh sách sản phẩm rỗng");
        }
        public void SP_SanXuatTren3Thang()
        {
            if (spBLL != null)
            {
                List<SanPhamDTO> temp = spBLL.SanPhamSXTren3Thang();
                if (temp == null || temp.Count == 0)
                    Console.WriteLine("Không có sản phẩm có ngày sản xuất trên 3 tháng");
                else
                {
                    Console.WriteLine($"\n------------Những sản phẩm có ngày sản xuất trên 3 tháng------------");
                    foreach (SanPhamDTO sp in temp)
                        Console.WriteLine(sp);
                }
            }
            else Console.WriteLine("Danh sách sản phẩm rỗng");
        }
        public void CapNhatGiaBanTrangDiem()
        {
            if (spBLL != null)
            {
                spBLL.TangGiaTrangDiem5();
                Console.WriteLine("Đã tăng giá các sản phẩm trang điểm 5%.");
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
                sp = new TrangDiemDTO(ma, ten, trongLuong, giaBan, xuatXu, ngaySanXuat);            }
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
        public void menu()
        {
            Console.WriteLine("\n====================== QUẢN LÝ CỬA HÀNG ======================");
            Console.WriteLine("1. Đọc danh sách các sản phẩm và khách hàng");
            Console.WriteLine("2. Thêm một sản phẩm mới");
            Console.WriteLine("3. Xuất danh sách các sản phẩm có trong cửa hàng");
            Console.WriteLine("4. Tìm sản phẩm khi biết nơi xuất xứ");
            Console.WriteLine("5. Xuất danh sách các sản phẩm khi biết tên khách hàng");
            Console.WriteLine("6. Cập nhật giá bán cho các sản phẩm thuộc loại trang điểm tăng lên 5%");
            Console.WriteLine("7. Xuất danh sách các sản phẩm có giá trên 300");
            Console.WriteLine("8. Xuất danh sách các sản phẩm thuộc loại trang điểm");
            Console.WriteLine("9. In ra danh sách các khách hàng đã mua nhiều hơn 3 sản phẩm");
            Console.WriteLine("10.In ra danh sách sản phẩm có ngày sản xuất trên 3 tháng");
            Console.WriteLine("11.In ra thông tin khách hàng đã mua nhiều tiền nhất");
            Console.WriteLine("0. Thoát");
        }
    }
}