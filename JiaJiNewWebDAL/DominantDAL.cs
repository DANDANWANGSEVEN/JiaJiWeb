using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebDAL
{
    public class DominantDAL:JiaJiNewWebIDAL.IDominantDAL
    {
        /// <summary>
        /// 获取国家优势
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <returns></returns>
        public List<CountryDominant> GetDominant(int countryid)
        {
            try
            {
                //    string sql = @"select a.CountryDominantID,a.Chance,b.*,c.* from countrydominant a INNER JOIN country b ON a.CountryID =b.CountryID 
                //INNER JOIN dominant c ON a.DominantID = c.DominantID where a.CountryID = " + countryid + " and IsCountry=1 limit 3 ";
                string sql = "select DominantID,DominantName,dominant.CountryID,CountryName from dominant left join country on dominant.CountryID=country.CountryID where dominant.CountryID = "+ countryid + " limit 3";
                List<CountryDominant> list = MySqlDB.GetList<CountryDominant>(sql, System.Data.CommandType.Text, null);
                JiaJiNewWeb.Common.Log4netHelper.WriteLog("调用成功！");
                return list;
            }
            catch (Exception ex)
            {
                JiaJiNewWeb.Common.Log4netHelper.WriteLog("调用失败！", ex);
                return null;
            }
        }


        /// <summary>
        /// 获取不是国家优势
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <returns></returns>
        public List<CountryDominant> GetLBY(int countryid)
        {
            try
            {
                string sql = @"select a.CountryDominantID,a.Chance,b.*,c.* from countrydominant a INNER JOIN country b ON a.CountryID =b.CountryID 
            INNER JOIN dominant c ON a.DominantID = c.DominantID where a.CountryID = " + countryid + " and IsCountry=0";
                List<CountryDominant> list = MySqlDB.GetList<CountryDominant>(sql, System.Data.CommandType.Text, null);
                JiaJiNewWeb.Common.Log4netHelper.WriteLog("调用成功！");
                return list;
            }
            catch (Exception ex)
            {
                JiaJiNewWeb.Common.Log4netHelper.WriteLog("调用失败！", ex);
                return null;
            }
        }



    }
}
