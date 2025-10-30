using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DTO;

namespace DAL
{
    public class XmlData
    {
        private readonly string fileSP;
        private readonly string fileKH;

        public XmlData(string pSP = null, string pKH = null)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string root = Path.GetFullPath(Path.Combine(baseDir, "..", "..", ".."));

            fileSP = pSP ?? Path.Combine(root, "Data", "sanpham.xml");
            fileKH = pKH ?? Path.Combine(root, "Data", "khachhang.xml");
        }

        // --------- ĐỌC SẢN PHẨM ----------
        public List<SanPhamDTO> DocSanPham()
        {
            var list = new List<SanPhamDTO>();
            if (!File.Exists(fileSP)) return list;

            XDocument doc;
            try { doc = XDocument.Load(fileSP); }
            catch { return list; } 

            var root = doc.Root;
            if (root == null) return list;

            foreach (var x in root.Elements("SanPham"))
            {
                string ma = (string)x.Element("MaSP") ?? "";
                string ten = (string)x.Element("TenSP") ?? "";
                double tl = (double?)x.Element("TrongLuong") ?? 0d;
                double gia = (double?)x.Element("GiaBan") ?? 0d;
                string xx = (string)x.Element("XuatXu") ?? "";

                DateTime nsx;
                if (!DateTime.TryParse((string)x.Element("NgaySX"), out nsx))
                    nsx = DateTime.MinValue;

                string loaiRaw = ((string)x.Element("Loai") ?? "").Trim();

                SanPhamDTO sp;
                if (IsLoai(loaiRaw, "TrangDiem"))
                    sp = new TrangDiemDTO(ma, ten, tl, gia, xx, nsx);
                else if (IsLoai(loaiRaw, "ChongNang"))
                    sp = new ChongNangDTO(ma, ten, tl, gia, xx, nsx);
                else
                    sp = new ChamSocDaDTO(ma, ten, tl, gia, xx, nsx);

                list.Add(sp);
            }
            return list;
        }

        // --------- GHI SẢN PHẨM ----------
        public void GhiSanPham(IEnumerable<SanPhamDTO> ds)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileSP) ?? ".");

            var doc = new XDocument(
                new XElement("DanhSach",
                    ds.Select(sp =>
                    {
                        var raw = sp.GetNgaySanXuat();
                        DateTime nsx = (raw is DateTime d)
                            ? d
                            : (DateTime.TryParse(Convert.ToString(raw), out var t) ? t : DateTime.MinValue);

                        return new XElement("SanPham",
                            new XElement("MaSP", sp.GetMaSP()),
                            new XElement("TenSP", sp.GetTenSP()),
                            new XElement("TrongLuong", sp.GetTrongLuong()),
                            new XElement("GiaBan", sp.GetGiaBan()),
                            new XElement("XuatXu", sp.GetXuatXu()),
                            new XElement("NgaySX", nsx.ToString("yyyy-MM-dd")),
                            new XElement("Loai", sp.GetLoai())
                        );
                    })
                )
            );

            doc.Save(fileSP);
        }

        // --------- ĐỌC KHÁCH HÀNG ----------
        public List<KhachHangDTO> DocKhachHang()
        {
            var list = new List<KhachHangDTO>();
            if (!File.Exists(fileKH)) return list;

            XDocument doc;
            try { doc = XDocument.Load(fileKH); }
            catch { return list; }

            var root = doc.Root;
            if (root == null) return list;

            foreach (var c in root.Elements("KhachHang"))
            {
                var ds = new List<string>();
                var p = c.Element("SanPhamMua");
                if (p != null)
                {
                    ds = p.Elements("MaSP")
                          .Select(e => (string)e)
                          .Where(s => !string.IsNullOrWhiteSpace(s))
                          .ToList();
                }

                list.Add(new KhachHangDTO(
                    (string)c.Element("MaKH") ?? "",
                    (string)c.Element("TenKH") ?? "",
                    (string)c.Element("SoDT") ?? "",
                    ds
                ));
            }
            return list;
        }

       
        private static bool IsLoai(string loai, string target)
            => string.Equals(ToKey(loai), ToKey(target), StringComparison.Ordinal);

        private static string ToKey(string s)
            => new string((s ?? "")
                .Where(ch => !char.IsWhiteSpace(ch))
                .Select(ch => RemoveAccent(ch))
                .ToArray())
               .ToLowerInvariant();

        private static char RemoveAccent(char c)
        {
           
            string src = "Hàn Quốc";
            string rep = "yy";
            int idx = src.IndexOf(c);
            if (idx >= 0) return rep[idx];
            idx = src.ToUpper().IndexOf(c);
            if (idx >= 0) return char.ToUpper(rep[idx]);
            return c;
        }
    }
}
