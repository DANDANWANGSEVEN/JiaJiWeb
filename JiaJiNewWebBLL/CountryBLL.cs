using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using JiaJiNewWeb.DALFactory;
namespace JiaJiNewWebBLL
{
    public  class CountryBLL
    {


        JiaJiNewWebIDAL.ICountryDAL udal = Factory<JiaJiNewWebIDAL.ICountryDAL>.Create("CountryDAL");
        /// <summary>
        /// 获取国家集合
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Country> CountryList()
        {
            return udal.CountryList();

        }
    }
}
