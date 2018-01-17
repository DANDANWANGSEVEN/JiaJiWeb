using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
   public interface IActiveDal
    {

        /// <summary>
        /// 获取首页显示的活动列表
        /// </summary>
        /// <returns></returns>
        List<Active> ActiveLsit();
        /// <summary>
        /// 获取活动列表,显示点击热度最高的前五条
        /// </summary>
        /// <returns></returns>
        List<Active> ActiveLsitIndex(int countryid);
        
        /// <summary>
        /// 获取具体活动列表
        /// </summary>
        /// <returns></returns>
        List<Active> ActiveList(int pageindex);
        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        int GetRowCounts();

        /// <summary>
        /// 获取活动列表,显示点击热度最高的前五条
        /// </summary>
        /// <returns></returns>
        List<Active> ActiveLsitIndex();
        
        ///<summary>
        ///获取活动详情
        ///Id：活动ID
        /// </summary>
        /// <return></return>
        Active ActiveShow(int Id);

        /// <summary>
        /// 根据日期获取嘉际北京最新活动
        /// </summary>
        /// <returns></returns>
        List<Active> ActiveLsitBeiJing();

        /// <summary>
        /// 根据日期获取嘉际xian最新活动
        /// </summary>
        /// <returns></returns>
        List<Active> ActiveLsitXiAn();


        ///<summary>
        ///上一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
         JiaJiNewWebModel.Active activePrev(int Id);
     
        ///<summary>
        ///下一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        JiaJiNewWebModel.Active activeNext(int Id);

    }
}
