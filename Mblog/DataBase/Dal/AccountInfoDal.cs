using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Dal
{
    public class AccountInfoDal
    {
        public int Insert(AccountInfo entity)
        {
            string sql =
                        @"INSERT INTO dt_Account
                                   (NickName
                                   ,Email
                                   ,Account
                                   ,[Password]
                                   ,CreateTime
                                   ,[Status])
                             VALUES
                                   (@NickName
                                   ,@Email
                                   ,@Account
                                   ,@Password
                                   ,GETDATE()
                                   ,@Status)";
            return DapperHelper.ExecuteNonQuery(sql, entity);
        }
    }
}
