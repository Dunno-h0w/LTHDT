using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ConsoleApp1
{
    public class KhachHangDAL
    {
        List<KhachHangDTO> ds = new List<KhachHangDTO>();
        public List<KhachHangDTO> Ds { get => ds; set => ds = value; }
        public KhachHangDAL() { }
        public List<KhachHangDTO> Docfile_kh(string filename)
        {
            XmlDocument f = new XmlDocument();
            f.Load(filename);
            XmlNodeList listnode = f.SelectNodes("DanhSachKhachHang/KhachHang");
            foreach (XmlNode node in listnode)
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = node["MaKH"].InnerText;
                kh.TenKH = node["TenKH"].InnerText;
                kh.SoDT = node["SoDT"].InnerText;
                foreach (XmlNode spNode in node.SelectNodes("DanhSachMua/SanPham"))
                {
                    string loai = spNode["Loai"].InnerText;
                    string maSP = spNode["MaSP"].InnerText;
                    string tenSP = spNode["TenSP"].InnerText;
                    double trongLuong = double.Parse(spNode["TrongLuong"].InnerText);
                    double giaBan = double.Parse(spNode["GiaBan"].InnerText);
                    string xuatXu = spNode["XuatXu"].InnerText;
                    DateTime ngaySX = DateTime.Parse(spNode["NgaySX"].InnerText);
                    if (loai == "ChamSocDa")
                    {
                        ChamSocDaDTO sp = new ChamSocDaDTO(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX);
                        kh.Dssp.Add(sp);
                    }
                    else if (loai == "TrangDiem")
                    {
                        TrangDiemDTO sp = new TrangDiemDTO(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX);
                        kh.Dssp.Add(sp);
                    }
                    else
                    {
                        ChongNangDTO sp = new ChongNangDTO(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX);
                        kh.Dssp.Add(sp);
                    }
                }
                Ds.Add(kh);
            }
            return Ds;
        }

    }
}