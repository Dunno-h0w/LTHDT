using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class TrangDiemDTO:SanPhamDTO,IKhuyenMai
    {
        public TrangDiemDTO() : base()
        {

        }
        public TrangDiemDTO(string msp, string tsp, double tl, double gb, string xx, DateTime nsx) : base(msp, tsp, tl, gb, xx, nsx)
        {

        }
        public double KhuyenMai()
        {
            if (GiaBan > 200000) return 0.10;
            else if (GiaBan > 100000) return 0.07;
            else return 0.05;
        }
        public override double GiaSauKhiGiam()
        {
            return GiaBan * (1 - (TroGia() + KhuyenMai()));
        }
        public override string LoaiSP()
        {
            return "Trang điểm";
        }
    }
}