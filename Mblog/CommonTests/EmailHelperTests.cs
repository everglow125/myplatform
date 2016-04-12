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
    public class EmailHelperTests
    {
        [TestMethod()]
        public void SendEmailTest()
        {
            EmailInfo mail = new EmailInfo()
            {
                Content = "测试邮件发送",
                MailAccount = "liaojin_work",
                MailPassword = "********",
                EnableSSL = false,
                NickName = "测试账号",
                RecipientMail = "183900112@qq.com",
                SenderMail = "liaojin_work@163.com",
                StmpServer = "smtp.163.com",
                Title = "测试邮件请勿回复"

            };
            EmailHelper.SendEmail(mail);
        }
    }
}
