using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Model
{
    public class SearchCriteria
    {
    }
    public class CLSSearchCriteria : SearchCriteria
    {
        public string SoPhieuYeuCau { get; set; } = string.Empty;
        public string NgayChiDinh { get; set; } = string.Empty;
        public string MaYTe { get; set; } = string.Empty;
        public string TenBenhNhan { get; set; } = string.Empty;
        public int? NamSinh { get; set; }
        public string SoTiepNhan { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string PhongBanId { get; set; }
        public DateTime TuNgay { get; set; } = DateTime.UtcNow;
        public DateTime DenNgay { get; set; } = DateTime.UtcNow;

        public CLSSearchCriteria(string phongBanId)
        {
            PhongBanId = phongBanId;
        }
    }
}
