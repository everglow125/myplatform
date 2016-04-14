using Common;
using Entity;
using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login(AccountInfo model)
        {
            model.Password = EncryptHelper.EncryptMD5(model.Password + "everglow");
            var account = new AccountInfoBll().Query(model);
            if (account == null)
            {
                return new ContentResult() { Content = "账号或密码错误！" };
            }
            else
            {
                Session["Account"] = account;
                return new ContentResult() { Content = "登录成功" };
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetValidateCode()
        {
            string code = CaptchaHelper.CreateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = CaptchaHelper.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        public ActionResult CheckImage(string txtCode)
        {
            var code = Session["ValidateCode"] as string;
            if (code.ToLower() == txtCode.ToLower())
                return new ContentResult() { Content = "验证码正确" };
            else
                return new ContentResult() { Content = "验证码错误" };
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountInfo model)
        {
            model.Password = EncryptHelper.EncryptMD5(model.Password + "everglow");
            var result = new AccountInfoBll().Insert(model) > 0;
            if (result)
            {
                EmailInfo mail = new EmailInfo();
                mail.Title = "MBlog-注册激活邮件";
                mail.Content = "<a href=\"http://127.0.0.1/active/code\">去网站激活</a>";
                mail.RecipientMail = model.Email;
                EmailHelper.SendSysMail(mail);
            }
            return new ContentResult() { Content = result ? "成功" : "失败" };
        }

        public ActionResult EditTest()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditTest(string mycontent)
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FileUpload(string mycontent)
        {
            return View();
        }
    }
}
