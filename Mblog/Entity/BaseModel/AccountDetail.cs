using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BaseModel
{
    public class AccountDetail : AccountInfo
    {
        /// <summary>
        /// 自我介绍
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 兴趣
        /// </summary>
        public string Interest { get; set; }

    }
}
