using System;

namespace DTO
{
    public abstract class SanPhamDTO
    {
       
        private readonly string ma, ten, xx;
        private readonly DateTime nsx;
        private double tl, gia;

        protected SanPhamDTO(string ma, string ten, double tl, double gia, string xx, DateTime nsx)
        {
            this.ma = ma ?? "";
            this.ten = ten ?? "";
            this.tl = tl;
            this.gia = gia;
            this.xx = xx ?? "";
            this.nsx = nsx;
        }

        public string GetMaSP() => ma;
        public string GetTenSP() => ten;
        public double GetTrongLuong() => tl;
        public double GetGiaBan() => gia;
        public string GetXuatXu() => xx;
        public DateTime GetNgaySanXuat() => nsx;

        public void TangGiaPhanTram(double pct) => gia += gia * pct / 100.0;

     
        public abstract string GetLoai();
    }
}
