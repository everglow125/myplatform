using System;
namespace Entity
{
	public partial class ActionInfo
	{
		/// <summary>
		/// 主键
		/// <summary>
		public long Id { get; set; }
		/// <summary>
		/// 用户
		/// <summary>
		public int AccountId { get; set; }
		/// <summary>
		/// 操作类型
		/// <summary>
		public int ActionType { get; set; }
		/// <summary>
		/// 添加时间
		/// <summary>
		public DateTime CreateTime { get; set; }
		/// <summary>
		/// IP地址
		/// <summary>
		public string IP { get; set; }
	}
}
