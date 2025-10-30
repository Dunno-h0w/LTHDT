using System;

namespace DTO
{
    public class ChamSocDaDTO : SanPhamDTO
    {
        public ChamSocDaDTO(string ma, string ten, double tl, double gia, string xx, DateTime nsx)
            : base(ma, ten, tl, gia, xx, nsx) { }

        public override string GetLoai() => "ChamSocDa";
    }
}
