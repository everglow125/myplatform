using Common;
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
            string code = CaptchaHelper.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = CaptchaHelper.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        public ActionResult CheckImage(string txtCode)
        {
            var code = Session["ValidateCode"] as string;
            if (code == txtCode)
                return new ContentResult() { Content = "验证码正确" };
            else
                return new ContentResult() { Content = "验证码错误" };
        }
    }
}
