using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    public class SanPhamBLL
    {
        private SanPhamDAL spDAL = new SanPhamDAL();
        public List<SanPhamDTO> dsSanPham;
        public SanPhamBLL()
        {
            dsSanPham = spDAL.Docfile_sp("../../../Data/DS_SP.xml");
        }
        public List<SanPhamDTO> GetSanPhamDTOs()
        {
            return dsSanPham;
        }
        public List<SanPhamDTO> LocGiaTren300()
        {
            return dsSanPham.Where(t => t.GiaBan > 300000).ToList();
        }
        public List<SanPhamDTO> TimKiem_XuatXu(string xx)
        {
            return dsSanPham.Where(t => t.XuatXu.ToLower() == xx.ToLower()).ToList();
        }
        public List<SanPhamDTO> LocSanPhamTrangDiem()
        {
            return dsSanPham.Where(t => t.LoaiSP() == "Trang điểm").ToList();
        }
        public List<SanPhamDTO> SanPhamSXTren3Thang()
        {
            DateTime ngayHienTai = DateTime.Now;
            return dsSanPham.Where(sp => (ngayHienTai - sp.NgaySanXuat).TotalDays > 90).ToList();
        }
        public void TangGiaTrangDiem5()
        {
            foreach(SanPhamDTO sp in dsSanPham.OfType<TrangDiemDTO>())
            {
                sp.GiaBan = sp.GiaBan * 1.05;
            }    
        }
        public bool ThemSanPham(SanPhamDTO sp)
        {
            foreach (SanPhamDTO s in dsSanPham)
            {
                if (s.MaSP == sp.MaSP)
                {
                    return false;
                }
            }
            dsSanPham.Add(sp);
            return true;
        }
    }
}