using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;

namespace JiaJiBLL
{
    public  class adloginBll
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
                return new JiaJiDAL.AdloginDal().AdNameIsExist(adname);
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
        public int NamePwdIsExist(string adname, string adpwd)
        {
            try
            {
                return new JiaJiDAL.AdloginDal().NamePwdIsExist(adname, adpwd);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




    }
}
