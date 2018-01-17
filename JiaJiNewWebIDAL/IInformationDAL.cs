using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
    public interface IInformationDAL
    {
        /// <summary>
        /// 热门资讯显示前6条
        /// </summary>
        /// <returns></returns>
        List<Information> GetInformationTopList(int countryid);
        /// <summary>
        /// 根据热度显示资讯列表（分页）
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        List<Information> GetInformationList(int pageindex);
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        int GetRowCounts();

        /// <summary>
        /// 获取搜索结果的行数
        /// </summary>
        /// <param name="selcontent"></param>
        /// <returns></returns>
        int SelectRowCounts(string selcontent);

        /// <summary>
        /// 获取资讯详细信息
        /// InformationID:资讯ID
        /// </summary>
        /// <returns></returns>
        Information InformationShow(int InformationID);
        /// <summary>
        /// 热门资讯显示前6条
        /// </summary>
        /// <returns></returns>
        List<Information> GetInformationTopList();

        /// <summary>
        /// 北京资讯
        /// </summary>
        /// <returns></returns>

        List<Information> GetBeiJingInfor();

        /// <summary>
        /// xian资讯
        /// </summary>
        /// <returns></returns>
        List<Information> GetXiAnInfor();
        /// <summary>
        /// 搜索关键字
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Home.SearchDetails> Select(JiaJiNewWebModel.Home.selectmodel model);

        ///<summary>
        ///上一个留学资讯
        ///<para>Id:成功案列Id</para>
        /// </summary>
        Information InforPrev(int Id);

        ///<summary>
        ///下一个成功案列
        ///<para>Id:成功案列Id</para>
        /// </summary>
        Information InforNext(int Id);
     

    }
}
