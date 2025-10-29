using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class KhachHangBLL
    {
        private string maKH;
        private string tenKH;
        private string soDT;
        List<SanPhamBLL> dssp;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public List<SanPhamBLL> Dssp { get => dssp; set => dssp = value; }
        public KhachHangBLL()
        {
            Dssp = new List<SanPhamBLL>();
        }

        public KhachHangBLL(string maKH, string tenKH, string soDT, List<SanPhamBLL> dssp)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soDT = soDT;
            this.dssp = dssp;
        }
    }
}