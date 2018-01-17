using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
    public class ApplyBLL
    {
        JiaJiNewWebIDAL.IApplyDAL apdal = JiaJiNewWeb.DALFactory.Factory<JiaJiNewWebIDAL.IApplyDAL>.Create("ApplyDAL");
        /// <summary>
        /// 添加申请
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Addapply(Apply a)
        {
            return apdal.Addapply(a);
        }

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.CountryDominant> HaiWaiLiuXueIndexList()
        {
            try
            {
                return apdal.HaiWaiLiuXueIndexList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 根据国家显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.CountryDominant> HaiWaiList(int countryid)
        {
            try
            {
                return apdal.HaiWaiList(countryid);
            }
            catch (Exception ex)
            {
                return null;
            }

        }


    }
}
