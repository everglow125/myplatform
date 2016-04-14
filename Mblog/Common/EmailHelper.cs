
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public class EmailHelper
    {
        public static void SendEmail(EmailInfo mail)
        {
            MailAddress from = new MailAddress(mail.SenderMail, mail.NickName);
            MailAddress to = new MailAddress(mail.RecipientMail);
            using (MailMessage mailmessage = new MailMessage(from, to))
            {
                mailmessage.Subject = mail.Title;
                mailmessage.Body = mail.Content;
                mailmessage.BodyEncoding = System.Text.Encoding.Default;
                mailmessage.IsBodyHtml = true;
                mailmessage.Priority = MailPriority.Normal;
                mailmessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                using (SmtpClient client = new SmtpClient(mail.StmpServer))
                {
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = mail.EnableSSL;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential(mail.MailAccount, mail.MailPassword);
                    client.Send(mailmessage);
                }
            }
        }
        public static void SendSysMail(EmailInfo mail)
        {
            mail.EnableSSL = true;
            mail.StmpServer = ConfigurationManager.AppSettings["stmpServer"];
            mail.MailAccount = ConfigurationManager.AppSettings["mailAccount"];
            mail.MailPassword = ConfigurationManager.AppSettings["mailPassword"];
            mail.NickName = ConfigurationManager.AppSettings["nickName"];
            mail.SenderMail = ConfigurationManager.AppSettings["senderMail"];
            SendEmail(mail);
        }
    }

    public class EmailInfo
    {
        /// <summary>
        /// 发件人邮箱
        /// </summary>
        public string SenderMail { get; set; }
        /// <summary>
        /// 发件人署名
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 收件人邮箱
        /// </summary>
        public string RecipientMail { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// STMP服务器 如smtp.163.com
        /// </summary>
        public string StmpServer { get; set; }
        /// <summary>
        /// 发件人邮箱账号 @前面部分
        /// </summary>
        public string MailAccount { get; set; }
        /// <summary>
        /// 发件人邮箱密码  明文
        /// </summary>
        public string MailPassword { get; set; }
        /// <summary>
        /// 是否需要SSL加密 
        /// </summary>
        public bool EnableSSL { get; set; }
    }
}
