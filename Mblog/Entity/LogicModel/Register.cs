using Entity.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.LogicModel
{
    public class Register : AccountInfo
    {
        /// <summary>
        /// 验证码
        /// <summary>
        [DisplayName("验证码")]
        [Required]
        public string Captcha { get; set; }

        [DisplayName("确认密码")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
