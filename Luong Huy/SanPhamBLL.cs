using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public abstract class SanPhamBLL
    {
        private string maSP;
        private string tenSP;
        private double trongLuong;
        private double giaBan;
        private string xuatXu;
        private DateTime ngaySanXuat;

        protected string MaSP { get => maSP; set => maSP = value; }
        protected string TenSP { get => tenSP; set => tenSP = value; }
        protected double TrongLuong { get => trongLuong; set => trongLuong = value; }
        protected double GiaBan { get => giaBan; set => giaBan = value; }
        protected string XuatXu { get => xuatXu; set => xuatXu = value; }
        protected DateTime NgaySanXuat { get => ngaySanXuat; set => ngaySanXuat = value; }


        protected SanPhamBLL(string maSP, string tenSP, double trongLuong, double giaBan, string xuatXu, DateTime ngaySanXuat)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.trongLuong = trongLuong;
            this.giaBan = giaBan;
            this.xuatXu = xuatXu;
            this.ngaySanXuat = ngaySanXuat;
        }
        protected SanPhamBLL()
        {

        }

        public abstract double GiamGia();

        public virtual void Nhap()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Xuat()
        {
            throw new System.NotImplementedException();
        }
        
    }
}