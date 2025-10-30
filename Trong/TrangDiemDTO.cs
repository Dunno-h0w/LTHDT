using System;

namespace DTO
{
    public class TrangDiemDTO : SanPhamDTO
    {
        public TrangDiemDTO(string ma, string ten, double tl, double gia, string xx, DateTime nsx)
             : base(ma, ten, tl, gia, xx, nsx) { }

        public override string GetLoai() => "TrangDiem";



        private string ma;
        private string ten;
        private double tl;
        private double gia;
        private string xx;
        private DateTime nsx;

        

    }
}