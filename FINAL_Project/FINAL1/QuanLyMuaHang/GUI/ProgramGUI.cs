using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class ProgramGUI
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            SanPhamGUI qlsp = new SanPhamGUI();
            KhachHangGUI qlkh = new KhachHangGUI();
            while (true)
            {
                qlsp.menu();
                Console.Write("\nChọn chức năng bạn muốn thực thi: ");
                int chon;
                chon = int.Parse(Console.ReadLine());
                if (chon == 1)
                {
                    qlsp.Doc_file();
                    qlkh.Doc_file();
                }
                else if (chon == 2) qlsp.ThemSanPham();
                else if (chon == 3)
                {
                    qlsp.showSanPhams();
                }
                else if (chon == 4)
                    qlsp.LocTheoXuatXu();
                else if (chon == 5) qlkh.XuatDSSanPhamTheoTenKH();
                else if (chon == 6) qlsp.CapNhatGiaBanTrangDiem();
                else if (chon == 7) qlsp.LocSPGiaHon300();
                else if (chon == 8) qlsp.DSTrangDiem();
                else if (chon == 9) qlkh.XuatDSMuaNhieuHon3();
                else if (chon == 10) qlsp.SP_SanXuatTren3Thang();
                else if (chon == 11) qlkh.XuatKhachHangMuaNhieuNhat();
                else if (chon == 0)
                {
                    Console.WriteLine("Thoát chương trình");
                    break;
                }
            } 
                
            Console.ReadKey();
        }
    }
}
