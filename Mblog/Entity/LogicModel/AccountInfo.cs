using System;
namespace Entity
{
	public partial class AccountInfo
	{
		/// <summary>
		/// 主键
		/// <summary>
		public int Id { get; set; }
		/// <summary>
		/// 账号 唯一
		/// <summary>
		public string Account { get; set; }
		/// <summary>
		/// 密码 MD5加密
		/// <summary>
		public string Password { get; set; }
		/// <summary>
		/// 注册邮箱 唯一
		/// <summary>
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
		public string NickName { get; set; }
		/// <summary>
		/// 自我介绍
		/// <summary>
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
