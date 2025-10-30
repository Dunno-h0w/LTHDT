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
        public List<KhachHangDTO> TimDSTheoTenKH(string ten)
        {
            List<KhachHangDTO> kq = new List<KhachHangDTO>();
            foreach(KhachHangDTO kh in dsKhachHang)
            {
                if(kh.TenKH.ToLower() == ten.ToLower())
                {
                    kq.Add(kh);
                }    
            }
            return kq;        
        }
        public List<KhachHangDTO> DSKHMuaHon3()
        {
            return dsKhachHang.Where(t => t.Dssp.Count > 3).ToList();
        }
        public double MuaNhieuNhat()
        {
            return dsKhachHang.Max(t => t.Dssp.Sum(q => q.GiaBan));
        }
        public List<KhachHangDTO> KhachHangMuaNhieuNhat()
        {
            double tienmax = MuaNhieuNhat();
            return dsKhachHang.Where(t => t.Dssp.Sum(q => q.GiaBan) ==  tienmax).ToList();
        }
    }
}