using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.LogicModel
{
    public class Login
    {
        /// <summary>
        /// 验证码
        /// <summary>
        [DisplayName("验证码")]
        [Required]
        public string Captcha { get; set; }
        /// <summary>
        /// 账号 唯一
        /// <summary>
        [DisplayName("登录名")]
        [Required]
        public string Account { get; set; }
        /// <summary>
        /// 密码 MD5加密
        /// <summary>
        [DisplayName("登录密码")]
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        /// <summary>
        /// 记住密码
        /// </summary>
        [DisplayName("记住密码")]
        public bool RemenberMe { get; set; }
    }
}
