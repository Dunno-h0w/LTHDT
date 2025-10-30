using System;

namespace DTO
{
    public class ChongNangDTO : SanPhamDTO
    {
        public ChongNangDTO(string ma, string ten, double tl, double gia, string xx, DateTime nsx)
            : base(ma, ten, tl, gia, xx, nsx) { }

        public override string GetLoai() => "ChongNang";
    }
}
