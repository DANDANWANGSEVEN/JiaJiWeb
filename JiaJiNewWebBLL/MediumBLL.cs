using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
    public class MediumBLL
    {
        JiaJiNewWebIDAL.IMediumDAL medal = JiaJiNewWeb.DALFactory.Factory<JiaJiNewWebIDAL.IMediumDAL>.Create("MediumDAL");
        /// <summary>
        /// 获取合作的媒体
        /// </summary>
        /// <returns></returns>
        public List<Medium> GetMedium()
        {
            return medal.GetMedium();
        }
    }
}
