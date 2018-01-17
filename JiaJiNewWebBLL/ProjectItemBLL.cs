using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWeb.DALFactory;
namespace JiaJiNewWebBLL
{
    /// <summary>
    /// 项目内容表加载
    /// </summary>
    public class ProjectItemBLL
    {

        JiaJiNewWebIDAL.IProjectItemDAL udal = Factory<JiaJiNewWebIDAL.IProjectItemDAL>.Create("ProjectItemDAL");
        /// <summary>
        /// 获取项目列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.projectItem> GetProductList()
        {
            return udal.GetProductList();
        }

        /// <summary>
        /// 获取项目对应的图片
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.projectItem> GetProImgList(int proid)
        {

            try
            {
                return udal.GetProImgList(proid);
            }
            catch (System.Exception ex)
            {
                return null;

            }
        }


        /// <summary>
        /// 获取项目对应学员分享的内容列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Share> GetShareList(int id)
        {
            return udal.GetShareList(id);        
        }


        /// <summary>
        /// 获取分享详情
        /// </summary>
        /// <returns></returns>
        public JiaJiNewWebModel.Share GetShareContent(int shareid)
        {

            try
            {
                return udal.GetShareContent(shareid);
            }
            catch (System.Exception ex)
            {
                return null;

            }
        }

        ///<summary>
        ///上一个分享
        ///<para>Id:分享Id</para>
        /// </summary>
        public JiaJiNewWebModel.Share SharePrev(int Id)
        {
            try
            {
                return udal.SharePrev(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///<summary>
        ///下一个分享
        ///<para>Id:分享Id</para>
        /// </summary>
        public JiaJiNewWebModel.Share ShareNext(int Id)
        {
            try
            {
                return udal.ShareNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public int GetShareRowCounts()
        {
            try
            {
                return udal.GetShareRowCounts();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 获取所有的学员分享
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Share> GetAllShareList(int pageindex)
        {

            try
            {
                return udal.GetAllShareList(pageindex);
            }
            catch (System.Exception ex)
            {
                return null;

            }


        }


        /// <summary>
        /// 获取分享首加载时
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Share> GetFirstList()
        {

            try
            {
                return udal.GetFirstList();
            }
            catch (System.Exception ex)
            {
              
                return null;

            }


        }

    }
}
