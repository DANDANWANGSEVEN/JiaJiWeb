using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebIDAL;
using JiaJiNewWeb.DALFactory;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
    public class ActiveBLL
    {

        JiaJiNewWebIDAL.IActiveDal udal =Factory<JiaJiNewWebIDAL.IActiveDal>.Create("ActiveDal");
        /// <summary>
        /// 获取活动列表
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Active> ActiveLsit()
        {
            return udal.ActiveLsit();
        }
        /// <summary>
        /// 获取活动列表,显示点击热度最高的前五条
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveLsitIndex(int countryid)
        {
            return udal.ActiveLsitIndex(countryid);
        }
        /// <summary>
        /// 获取具体活动列表
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveList(int pageindex)
        {
            return udal.ActiveList(pageindex);
        }
        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts()
        {
            return udal.GetRowCounts();
        }
        /// <summary>
        /// 获取活动列表,显示点击热度最高的前五条
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Active> ActiveLsitIndex()
        {
            return udal.ActiveLsitIndex();
        }
        ///// <summary>
        ///// 获取活动列表
        ///// </summary>
        ///// <returns></returns>
        //public List<JiaJiNewWebModel.Active> ActiveLsit()
        //{
        //    return udal.ActiveLsit();
        //}
        ///<summary>
        ///活动详情
        /// </summary>
        /// <returns></returns>
        public JiaJiNewWebModel.Active ActiveShow(int Id)
        {
            return udal.ActiveShow(Id);
        }


        /// <summary>
        /// 根据日期获取嘉际北京最新活动
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveLsitBeiJing()
        {
            try
            {
                return udal.ActiveLsitBeiJing();
            }
            catch (System.Exception ex)
            {
                return null;

            }

        }

        /// <summary>
        /// 根据日期获取嘉际xian最新活动
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveLsitXiAn()
        {
            try
            {
                return udal.ActiveLsitXiAn();
            }
            catch (System.Exception ex)
            {
                return null;

            }

        }

        ///<summary>
        ///上一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        public JiaJiNewWebModel.Active activePrev(int Id)
        {
            try
            {
                return udal.activePrev(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///<summary>
        ///下一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        public JiaJiNewWebModel.Active activeNext(int Id)
        {
            try
            {
                return udal.activeNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




    }
}
