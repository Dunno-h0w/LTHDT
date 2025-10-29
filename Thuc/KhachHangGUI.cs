using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class KhachHangGUI
    {
        private string maKH;
        private string tenKH;
        private string soDT;
        List<SanPhamGUI> dssp;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public List<SanPhamGUI> Dssp { get => dssp; set => dssp = value; }
        public KhachHangGUI()
        {
            Dssp = new List<SanPhamGUI>();
        }

        public KhachHangGUI(string maKH, string tenKH, string soDT, List<SanPhamGUI> dssp)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soDT = soDT;
            this.dssp = dssp;
        }
    }
}