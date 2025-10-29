using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class KhachHang
    {
        private string maKH;
        private string tenKH;
        private string soDT;
        List<SanPham> dssp;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public List<SanPham> Dssp { get => dssp; set => dssp = value; }
        public KhachHang()
        {
            Dssp = new List<SanPham>();
        }

        public KhachHang(string maKH, string tenKH, string soDT, List<SanPham> dssp)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soDT = soDT;
            this.dssp = dssp;
        }
    }
}