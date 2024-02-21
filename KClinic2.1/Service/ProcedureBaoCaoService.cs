using KClinic2._1.Contexts;
using KClinic2._1.Desktop;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Service
{
    public interface IProcedureBaoCaoService
    {
        ProcedureBaoCao GetBaoCaoByCode(string maBaoCao);
        ProcedureBaoCao GetBaoCaoById(int id);
        ProcedureBaoCao[] GetBaoCaosByUserId(int userId);
    }
    public class ProcedureBaoCaoService : IProcedureBaoCaoService
    {
        private static readonly KClinicContext _context = new KClinicContext();
        public ProcedureBaoCao GetBaoCaoByCode(string maBaoCao)
        {
            return _context.ProcedureBaoCao
                .Where(p => p.MaBaoCao == maBaoCao)
                .First();
        }

        public ProcedureBaoCao GetBaoCaoById(int id)
        {
            return _context.ProcedureBaoCao
                .Include(p => p.ProcedureParameter)
                .Where(p => p.Id == id)
                .First();
        }

        public ProcedureBaoCao[] GetBaoCaosByUserId(int userId)
        {
            return _context.ProcedureBaoCao
                .Include(p => p.ProcedureParameter)
                .Include(p => p.ProcedureParameter.Select(pp => pp.ItemSelect))
                .Where(p => p.K_Permission_Report
                        .Select(pr => pr.User_Id)
                        .Contains(userId))
                .Where(p => p.TamNgung == 0 && p.Huy == 0)
                .ToArray();
        }
    }
}
