using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Model
{
    public class ProcedureParameter
    {
        public int Id { get; set; }
        public int NumericalOrder { get; set; }
        public string ParameterName { get; set; }
        public string NameShowLabel { get; set; }
        public int TypeOfItemSelect { get; set; }
        //0 null, 1 string, 2 int,
        public int TypeOfLoadItem { get; set; }
        // 1 fix static, 2 load database
        public int ProcedureBaoCaoId { get; set; }
        public int TypeOfControlInputId { get; set; }
        public int? ValueIntCheckBoxTrue { get; set; }
        public int? ValueIntCheckBoxFalse { get; set; }
        public string ValueStringCheckBoxTrue { get; set; }
        public string ValueStringCheckBoxFalse { get; set; }
        public string OutputValue { get; set; }
    }
}
