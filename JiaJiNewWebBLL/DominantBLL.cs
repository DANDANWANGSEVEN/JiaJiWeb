using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
    public class DominantBLL
    {
        JiaJiNewWebIDAL.IDominantDAL ddal = JiaJiNewWeb.DALFactory.Factory<JiaJiNewWebIDAL.IDominantDAL>.Create("DominantDAL");
        /// <summary>
        /// 获取优势
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <returns></returns>
        public List<CountryDominant> GetDominant(int countryid)
        {
            return ddal.GetDominant(countryid);
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

                return ddal.GetLBY(countryid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
