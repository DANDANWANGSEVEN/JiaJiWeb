using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace JiaJiDAL
{
   public class solutiondal
    {
        /// <summary>
        /// 解决方案添加
        /// </summary>
        /// <param name="sol"></param>
        /// <returns></returns>
        public int soladd(JiaJiModels.solution sol)
        {
            try
            {
                string sql = "insert into solution(SolutionTitle) VALUES('"+sol.SolutionTitle+"')";
                return MySqlDB.nonquery(sql, CommandType.Text, null);
            }
            catch(Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 显示解决方案
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.solution> ShowSolution()
        {
            try
            {
                string sql = "SELECT * from solution";
                List<JiaJiModels.solution> list = MySqlDB.GetList<JiaJiModels.solution>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除解决方案
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelSolution(string SolutionID)
        {
            try
            {
                string sql = "delete from solution where SolutionID in (" + SolutionID + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 解决方案修改
        /// </summary>
        /// <param name="sol"></param>
        /// <returns></returns>
        public int UpdSolu(JiaJiModels.solution sol)
        {
            try
            {
                string sql = "update solution set SolutionTitle='"+sol.SolutionTitle+"' where SolutionID="+sol.SolutionID+"";
                return MySqlDB.nonquery(sql, CommandType.Text, null);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




    }
}
