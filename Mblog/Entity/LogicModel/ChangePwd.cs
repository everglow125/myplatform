using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.LogicModel
{
    public class ChangePwd
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        [DisplayName("旧密码")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("新密码")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("确认密码")]
        [Compare("NewPassword")]
        public string ConfrimPassword { get; set; }
    }
}
