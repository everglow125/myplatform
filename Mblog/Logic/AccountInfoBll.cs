using DataBase.Dal;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AccountInfoBll
    {
        public static AccountInfoDal dal = new AccountInfoDal();
        public int Insert(AccountInfo entity)
        {
            return dal.Insert(entity);
        }
    }
}
