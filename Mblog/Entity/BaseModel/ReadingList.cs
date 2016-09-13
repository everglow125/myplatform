using System;
namespace Entity
{
	public partial class ReadingList
	{
		/// <summary>
		/// 主键
		/// <summary>
		public int Id { get; set; }
		/// <summary>
		/// 用户Id
		/// <summary>
		public int AccountId { get; set; }
		/// <summary>
		/// 书籍Id
		/// <summary>
		public int BookId { get; set; }
		/// <summary>
		/// 创建时间
		/// <summary>
		public DateTime CreateTime { get; set; }
		/// <summary>
		/// 读书状态 [0]未读 [1]正在阅读 [
		/// <summary>
		public int ReadStatus { get; set; }
		/// <summary>
		/// 状态 [0]正常 [1]删除
		/// <summary>
		public int Status { get; set; }
		/// <summary>
		/// 计划阅读开始时间
		/// <summary>
		public DateTime PredictReadTimeBegin { get; set; }
		/// <summary>
		/// 计划阅读结束时间
		/// <summary>
		public DateTime PredictReadTimeEnd { get; set; }
		/// <summary>
		/// 实际阅读开始时间
		/// <summary>
		public DateTime ReadTimeBegin { get; set; }
		/// <summary>
		/// 实际阅读结束时间
		/// <summary>
		public DateTime ReadTimeEnd { get; set; }
		/// <summary>
		/// 分类
		/// <summary>
		public string Category { get; set; }
		/// <summary>
		/// 进度
		/// <summary>
		public int Proportion { get; set; }
	}
}
