using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Model
{
    internal class ProcedureDefinition
    {
        public string Name { get; set; }
        public ProcedureParam ProcedureParam { get; set; }
    }
    internal class ProcedureParam
    {
        public string ParamName { get; set; }
        public string Type { get; set; }
    }
    internal class ProcedureParamEdit
    {
        public string Id { get; set; }
        public string NameShowLabel { get; set; }
        public string ParamName { get; set; }
        public string Type { get; set; }
        public string typeOfControlInput { get; set; }

        public string  typeOfItemSelect { get; set; }
        public string ParameterName { get; set; }

        public string ValueIntCheckBoxTrue { get; set; }
        public string ValueIntCheckBoxFalse { get; set; }
        public string ValueStringCheckBoxTrue { get; set; }
        public string ValueStringCheckBoxFalse { get; set; }
        public string TypeOfLoadItem { get; set; }
    }
    internal class GetItemSelectEdit
    {
        public int Id { get; set; }
        public string ValueItemString { get; set; }
        public int ValueItemInt { get; set; }
        public string ShowText { get; set; }
        public int NumericalOrder { get; set; }
        public int procedureParameterId { get; set; }
        public string QueryDatabase { get; set; }
        public string ColumnKey { get; set; }
        public string ColumnTextShow { get; set; }
        public int procedureParameterNumericalOrder { get; set; }
    }
}
