using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Model
{
    public class ItemSelect
    {
        public int Id { get; set; }
        public int NumericalOrder { get; set; }

        public string ValueItemString { get; set; }
        public int? ValueItemInt { get; set; }
        public string ShowText { get; set; }
        public int procedureParameterId { get; set; }

        public string QueryDatabase { get; set; }

        public string ColumnKey { get; set; }

        public string ColumnTextShow { get; set; }


        public int procedureParameterNumericalOrder { get; set; }


    }
}
