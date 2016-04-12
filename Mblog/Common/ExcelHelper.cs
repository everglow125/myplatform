using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common
{
    public class ExcelHelper
    {
        public static FileResult ExportByBrower(DataTable table, string fileName)
        {
            var book = new HSSFWorkbook();
            var ms = TableToStream(table);
            FileStreamResult flr;
            book.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            flr = new FileStreamResult(ms, "application/vnd.ms-excel")
            {
                FileDownloadName = fileName
            };
            return flr;
        }

        public static bool SaveToServer(DataTable table, string fileName)
        {
            try
            {
                var book = new HSSFWorkbook();
                var ms = TableToStream(table);

                var fl = new FileInfo(fileName);
                if (!fl.Directory.Exists)
                    fl.Directory.Create();

                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private double GetCellValue(ICell cell)
        {
            if (cell.CellType == CellType.Numeric)
                return cell.NumericCellValue;
            return Convert.ToDouble(string.IsNullOrEmpty(cell.StringCellValue) ? "0" : cell.StringCellValue);
        }

        private ICellStyle CreateStyle(IWorkbook book, short backColor, short fontColor = NPOI.HSSF.Util.HSSFColor.Black.Index, short bold = (short)NPOI.SS.UserModel.FontBoldWeight.Normal)
        {
            ICellStyle source = book.CreateCellStyle();
            source.Alignment = HorizontalAlignment.Center;
            source.BorderDiagonalColor = 0;
            source.FillBackgroundColor = 67;
            source.FillForegroundColor = backColor;
            source.FillPattern = FillPattern.SolidForeground;
            source.Indention = 0;
            source.VerticalAlignment = VerticalAlignment.Center;

            IFont font = book.CreateFont();
            font.Color = fontColor;
            font.FontName = "微软雅黑";
            font.FontHeightInPoints = 9;
            font.Boldweight = bold;
            source.SetFont(font);
            return source;
        }

        private void InsertRow(ISheet sheet, int insertIndex, int rowCount, IRow preRow)
        {
            sheet.ShiftRows(insertIndex, sheet.LastRowNum, rowCount, true, false);

            for (int i = insertIndex; i < insertIndex + rowCount - 1; i++)
            {
                IRow targetRow = null;
                ICell sourceCell = null;
                ICell targetCell = null;
                targetRow = sheet.CreateRow(i + 1);
                for (int m = preRow.FirstCellNum; m < preRow.LastCellNum; m++)
                {
                    sourceCell = preRow.GetCell(m);
                    if (sourceCell == null)
                        continue;
                    targetCell = targetRow.CreateCell(m);
                    targetCell.SetCellValue("");
                }
            }

            IRow firstTargetRow = sheet.CreateRow(insertIndex);
            ICell firstSourceCell = null;
            ICell firstTargetCell = null;
            for (int m = preRow.FirstCellNum; m < preRow.LastCellNum; m++)
            {
                firstSourceCell = preRow.GetCell(m);
                if (firstSourceCell == null)
                    continue;
                firstTargetCell = firstTargetRow.CreateCell(m);
                firstTargetCell.SetCellValue(firstSourceCell.StringCellValue);
                firstSourceCell.SetCellValue("");
            }
        }

        private static CellType DataTypeToCellType(Type _type)
        {
            if (_type == typeof(int) || _type == typeof(double) || _type == typeof(decimal) || _type == typeof(float) || _type == typeof(long))
            {
                return CellType.Numeric;
            }
            return CellType.String;
        }

        private static void CreateSheet(IWorkbook workbook, string sheetName, DataTable source)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow rowHeader = sheet.CreateRow(0);
            DataColumn col = null;
            Dictionary<int, CellType> cellTypes = new Dictionary<int, CellType>();
            for (int i = 0; i < source.Columns.Count; i++)
            {
                col = source.Columns[i];
                rowHeader.CreateCell(i, CellType.String).SetCellValue(col.ColumnName);
                cellTypes.Add(i, DataTypeToCellType(source.Columns[i].DataType));
            }
            IRow row = null;
            for (int i = 0; i < source.Rows.Count; i++)
            {
                row = sheet.CreateRow(i + 1);//创建内容行     
                for (int j = 0; j < source.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j, cellTypes[j]);
                    if (cellTypes[j] == CellType.Numeric && !String.IsNullOrEmpty(source.Rows[i][j].ToString()))
                        cell.SetCellValue(Convert.ToDouble(source.Rows[i][j]));
                    else
                        cell.SetCellValue(source.Rows[i][j].ToString());
                }
            }
        }

        private static MemoryStream TableToStream(DataTable dt)
        {
            if (dt == null)
                return null;
            HSSFWorkbook workbook = new HSSFWorkbook();
            CreateSheet(workbook, "sheet0", dt);
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            return ms;
        }

        public static DataTable ReadExcel(Stream fileStream)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(fileStream);
            ISheet sheet = workbook.GetSheetAt(0);
            DataTable table = new DataTable();
            IRow headerRow = sheet.GetRow(0);

            int columnsCount = headerRow.LastCellNum;
            for (int i = headerRow.FirstCellNum; i < columnsCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowsCount = sheet.LastRowNum;
            for (int i = (sheet.FirstRowNum + 1); i < rowsCount; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                for (int j = row.FirstCellNum; j < columnsCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }

        public static DataTable ReadExcel(string filePath)
        {
            DataTable result = new DataTable();
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                result = ReadExcel(file);
            }
            return result;
        }
    }
}
