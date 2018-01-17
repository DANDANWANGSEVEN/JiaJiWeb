using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
    public interface IStrategyDAL
    {

        /// <summary>
        /// 根据日期显示策略（分页）
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        List<Strategy> GetStrategyList(int pageindex);

        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        int GetStraRowCounts();



        /// <summary>
        /// 获取申请攻略的信息
        /// </summary>
        /// <param name="contryid"></param>
        /// <returns></returns>
        List<Strategy> StrategeIndexList(int contryid);
        ///<summary>
        ///攻略详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Strategy StrategyShow(int Id);


        //<summary>
        ///上一个攻略
        ///<para>Id:攻略Id</para>
        /// </summary>
        JiaJiNewWebModel.Strategy StrategyPrev(int Id);

        ///<summary>
        ///下一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        JiaJiNewWebModel.Strategy StrategyNext(int Id);

    }
}
