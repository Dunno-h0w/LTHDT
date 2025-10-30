using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class ChongNangDTO:SanPhamDTO
    {
        public ChongNangDTO() : base()
        {

        }
        public ChongNangDTO(string msp, string tsp, double tl, double gb, string xx, DateTime nsx) : base(msp, tsp, tl, gb, xx, nsx)
        {

        }
        public override double GiaSauKhiGiam()
        {
            return GiaBan * (1 - TroGia());
        }
        public override string LoaiSP()
        {
            return "Chống nắng";
        }
    }
}