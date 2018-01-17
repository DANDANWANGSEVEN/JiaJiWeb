using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
    public interface IApplyDAL
    {
        /// <summary>
        /// 添加申请
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        bool Addapply(Apply a);

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.CountryDominant> HaiWaiLiuXueIndexList();

        /// <summary>
        /// 根据国家显示
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.CountryDominant> HaiWaiList(int countryid);
    }
}
