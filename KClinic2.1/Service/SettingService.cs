using KClinic2._1.Contexts;
using KClinic2._1.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Service
{
    public interface ISettingService
    {
        K_Setting GetSettingBySettingCode(string settingCode);
    }
    public class SettingService : ISettingService
    {
        private static readonly KClinicContext _context = new KClinicContext();
        public K_Setting GetSettingBySettingCode(string settingCode)
        {
            var settings = _context.K_Setting
                .Where(s => s.SettingCode == settingCode)
                .ToArray();
            if (settings.Length == 0)
            {
                throw new Exception($"Không tìm thấy setting với code: {settingCode}");
            }
            if (settings.Length != 1)
            {
                throw new Exception($"Tìm thấy nhiều hơn 1 setting với code: {settingCode}");
            }
            return settings[0];
        }
    }
    public class SettingCode
    {
        public static readonly string DuongDanBaoCao = "DuongDanBaoCao";
    }
}
