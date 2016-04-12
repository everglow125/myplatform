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
    public class EncryptHelperTests
    {
        [TestMethod()]
        public void MD5EncryptTest()
        {
            string result = EncryptHelper.EncryptMD5("7890123mblog", Encoding.UTF8).ToUpper();
            Assert.AreEqual(result, "322D9AE6F6D55D7F5CD75F56DDF6D172");
        }

        [TestMethod()]
        public void DES3EncryptTest()
        {
            string result = EncryptHelper.Encrypt3DES("123456", "test123456test123456test");
            Assert.AreEqual(result, "rDeEUyI53MA=");
        }

        [TestMethod()]
        public void DES3DEncryptTest()
        {
            string result = EncryptHelper.Decrypt3DES("rDeEUyI53MA=", "test123456test123456test");
            Assert.AreEqual(result, "123456");
        }
    }
}
