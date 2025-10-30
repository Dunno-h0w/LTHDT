using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ConsoleApp1
{
    public class SanPhamDAL
    {
        private List<SanPhamDTO> ds = new List<SanPhamDTO>();
        public List<SanPhamDTO> Ds { get => ds; set => ds = value; }
        public SanPhamDAL() { }
        public List<SanPhamDTO> Docfile_sp(string filename)
        {
            XmlDocument f = new XmlDocument();
            f.Load(filename);
            XmlNodeList listnode = f.SelectNodes("SanPhams/SanPham");
            foreach (XmlNode node in listnode)
            {
                string loai = (node.Attributes["Loai"].Value);
                string maSP = node["MaSP"].InnerText;
                string tenSP = node["TenSP"].InnerText;
                double trongLuong = double.Parse(node["TrongLuong"].InnerText);
                double giaBan = double.Parse(node["GiaBan"].InnerText);
                string xuatXu = node["XuatXu"].InnerText;
                DateTime ngaySX = DateTime.Parse(node["NgaySX"].InnerText);
                if (loai == "ChamSocDa")
                {
                    ChamSocDaDTO sp = new ChamSocDaDTO(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX);
                    Ds.Add(sp);
                }
                else if (loai == "ChongNang")
                {
                    ChongNangDTO sp = new ChongNangDTO(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX);
                    Ds.Add(sp);
                }
                else
                {
                    TrangDiemDTO sp = new TrangDiemDTO(maSP, tenSP, trongLuong, giaBan, xuatXu, ngaySX);
                    Ds.Add(sp);
                }
            }
            return Ds;
        }
    }
}