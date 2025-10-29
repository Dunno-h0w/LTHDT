using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class KhachHangBLL
    {
        private KhachHangDAL khDAL = new KhachHangDAL();
        public List<KhachHangDTO> dsKhachHang;
        public KhachHangBLL()
        {
            dsKhachHang = khDAL.Docfile_kh("../../../Data/DS_KH.xml");
        }
        public List<KhachHangDTO> GetKhachHangDTOs()
        {
            return dsKhachHang;
        }

    }
}