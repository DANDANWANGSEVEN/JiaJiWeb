using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JiaJiNewWeb.Common;
namespace JiaJiNewWebDAL
{
   public class SolutionDAL:JiaJiNewWebIDAL.ISolutionDAL
    {

        /// <summary>
        /// 首页显示解决方案的信息的信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Solution> SolutionIndexList()
        {


            try
            {
                string sql = "select  * from Solution ORDER BY solutionID  DESC LIMIT 5";

                List<JiaJiNewWebModel.Solution> list = MySqlDB.GetList<JiaJiNewWebModel.Solution>(sql, CommandType.Text, null);
                Log4netHelper.WriteLog("系统日志，请求了SolutionDAL类下的SolutionIndexList方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;

            }


        }


        /// <summary>
        /// 首页显示解决方案步骤
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Solution_BuZhou> SolutionBuZhouList()
        {


            try
            {
                string sql = "select  SolutionBuZhouID,SolutionBuZhou from solution_buzou ORDER BY SolutionBuZhouID  DESC LIMIT 8";

                List<JiaJiNewWebModel.Solution_BuZhou> list = MySqlDB.GetList<JiaJiNewWebModel.Solution_BuZhou>(sql, CommandType.Text, null);
                Log4netHelper.WriteLog("系统日志，请求了SolutionDAL类下的SolutionIndexList方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;

            }
        }

    }
}
