using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
    public class SuccessFulRelationBLL
    {
        JiaJiNewWebIDAL.ISuccessFulRelationDAL sdal = JiaJiNewWeb.DALFactory.Factory<JiaJiNewWebIDAL.ISuccessFulRelationDAL>.Create("SuccessFulRelationDAL");
        /// <summary>
        /// 显示成功案例
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        public List<SuccessfulInfo_Relation> GetAnLi(int countryid, int educationid, int pageindex)
        {
            return sdal.GetAnLi(countryid, educationid, pageindex);
        }
        /// <summary>
        /// 根据条件获取总行数
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <returns></returns>
        public int GetRowCounts(int countryid, int educationid)
        {
            return sdal.GetRowCounts(countryid, educationid);
        }
        /// <summary>
        /// 获取国家列表
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountry()
        {
            return sdal.GetCountry();
        }
        /// <summary>
        /// 获取学历类别
        /// </summary>
        /// <returns></returns>
        public List<EducationType> GetEducationType()
        {
            return sdal.GetEducationType();
        }
        /// <summary>
        /// 查找国家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Country> GetCountry(int id)
        {
            return sdal.GetCountry(id);
        }


        /// <summary>
        /// 获取语言背景移民
        /// </summary>
        /// <returns></returns>
        public List<Country> GetLBY(int countryid)
        {
            try
            {
                return sdal.GetLBY(countryid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
