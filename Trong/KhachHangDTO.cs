using System;
using System.Collections.Generic;

namespace DTO
{
    public class KhachHangDTO
    {
        private readonly string ma, ten, sdt;
        private readonly List<string> dsMaDaMua;

        public KhachHangDTO(string ma, string ten, string sdt, List<string> dsMaDaMua)
        {
            this.ma = ma; this.ten = ten; this.sdt = sdt;
            this.dsMaDaMua = dsMaDaMua ?? new List<string>();
        }

        public string GetMaKH() => ma;
        public string GetTenKH() => ten;
        public string GetSoDT() => sdt;
        public List<string> GetDanhSachSPDaMua() => dsMaDaMua;
    }
}
