using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWeb.Common;
namespace JiaJiNewWebDAL
{
    public class CountryDAL:JiaJiNewWebIDAL.ICountryDAL
    {
        /// <summary>
        /// 获取国家集合
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Country> CountryList()
        {
            try
            {
                string sql = "SELECT CountryID,CountryName,CountryImg from country where IsCountry=1";

                List<JiaJiNewWebModel.Country> list = MySqlDB.GetList<JiaJiNewWebModel.Country>(sql, System.Data.CommandType.Text, null);
                Log4netHelper.WriteLog("系统日志，请求了CountryDal类下的CountryDAL方法");
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误，请求了CountryDal类下的CountryDAL方法", ex);
                throw;
            }

        }
    }
}
