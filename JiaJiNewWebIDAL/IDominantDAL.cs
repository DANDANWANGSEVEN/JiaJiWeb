using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
    public interface IDominantDAL
    {
        /// <summary>
        /// 获取优势
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <returns></returns>
        List<CountryDominant> GetDominant(int countryid);

        /// <summary>
        /// 获取不是国家优势
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <returns></returns>
        List<CountryDominant> GetLBY(int countryid);

    }
}
