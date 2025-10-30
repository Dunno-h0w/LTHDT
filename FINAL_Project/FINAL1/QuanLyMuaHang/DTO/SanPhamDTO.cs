using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public abstract class SanPhamDTO
    {
        private string maSP;
        private string tenSP;
        private double trongLuong;
        private double giaBan;
        private string xuatXu;
        private DateTime ngaySanXuat;

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public double TrongLuong { get => trongLuong; set => trongLuong = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public DateTime NgaySanXuat { get => ngaySanXuat; set => ngaySanXuat = value; }


        protected SanPhamDTO(string maSP, string tenSP, double trongLuong, double giaBan, string xuatXu, DateTime ngaySanXuat)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.trongLuong = trongLuong;
            this.giaBan = giaBan;
            this.xuatXu = xuatXu;
            this.ngaySanXuat = ngaySanXuat;
        }
        protected SanPhamDTO()
        {

        }

        public double TroGia()
        {
            TimeSpan ktg = (NgaySanXuat - DateTime.Today);
            double soThang = ktg.TotalDays / 30;
            if (soThang >= 12) return 0.1;
            else if (soThang >= 9) return 0.05;
            else return 0.03;
        }
        public abstract double GiaSauKhiGiam();
        public abstract string LoaiSP();
        public override string ToString()
        {
            return $"{MaSP,-8} | {TenSP,-25} | {GiaBan,-10:#,##0} | {XuatXu,-10} | {NgaySanXuat,-15:dd/MM/yyyy} | Loại : {LoaiSP(), -12}";
        }

    }
}