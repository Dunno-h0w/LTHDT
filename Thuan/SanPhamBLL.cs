using System;
using System.Collections.Generic;
using System.Linq;
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