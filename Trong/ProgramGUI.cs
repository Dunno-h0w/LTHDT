using BLL;
using DTO;
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
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var bll = new SanPhamBLL();

            try
            {
                // (4) Tìm theo xuất xứ (Han ~ Hàn)
                var ds1 = bll.TimTheoXuatXu("Han");
                Console.WriteLine($"Theo xuất xứ 'Han': {ds1.Count}");
                Print(ds1);

                // (5) Sản phẩm đã mua theo tên KH (không dấu)
                var ds2 = bll.LaySPTheoTenKH("Nguyen A");
                Console.WriteLine($"\nSP của 'Nguyen A': {ds2.Count}");
                Print(ds2);

                // (6) Tăng giá 5% loại TrangDiem
                var n = bll.TangGiaTrangDiem5();
                Console.WriteLine($"\nĐã tăng giá {n} sản phẩm TrangDiem.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n[ERR] " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        static void Print(System.Collections.Generic.IEnumerable<SanPhamDTO> list)
        {
            foreach (var sp in list)
            {
                Console.WriteLine($"- {sp.GetMaSP(),-5} | {sp.GetTenSP(),-30} | {sp.GetXuatXu(),-12} | {sp.GetLoai(),-10} | {sp.GetGiaBan():0}");
            }
        }
    }
}
    

