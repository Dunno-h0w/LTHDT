using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class SanPhamBLL
    {
        private readonly XmlData dal = new XmlData();

     
        private static string ToUnsign(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            var norm = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(norm.Length);
            foreach (var ch in norm)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark) sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        // (4)
        public List<SanPhamDTO> TimTheoXuatXu(string noi)
        {
            var key = ToUnsign((noi ?? "").Trim()).ToLowerInvariant();

            return dal.DocSanPham()
                      .Where(sp => ToUnsign(sp.GetXuatXu() ?? "")
                                    .ToLowerInvariant()
                                    .Contains(key))
                      .OrderBy(sp => sp.GetTenSP())
                      .ToList();
        }

        // (5)
        public List<SanPhamDTO> LaySPTheoTenKH(string tenKH)
        {
            var dssp = dal.DocSanPham();
            var dskh = dal.DocKhachHang();

            var target = ToUnsign((tenKH ?? "").Trim()).ToLowerInvariant();

            var kh = dskh.FirstOrDefault(k =>
                        ToUnsign(k.GetTenKH()?.Trim() ?? "").ToLowerInvariant() == target);

            if (kh == null) return new List<SanPhamDTO>();

            var setMa = new HashSet<string>(kh.GetDanhSachSPDaMua() ?? new List<string>());
            return dssp.Where(sp => setMa.Contains(sp.GetMaSP()))
                       .OrderBy(sp => sp.GetTenSP())
                       .ToList();
        }

        // (6) 
        public int TangGiaTrangDiem5()
        {
            var dssp = dal.DocSanPham();

            var targets = dssp
                .Where(sp => string.Equals(sp.GetLoai(), "TrangDiem", StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var sp in targets)
                sp.TangGiaPhanTram(5.0);

            dal.GhiSanPham(dssp);
            return targets.Count;
        }
    }
}
