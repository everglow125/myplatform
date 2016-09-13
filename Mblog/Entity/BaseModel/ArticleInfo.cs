using System;
namespace Entity
{
    public partial class ArticleInfo
    {
        /// <summary>
        /// 
        /// <summary>
        public long Id { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int Status { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int ReadCount { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int ViewEnable { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public int ReplyCount { get; set; }
        /// <summary>
        /// 
        /// <summary>
        public string LastReadTime { get; set; }
    }
}
