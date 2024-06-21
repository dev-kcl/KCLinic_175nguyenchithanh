using System.Collections;
using Aspose.Cells;
using System.Data;

namespace ExportListDataToExcelInCSharp
{
    public class XuatExcelXetNghiem
    {
        public static void Run(DataTable dt,string filePath)
        {
            // Instantiating a Workbook object
            Workbook workbook = new Workbook();

            // Obtaining the reference of the worksheet
            Worksheet worksheet = workbook.Worksheets[0];

            // Instantiating an ArrayList object
            var dataview = new DataView(dt);
            for (int i = 0; i < dataview.Table.Columns.Count; i++)
            {
                worksheet.Cells[0, i].PutValue(dataview.Table.Columns[i].ColumnName);
            }

            // Exporting the contents of ArrayList vertically at the first row and first column of the worksheet. 
            worksheet.Cells.ImportDataView(dataview, 1, 0, true);

            // Saving the Excel file
            worksheet.Workbook.Save(filePath, SaveFormat.Xlsx);
        }
    }
}