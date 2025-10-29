using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class ChongNang:SanPham
    {
        public ChongNang() : base()
        {

        }
        public ChongNang(string msp, string tsp, double tl, double gb, string xx, DateTime nsx) : base(msp, tsp, tl, gb, xx, nsx)
        {

        }
        public override double GiamGia()
        {
            throw new NotImplementedException();
        }
        public override void Xuat()
        {
            throw new NotImplementedException();
        }
    }
}