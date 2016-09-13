using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BaseModel
{
    /// <summary>
    /// 抽奖记录表
    /// </summary>
    public class LotteryAction
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 奖品Id
        /// </summary>
        public int AwardId { get; set; }
        /// <summary>
        /// 奖品名称
        /// </summary>
        public string AwardName { get; set; }
        /// <summary>
        /// 抽奖人Id
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 中奖人名字
        /// </summary>
        public string WinnerName { get; set; }
        /// <summary>
        /// 是否中奖
        /// </summary>
        public bool IsWinning { get; set; }
        /// <summary>
        /// 抽奖时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 抽奖IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 消耗积分
        /// </summary>
        public int DedcutPoint { get; set; }


    }
}
