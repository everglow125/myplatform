using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;
using Dapper;
namespace DataBase
{
    public class DapperHelper
    {
        private static string cnnstr;

        public DapperHelper()
        {
            cnnstr = ConfigurationManager.AppSettings["ConnectionString"] ?? @"Data Source=SZC062\SQLEXPRESS;Initial Catalog=Mblog;User Id=sa;Password=123456;";
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection cnn = new SqlConnection(cnnstr);
            cnn.Open();
            return cnn;
        }


        public static int ExecuteNonQuery(string sql, object param)
        {
            using (var con = GetConnection())
            {
                int i = con.Execute(sql, param);
                return i;
            }
        }


        public static int ExecuteTranSql(string sql, object param)
        {
            using (var con = GetConnection())
            {
                SqlTransaction trans = con.BeginTransaction();
                int result = con.Execute(sql, param, transaction: trans);
                trans.Commit();
                return result;
            }

        }

        public static T ExecuteScalar<T>(string sql, object param)
        {
            using (var con = GetConnection())
            {
                T result = con.Query<T>(sql, param).FirstOrDefault<T>();
                return result;
            }
        }

        public static IList<T> ExecuteList<T>(string sql, object param)
        {
            using (var con = GetConnection())
            {
                IEnumerable<T> result = con.Query<T>(sql, param);
                return result.ToList<T>();
            }
        }

        public static IList<T> ExecuteList<T>(string sql, object param, int pageIndex = 0, int pageSize = 20)
        {
            using (var con = GetConnection())
            {
                var skip = (pageIndex - 1) * pageSize;
                var take = pageSize;
                IEnumerable<T> result = con.Query<T>(sql, param).Skip(skip).Take(take);
                return result.ToList<T>();
            }
        }


        public static int ExecuteNoneQueryByProcedure(string proName, object param)
        {
            using (var con = GetConnection())
            {
                int result = con.Execute(proName, param, CommandType.StoredProcedure);
                return result;
            }
        }

        public static IList<T> ExceteListByProcedure<T>(string proName, object param)
        {
            using (var con = GetConnection())
            {
                IEnumerable<T> result = con.Query<T>(proName, param, CommandType.StoredProcedure);
                return result.ToList<T>();
            }
        }

        public static IList<T> ExceteListByProcedure<T>(string proName, object param, out T Total, out int Count)
        {
            using (var con = GetConnection())
            {
                var result = con.QueryMultiple(proName, param, CommandType.StoredProcedure);
                var list = result.Read<T>().ToList();
                Count = result.Read<int>().Single();
                Total = result.Read<T>().Single();
                return list;
            }
        }

        public static T ExecuteScalarByProcedure<T>(string proName, object param)
        {
            using (var con = GetConnection())
            {
                T result = con.Query<T>(proName, param, CommandType.StoredProcedure).FirstOrDefault();
                return result;
            }
        }

    }
}
