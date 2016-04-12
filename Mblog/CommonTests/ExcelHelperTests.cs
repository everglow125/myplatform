using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
namespace Common.Tests
{
    [TestClass()]
    public class ExcelHelperTests
    {
        [TestMethod()]
        public void SaveToServerTest()
        {
            DataTable dt = new DataTable();
            var temp = ExcelHelper.SaveToServer(dt, @"F:\迅雷下载\财务分析_20160406170847.xls");
            Assert.AreEqual(true, temp);
        }

        [TestMethod()]
        public void ReadExcelTest()
        {
            var dt = ExcelHelper.ReadExcel(@"F:\迅雷下载\财务分析_20160406173424.xls");
            Assert.AreNotEqual(0, dt.Rows.Count);
        }
    }
}
