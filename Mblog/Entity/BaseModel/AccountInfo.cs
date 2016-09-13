using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity.BaseModel
{
    [Serializable]
    public partial class AccountInfo
    {
        /// <summary>
        /// 主键
        /// <summary>
        public int Id { get; set; }
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
        [MinLength(8)]
        public string Password { get; set; }
        [DisplayName("确认密码")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// 注册邮箱 唯一
        /// <summary>
        [DisplayName("注册邮箱")]
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// 状态 [0]未激活 [1]正常 [2]禁用
        /// <summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// <summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 昵称
        /// <summary>
        [DisplayName("昵称")]
        public string NickName { get; set; }
        /// <summary>
        /// 自我介绍
        /// <summary>
        [DisplayName("自我介绍")]
        public string Description { get; set; }
        /// <summary>
        /// 头像地址
        /// <summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 上次登录IP
        /// <summary>
        public string LastLoginIP { get; set; }
    }
}
