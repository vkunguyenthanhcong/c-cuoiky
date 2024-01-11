using System;
using System.Data;
using ClosedXML.Excel;

namespace BLL
{
    public class YourExcelReader
    {
        public static DataTable ReadData(string filePath)
        {
            var dataTable = new DataTable();

            using (var workBook = new XLWorkbook(filePath))
            {
                var workSheet = workBook.Worksheet(1); // Assuming data is on the first worksheet

                // Assuming the first row contains column headers
                var firstRow = workSheet.FirstRowUsed();
                foreach (var cell in firstRow.CellsUsed())
                {
                    if (!string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        dataTable.Columns.Add(cell.Value.ToString());
                    }
                }

                // Add data rows
                var rows = workSheet.RowsUsed().Skip(1); // Skip the header row
                foreach (var row in rows)
                {
                    var dataRow = dataTable.NewRow();
                    for (int i = 0; i < row.CellCount(); i++)
                    {
                        dataRow[i] = row.Cell(i + 1).Value.ToString();
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
