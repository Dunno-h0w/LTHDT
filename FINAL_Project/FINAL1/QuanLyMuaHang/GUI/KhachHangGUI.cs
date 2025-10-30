using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class KhachHangGUI
    {
        public KhachHangBLL khBLL;
        public void Doc_file()
        {
            try
            {
                khBLL = new KhachHangBLL();
                Console.WriteLine("Đọc file khách hàng thành công");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đọc file: " + ex.Message);
            }
        }
        public void showKhachHangs()
        {
            if (khBLL != null)
            {
                List<KhachHangDTO> khs = khBLL.GetKhachHangDTOs();
                foreach (KhachHangDTO sp in khs)
                    Console.WriteLine(sp);
            }
            else Console.WriteLine("Danh sách khách hàng rỗng");
        }
        public void XuatDSSanPhamTheoTenKH()
        {
            if (khBLL != null)
            {
                Console.Write("Nhập tên khách hàng để tìm kiếm những sản phẩm mua : ");
                string ten = Console.ReadLine();
                List<KhachHangDTO> temp = khBLL.TimDSTheoTenKH(ten);
                if (temp == null || temp.Count == 0)
                    Console.WriteLine($"Không có khách hàng {ten} trong danh sách khách hàng");
                else
                {
                    foreach (KhachHangDTO kh in temp)
                    {
                        Console.WriteLine($"Khách hàng: {kh.TenKH} - {kh.SoDT}");
                        foreach (SanPhamDTO sps in kh.Dssp)
                            Console.WriteLine(sps);
                    }
                }
            }
            else Console.WriteLine("Danh sách khách hàng rỗng");
        }
        public void XuatDSMuaNhieuHon3()
        {
            if (khBLL != null)
            {
                List<KhachHangDTO> temp = khBLL.DSKHMuaHon3();
                if (temp == null || temp.Count == 0)
                    Console.WriteLine($"Không có khách hàng mua nhiều hơn 3 sản phẩm");
                else
                {
                    Console.WriteLine($"\n------------Những khách hàng mua nhiều hơn 3 sản phẩm------------");
                    foreach (KhachHangDTO kh in temp)
                        Console.WriteLine(kh);
                }
            }
            else Console.WriteLine("Danh sách khách hàng rỗng");
        }
        public void XuatKhachHangMuaNhieuNhat()
        {
            if (khBLL != null)
            {
                List<KhachHangDTO> temp = khBLL.KhachHangMuaNhieuNhat();
                if (temp == null || temp.Count == 0)
                    Console.WriteLine("Danh sách không có khách hàng");
                else
                {
                    foreach (KhachHangDTO kh in temp)
                    {
                        Console.Write("Tên KH: " + kh.TenKH + " - SĐT: " + kh.SoDT);
                        double tongtien = 0;
                        foreach (SanPhamDTO sps in kh.Dssp)
                        {
                            tongtien += sps.GiaBan;
                        }
                        Console.WriteLine($" - Tổng tiền: {tongtien::#,##0}");
                    }
                }
            }
            else Console.WriteLine("Danh sách khách hàng rỗng");
        }
    }
}