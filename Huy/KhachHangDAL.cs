using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ConsoleApp1
{
    public class KhachHangDAL
    {
        private string maKH;
        private string tenKH;
        private string soDT;
        List<SanPhamDAL> dssp;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public List<SanPhamDAL> Dssp { get => dssp; set => dssp = value; }
        public KhachHangDAL()
        {
            Dssp = new List<SanPhamDAL>();
        }

        public KhachHangDAL(string maKH, string tenKH, string soDT, List<SanPhamDAL> dssp)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soDT = soDT;
            this.dssp = dssp;
        }
    }
}