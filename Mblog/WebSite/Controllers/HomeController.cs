using Common;
using Entity;
using Entity.BaseModel;
using Entity.LogicModel;
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
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model, string returnUrl)
        {
            //if (file != null)
            //{
            //    var fileName = Path.Combine(Request.MapPath("~/Upload"), Path.GetFileName(file.FileName));
            //    FileInfo fileInfo = new FileInfo(fileName);
            //    if (!fileInfo.Directory.Exists)
            //        fileInfo.Directory.Create();
            //    file.SaveAs(fileName);
            //}
            if (!ModelState.IsValid)
                return View();
            AccountInfo user = new AccountInfo();
            user.Password = EncryptHelper.EncryptMD5(model.Password + "everglow");
            user.Account = model.Account;
            var account = new AccountInfoBll().Query(user);
            if (account == null)
            {
                return new ContentResult() { Content = "账号或密码错误！" };
            }
            else
            {
                Session["Account"] = account;
                if (string.IsNullOrEmpty(returnUrl))
                    return Redirect("Index");
                return Redirect(returnUrl);
            }
        }

        public ActionResult Index()
        {
            ViewBag.userInfo = Session["Account"];
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
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                model.NickName = "";
                model.Password = EncryptHelper.EncryptMD5(model.Password + "everglow");
                CacheHelper.Add<string>(model.Email + "_ActiveCode", Guid.NewGuid().ToString());
                var result = new AccountInfoBll().Insert(model) > 0;
                if (result)
                {
                    EmailInfo mail = new EmailInfo();
                    mail.Title = "MBlog-注册激活邮件";
                    mail.Content = "<a href=\"http://127.0.0.1/active/" + CacheHelper.Get<string>(model.Email + "_ActiveCode") + "\">去网站激活</a>";
                    mail.RecipientMail = model.Email;
                    EmailHelper.SendSysMail(mail);
                }
                return new ContentResult() { Content = result ? "成功" : "失败" };
            }
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPwd(string Account)
        {

            if (!string.IsNullOrEmpty(Account.Trim()))
            {
                var account = new AccountInfoBll().QueryByAccountOrEmail(Account);
                if (account == null) return View();
                EmailInfo mail = new EmailInfo();
                mail.Title = "MBlog-重置密码";
                mail.Content = "<a href=\"http://localhost:14561/Home/ChangePwd" + CacheHelper.Get<string>(account.Email + "_ActiveCode") + "\">如果不是本人操作,请忽略此邮件</a>";
                mail.RecipientMail = account.Email;
                EmailHelper.SendSysMail(mail);
            }
            return View();
        }

        [HttpGet]
        public ActionResult ForgetPwd()
        {
            return View();
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
