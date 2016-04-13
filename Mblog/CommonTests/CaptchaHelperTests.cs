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
    public class CaptchaHelperTests
    {
        [TestMethod()]
        public void CreateCodeTest()
        {
            string temp = CaptchaHelper.CreateCode(5);
            Assert.AreNotEqual("",temp);
        }
    }
}
