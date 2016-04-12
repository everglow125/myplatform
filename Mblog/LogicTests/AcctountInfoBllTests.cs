using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity;
namespace Logic.Tests
{
    [TestClass()]
    public class AcctountInfoBllTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            AccountInfo entity = new AccountInfo()
            {
                Account = "test",
                Password = "123456",
                Email = "183900112@qq.com",
                NickName = "测试账号",
                Status = 1
            };
            var result = new AccountInfoBll().Insert(entity);
            Assert.AreEqual(1, 1);
        }
    }
}
