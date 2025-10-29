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
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            SanPhamGUI qlsp = new SanPhamGUI();
            KhachHangGUI qlkh = new KhachHangGUI();

            int chon;
            if(chon == 1)
            {
                qlsp.Doc_file();
                qlkh.Doc_file();
            }
            else if (chon == 2) qlsp.ThemSanPham();
            else if (chon == 3)
            {
                qlsp.showSanPhams();
            }
        }
    }
}
