using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Common.Tests
{
    public enum OrderStateEnum
    {
        [System.ComponentModel.Description("未开始")]
        Ready = 0,

        [System.ComponentModel.Description("进行中")]
        Processing,

        [System.ComponentModel.Description("等待中")]
        Waiting,

        [System.ComponentModel.Description("取消")]
        Canceled,

        [System.ComponentModel.Description("完成")]
        Finished
    }
    [TestClass()]
    public class EnumHelperTests
    {
        [TestMethod()]
        public void GetAllItemsTest()
        {
            var temp = EnumHelper.GetAllItems(typeof(OrderStateEnum));
            Assert.AreNotEqual(5, temp.Count);
        }

        [TestMethod()]
        public void GetDescriptionByNameTest()
        {
            var temp = EnumHelper.GetDescription<OrderStateEnum>(OrderStateEnum.Ready);
            Assert.AreEqual("未开始", temp);
        }

        [TestMethod()]
        public void GetNameTest()
        {
            var temp = EnumHelper.GetName<OrderStateEnum>(0);
            Assert.AreEqual("Ready", temp);
        }

        [TestMethod()]
        public void GetEnumTest()
        {
            var temp1 = EnumHelper.GetEnum<OrderStateEnum>("Ready");
            var temp2 = EnumHelper.GetEnum<OrderStateEnum>(0);
            Assert.AreEqual(temp1, temp2);
        }

        [TestMethod()]
        public void IncloudTest()
        {
            var temp1 = EnumHelper.Incloud<OrderStateEnum>(100);
            Assert.AreEqual(false, temp1);
        }
    }
}
