using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
    public interface IMediumDAL
    {
        /// <summary>
        /// 获取合作的媒体
        /// </summary>
        /// <returns></returns>
        List<Medium> GetMedium();
    }
}
