using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
   public class StrategyBLL
    {
        JiaJiNewWebIDAL.IStrategyDAL Strdal = JiaJiNewWeb.DALFactory.Factory<JiaJiNewWebIDAL.IStrategyDAL>.Create("StrategyDAL");


        /// <summary>
        /// 根据日期显示策略（分页）
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public List<Strategy> GetStrategyList(int pageindex)
        {
            try
            {
                return Strdal.GetStrategyList(pageindex);
            }

            catch (Exception ex)
            {
                return null;
            }



        }
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public int GetStraRowCounts()
        {
            try
            {
                return Strdal.GetStraRowCounts();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        /// <summary>
        /// 获取申请攻略的信息
        /// </summary>
        /// <param name="contryid"></param>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Strategy> StrategeIndexList(int contryid)
        {
            return Strdal.StrategeIndexList(contryid);
        }

        ///<summary>
        ///攻略详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Strategy StrategyShow(int Id)
        {
            return Strdal.StrategyShow(Id);
        }


        ///<summary>
        ///上一个攻略
        ///<para>Id:攻略Id</para>
        /// </summary>
        public JiaJiNewWebModel.Strategy StrategyPrev(int Id)
        {
            try
            {
                return Strdal.StrategyPrev(Id);
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
        public JiaJiNewWebModel.Strategy StrategyNext(int Id)
        {
            try
            {
                return Strdal.StrategyNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
