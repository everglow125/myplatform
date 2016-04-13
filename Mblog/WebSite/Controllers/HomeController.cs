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
            return new ContentResult() { Content = new AccountInfoBll().Insert(model) > 0 ? "成功" : "失败" };
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
    }
}
