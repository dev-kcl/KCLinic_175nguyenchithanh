using KClinic2._1.Contexts;
using KClinic2._1.Desktop;
using KClinic2._1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Service
{
    public interface ICLSSerivce
    {
        K_CLSYeuCau[] SearchCLSChuaThucHien(CLSSearchCriteria searchCriteria);
    }
    public class CLSSerivce : ICLSSerivce
    {
        private static readonly KClinicContext _context = new KClinicContext();
        public K_CLSYeuCau[] SearchCLSChuaThucHien(CLSSearchCriteria searchCriteria)
        {
            return _context.K_CLSYeuCau.ToArray();
        }
    }
}
