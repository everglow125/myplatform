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
    public class DataTableExtensionTests
    {
        [TestMethod()]
        public void ReversalRowsTest()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("姓名");
            dt.Columns.Add("学科");
            dt.Columns.Add("成绩");

            DataRow dr = dt.NewRow();
            dr["姓名"] = "张三";
            dr["学科"] = "语文";
            dr["成绩"] = 90;
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["姓名"] = "张三";
            dr1["学科"] = "数学";
            dr1["成绩"] = 70;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["姓名"] = "李四";
            dr2["学科"] = "英语";
            dr2["成绩"] = 90;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["姓名"] = "王五";
            dr3["学科"] = "化学";
            dr3["成绩"] = 88;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["姓名"] = "朱六";
            dr4["学科"] = "政治";
            dr4["成绩"] = 90;
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["姓名"] = "朱六";
            dr5["学科"] = "语文";
            dr5["成绩"] = 66;
            dt.Rows.Add(dr5);

            var result = dt.ReversalRows("姓名", "学科", "成绩");
            var result1 = dt.ReversalRows("学科", "姓名", "成绩");
            Assert.AreNotEqual(dt, result);
        }

        [TestMethod()]
        public void ReversalRowsTest1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("姓名");
            dt.Columns.Add("数学");
            dt.Columns.Add("语文");
            dt.Columns.Add("英语");

            DataRow dr = dt.NewRow();
            dr["姓名"] = "乔峰";
            dr["数学"] = 99;
            dr["语文"] = 99;
            dr["英语"] = 99;
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["姓名"] = "段誉";
            dr1["数学"] = 90;
            dr1["语文"] = 80;
            dr1["英语"] = 80;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["姓名"] = "虚竹";
            dr2["数学"] = 70;
            dr2["语文"] = 90;
            dr2["英语"] = 60;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["姓名"] = "慕容";
            dr3["数学"] = 95;
            dr3["语文"] = 60;
            dr3["英语"] = 70;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["姓名"] = "李寻欢";
            dr4["数学"] = 100;
            dr4["语文"] = 100;
            dr4["英语"] = 100;
            dt.Rows.Add(dr4);

            var result = dt.ReversalRows("学科");

            Assert.AreNotEqual(dt, result);
        }
    }
}
