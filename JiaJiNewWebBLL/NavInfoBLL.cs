using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using JiaJiNewWebDAL;
using JiaJiNewWebIDAL;

namespace JiaJiNewWebBLL
{
    public class NavInfoBLL : INavInfo
    {
        public bool AddByModel(NavInfoModel model)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.AddByModel(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteByModel(NavInfoModel model)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.DeleteByModel(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditByModel(NavInfoModel model)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.EditByModel(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NavInfoModel> GetAllNavInfoByGuoJia(string GuoJia)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.GetAllNavInfoByGuoJia(GuoJia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据navid获取该行数据
        /// </summary>
        /// <param name="NavID"></param>
        /// <returns></returns>
        public NavInfoModel GetModelById(int NavID)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.GetModelById(NavID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///<summary>
        ///上一个导航标题
        ///<para>Id:导航标题Id</para>
        /// </summary>
        public NavInfoModel GetModelByIdPrev(int Id)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.GetModelByIdPrev(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///<summary>
        ///下一个导航标题
        ///<para>Id:导航标题Id</para>
        /// </summary>
        public NavInfoModel GetModelByIdNext(int Id)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.GetModelByIdNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<NavInfoModel> GetNavInfoByGuoJiaAndParentID(string GuoJia,int ParentId)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.GetNavInfoByGuoJiaAndParentId(GuoJia,ParentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NavInfoModel> GetNavInfo(string GuoJia, int ParentId,string BuWei)
        {
            try
            {
                NavInfoDAL dal = new NavInfoDAL();
                return dal.GetNavInfo(GuoJia, ParentId, BuWei);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
