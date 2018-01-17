using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    public interface ICountryDAL
    {
        /// <summary>
        /// 获取国家集合
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Country> CountryList();
         
    }
}
