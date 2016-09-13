using System;
namespace Entity
{
    public partial class ReadingNotes
    {
        /// <summary>
        /// 主键
        /// <summary>
        public int Id { get; set; }
        /// <summary>
        /// 图书Id
        /// <summary>
        public string BookId { get; set; }
        /// <summary>
        /// 账号Id
        /// <summary>
        public int AccountId { get; set; }
        /// <summary>
        /// 添加时间
        /// <summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 状态 [0]正常 [1]删除
        /// <summary>
        public int Status { get; set; }
        /// <summary>
        /// 标题
        /// <summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// <summary>
        public string Content { get; set; }
        /// <summary>
        /// 浏览次数
        /// <summary>
        public int ReadCount { get; set; }
        /// <summary>
        /// 赞同数
        /// <summary>
        public int AgreeCount { get; set; }
        /// <summary>
        /// 反对数
        /// <summary>
        public int AgainstCount { get; set; }
        /// <summary>
        /// 是否公开可见
        /// <summary>
        public bool IsPublic { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime ModifyTime { get; set; }
    }
}
