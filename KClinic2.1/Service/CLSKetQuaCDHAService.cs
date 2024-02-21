using KClinic2._1.Contexts;
using KClinic2._1.Desktop;
using KClinic2._1.DTOs;
using KClinic2._1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Service
{
    public interface ICLSKetQuaCDHASerivce
    {
        Search_CLSKetQuaCDHA_DaThucHien[] SearchCLSKetQuaCDHA(CLSSearchCriteria searchCriteria);
    }
    public class CLSKetQuaCDHAService : ICLSKetQuaCDHASerivce
    {
        private static readonly KClinicContext _context = new KClinicContext();
        public Search_CLSKetQuaCDHA_DaThucHien[] SearchCLSKetQuaCDHA(CLSSearchCriteria searchCriteria)
        {
            var phongBanId = int.Parse(searchCriteria.PhongBanId);
            var clsKetQuaCDHAs = _context.K_CLSKetQua_CDHA
                .Include(c => c.CLSYeuCau.BenhNhan)
                .Include(c => c.CLSYeuCau.DichVu)
                .Where(c => c.CLSYeuCau.SoPhieuYeuCau.Contains(searchCriteria.SoPhieuYeuCau))
                .Where(c => c.TiepNhan.SoTiepNhan.Contains(searchCriteria.SoTiepNhan))
                .Where(c => c.CLSYeuCau.BenhNhan.TenBenhNhan.Contains(searchCriteria.TenBenhNhan))
                .Where(c => c.CLSYeuCau.BenhNhan.MaYTe.Contains(searchCriteria.MaYTe))
                .Where(c => c.CLSYeuCau.BenhNhan.SoDienThoai.Contains(searchCriteria.SoDienThoai))
                .Where(c => searchCriteria.NamSinh == 0 || c.CLSYeuCau.BenhNhan.NamSinh == searchCriteria.NamSinh)
                .Where(c => DbFunctions.DiffDays(searchCriteria.TuNgay, c.NgayThucHien) >= 0)
                .Where(c => DbFunctions.DiffDays(searchCriteria.DenNgay, c.NgayThucHien) <= 0)
                .Where(c => c.TiepNhan.Huy == 0 && c.CLSYeuCau.Huy == 0 && c.Huy == 0
                && c.CLSYeuCau.TrangThai == "CoKetQua"
                && !c.CLSYeuCau.DichVu.NhomDichVu.MaNhomDichVu.Contains("XN")
                && !c.CLSYeuCau.DichVu.NhomDichVu.MaNhomDichVu.Contains("KB")
                && c.CLSYeuCau.NoiThucHien.PhongBan_Id == phongBanId
                ).ToArray();

            var result = new List<Search_CLSKetQuaCDHA_DaThucHien>();
            Parallel.ForEach(clsKetQuaCDHAs, clsKetQuaCDHA => 
            {
                var benhNhan = clsKetQuaCDHA.CLSYeuCau.BenhNhan;
                var clsYeuCau = clsKetQuaCDHA.CLSYeuCau;
                result.Add(new Search_CLSKetQuaCDHA_DaThucHien()
                {
                    CLSKetQua_Id = clsKetQuaCDHA.CLSKetQua_Id,
                    CLSYeuCau_Id = clsKetQuaCDHA.CLSYeuCau_Id ?? 0,
                    TiepNhan_Id = clsKetQuaCDHA.TiepNhan_Id ?? 0,
                    SoPhieuYeuCau = clsYeuCau.SoPhieuYeuCau,
                    MaYTe = benhNhan.MaYTe,
                    SoDienThoai = benhNhan.SoDienThoai,
                    TenBenhNhan = benhNhan.TenBenhNhan,
                    NamSinh = benhNhan.NamSinh != 0 ? $"{benhNhan.NamSinh}" : "N/N",
                    Tuoi = benhNhan.NamSinh != 0 ? $"{DateTime.Now.Year - benhNhan.NamSinh}" : "N/N",
                    TenDichVu = clsYeuCau.DichVu.TenDichVu,
                    NgayThucHien = clsKetQuaCDHA.NgayThucHien
                });
            })
            ;
            return result.ToArray();
        }
    }
}
