using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;

namespace KClinic2._1.Service
{
    public class ExcelService
    {
        private static readonly SettingService settingService = new SettingService();
        private static readonly ProcedureBaoCaoService procedureBaoCaoService = new ProcedureBaoCaoService();
        public static void Run(string maBaoCao, string filePath, DataTable dt, Dictionary<string,object> procedureParams)
        {
            // The path to the template file.
            string templatePath = settingService.GetSettingBySettingCode(SettingCode.DuongDanBaoCao).NoiDung;
            string baoCaoName = procedureBaoCaoService.GetBaoCaoByCode(maBaoCao).ExcelTemplateName;
            // Open a designer workbook
            WorkbookDesigner designer = new WorkbookDesigner();

            // Get worksheet Cells collection
            designer.Workbook = new Workbook($"{templatePath}{baoCaoName}.xlsx");
            var dataview = new DataView(dt);
            designer.SetDataSource("Data", dataview);
            foreach (var key in procedureParams.Keys)
            {
                object value;
                if (procedureParams.TryGetValue(key, out value))
                {
                    designer.SetDataSource(key, value);
                }
            }
            designer.LineByLine = false;
            // Process designer
            designer.Process(false);
            designer.Workbook.Worksheets[0].AutoFitColumns();
            designer.Workbook.Save(filePath, SaveFormat.Xlsx);
        }
    }
}
