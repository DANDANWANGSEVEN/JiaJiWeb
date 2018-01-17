using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
    public interface ISuccessFulRelationDAL
    {
        /// <summary>
        /// 显示成功案例
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        List<SuccessfulInfo_Relation> GetAnLi(int countryid, int educationid, int pageindex);
        /// <summary>
        /// 根据条件获取总行数
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <returns></returns>
        int GetRowCounts(int countryid, int educationid);
        /// <summary>
        /// 获取国家列表
        /// </summary>
        /// <returns></returns>
        List<Country> GetCountry();

        /// <summary>
        /// 获取语言背景移民
        /// </summary>
        /// <returns></returns>
        List<Country> GetLBY(int countryid);

        /// <summary>
        /// 获取学历类别
        /// </summary>
        /// <returns></returns>
        List<EducationType> GetEducationType();
        /// <summary>
        /// 查找国家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Country> GetCountry(int id);
    }
}
