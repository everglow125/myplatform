using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BaseModel
{
    /// <summary>
    /// 抽奖奖品
    /// </summary>
    public class LotteryAward
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 奖品名称
        /// </summary>
        public string AwardName { get; set; }
        /// <summary>
        /// 奖品数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 中奖率
        /// </summary>
        public double Odds { get; set; }
        /// <summary>
        /// 状态 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime CtreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public int ModifyBy { get; set; }
        /// <summary>
        /// 转盘位置
        /// </summary>
        public int Location { get; set; }
        /// <summary>
        /// 间隔周期 小时单位
        /// </summary>
        public int Interval { get; set; }
        /// <summary>
        /// 下一次出现奖品时间  防止中奖率估算错误导致大将快速抽完
        /// </summary>
        public DateTime NextUptime { get; set; }
    }
}
