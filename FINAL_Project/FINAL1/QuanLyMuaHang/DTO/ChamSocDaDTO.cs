using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ChamSocDaDTO:SanPhamDTO,IKhuyenMai
    {
        public ChamSocDaDTO():base()
        {
            
        }
        public ChamSocDaDTO(string msp,string tsp,double tl,double gb,string xx,DateTime nsx):base(msp,tsp,tl,gb,xx,nsx)
        {

        }
        public double KhuyenMai()
        {
            return 0.1;
        }
        public override string LoaiSP()
        {
            return "Chăm sóc da";
        }
        public override double GiaSauKhiGiam()
        {
            return GiaBan * (1 - (TroGia() + KhuyenMai()));
        }
    }
}
