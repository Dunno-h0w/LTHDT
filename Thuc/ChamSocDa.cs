using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ChamSocDa:SanPham,IKhuyenMai
    {
        public ChamSocDa():base()
        {
            
        }
        public ChamSocDa(string msp,string tsp,double tl,double gb,string xx,DateTime nsx):base(msp,tsp,tl,gb,xx,nsx)
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
        public double KhuyenMai()
        {
            throw new NotImplementedException();
        }
    }
}
