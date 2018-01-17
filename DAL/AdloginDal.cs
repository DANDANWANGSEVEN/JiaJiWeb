using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JiaJiDAL;

namespace JiaJiDAL
{
    public class AdloginDal
    {
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="adname"></param>
        /// <returns></returns>
        public int AdNameIsExist(string adname)
        {
            try
            {
                string sql = "select count(1) from adlogin where AdName='"+adname+"'";
                int h = MySqlDB.scalar(sql, CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 判断用户名和密码
        /// </summary>
        /// <param name="adname"></param>
        /// <param name="adpwd"></param>
        /// <returns></returns>
        public int NamePwdIsExist(string adname,string adpwd)
        {
            try
            {
                string sql = "select count(1) from adlogin where AdName='" + adname + "' and AdPwd='"+ adpwd + "' ";
                int h = MySqlDB.scalar(sql, CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




    }
}
