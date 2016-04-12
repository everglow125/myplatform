
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DataTableExtension
    {
        /// <summary>
        /// 关系表转 行列对应表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toColumn">该列值转成列名</param>
        /// <param name="toRow">该列名转成行值</param>
        /// <param name="value">该列为行列对应值</param>
        /// <returns></returns>
        public static DataTable ReversalRows(this DataTable dt, string toColumn, string toRow, string value)
        {
            DataTable result = new DataTable();
            result.Columns.Add(toRow);
            List<string> rows = new List<string>();
            List<string> columns = new List<string>();
            Dictionary<string, int> cells = new Dictionary<string, int>();
            int rowIndex = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var columnName = dt.Rows[i][toColumn].ToString();
                if (!result.Columns.Contains(columnName))
                {
                    result.Columns.Add(columnName);
                    columns.Add(columnName);
                }

                var rowValue = dt.Rows[i][toRow].ToString();
                if (!rows.Contains(rowValue))
                {
                    rows.Add(rowValue);
                    cells.Add(rowValue, rowIndex++);
                }
            }
            foreach (var item in rows)
            {
                DataRow dr = result.NewRow();
                dr[toRow] = item;
                result.Rows.Add(dr);
            }

            foreach (DataRow dr in dt.Rows)
            {
                var rowNum = cells[dr[toRow].ToString()];
                var columnName = dr[toColumn].ToString();
                result.Rows[rowNum][columnName] = dr[value].ToString();
            }
            return result;
        }

        /// <summary>
        /// 将第一列转为行
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fixedColumnName">列名转成行以后所属的列名</param>
        /// <returns></returns>
        public static DataTable ReversalRows(this DataTable dt, string fixedColumnName)
        {
            DataTable result = new DataTable();
            result.Columns.Add(fixedColumnName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Columns.Add(dt.Rows[i][0].ToString());
            }
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                DataRow dr = result.NewRow();
                dr[0] = dt.Columns[i].ColumnName;
                result.Rows.Add(dr);
            }
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    result.Rows[j - 1][i] = dt.Rows[i - 1][j];
                }
            }
            return result;
        }
    }

}
