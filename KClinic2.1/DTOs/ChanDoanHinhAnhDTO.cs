using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.DTOs
{
    public class Search_CLSKetQuaCDHA_DaThucHien
    {
        public int CLSKetQua_Id { get; set; }
        public int CLSYeuCau_Id { get; set; }
        public int TiepNhan_Id { get; set; }
        public string SoPhieuYeuCau { get; set; }
        public string MaYTe { get; set; }
        public string TenBenhNhan { get; set; }
        public string Tuoi { get; set; }
        public string NamSinh { get; set; }
        public string SoDienThoai { get; set; }
        public string TenDichVu { get; set; }
        public DateTime? NgayThucHien { get; set; }
    }
    public class Search_CLSKetQuaCDHA_ChuaThucHien
    {
        public int CLSYeuCau_Id { get; set; }
        public string SoPhieuYeuCau { get; set; }
        public string TenBenhNhan { get; set; }
        public string Tuoi { get; set; }
        public string NamSinh { get; set; }
        public string SoDienThoai { get; set; }
        public string TenDichVu { get; set; }
        public DateTime? NgayYeuCau { get; set; }
    }

    public class Search_CDHA_All
    {
        public int CLSYeuCau_Id { get; set; }
        public int CLSKetQua_Id { get; set; }
        public int TiepNhan_Id { get; set; }
        public string SoPhieuYeuCau { get; set; }
        public string TenBenhNhan { get; set; }
        public string Tuoi { get; set; }
        public string DiaChi { get; set; }
        public string NamSinh { get; set; }
        public string MaYTe { get; set; }
        public string SoTiepNhan { get; set; }
        public string TrangThai { get; set; }
        public string SoDienThoai { get; set; }
        public string TenDichVu { get; set; }
        public DateTime? NgayYeuCau { get; set; }
        public DateTime? NgayThucHien { get; set; }
    }
}
