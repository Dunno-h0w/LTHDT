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

    }
}