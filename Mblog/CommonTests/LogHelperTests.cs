using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Common.Tests
{
    [TestClass()]
    public class LogHelperTests
    {
        [TestMethod()]
        public void ErrorLogTest()
        {
            try { int a = Convert.ToInt32("aaa"); }
            catch (Exception ex)
            {
                LogHelper.ErrorLog("test", ex);
            }
            Assert.Fail();
        }
    }
}
