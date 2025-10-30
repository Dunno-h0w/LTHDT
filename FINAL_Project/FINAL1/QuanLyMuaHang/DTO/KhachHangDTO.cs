using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class KhachHangDTO
    {
        private string maKH;
        private string tenKH;
        private string soDT;
        List<SanPhamDTO> dssp;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public List<SanPhamDTO> Dssp { get => dssp; set => dssp = value; }
        public KhachHangDTO()
        {
            Dssp = new List<SanPhamDTO>();
        }

        public KhachHangDTO(string maKH, string tenKH, string soDT, List<SanPhamDTO> dssp)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soDT = soDT;
            this.dssp = dssp;
        }
        public override string ToString()
        {
            return $"Mã KH : {MaKH,-8} | Tên KH : {TenKH, -25} | Số ĐT : {SoDT, -15} | Số sản phẩm đã mua : {Dssp.Count, -20}";
        }
    }
}