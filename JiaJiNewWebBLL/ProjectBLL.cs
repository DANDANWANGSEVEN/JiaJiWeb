using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using JiaJiNewWeb.DALFactory;
using JiaJiNewWebIDAL;

namespace JiaJiNewWebBLL
{
    public class ProjectBLL
    {
        IProjectDAL dal = Factory<IProjectDAL>.Create("ProjectDAL");

        #region 背景提升项目
        ///<summary>
        ///项目显示
        /// </summary>
        public List<projectItem> ProjectShow()
        {
            return dal.ProjectShow();
        }

        ///<summary>
        ///获取背景提升项目详情
        /// </summary>
        /// <para>Id:项目ID</para>
        /// <returns></returns>
        public projectItem ProjectItemShow(int Id)
        {
            try
            {
                return dal.ProjectItemShow(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///上一个背景提升项目
        ///<para>Id:背景提升项目Id</para>
        /// </summary>
        public JiaJiNewWebModel.projectItem ProjectItemPrev(int Id)
        {
            try
            {
                return dal.ProjectItemPrev(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///<summary>
        ///下一个背景提升项目
        ///<para>Id:背景提升项目Id</para>
        /// </summary>
        public JiaJiNewWebModel.projectItem ProjectItemNext(int Id)
        {
            try
            {
                return dal.ProjectItemNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 获取全部的移民项目
        /// </summary>
        /// <returns></returns>
        public List<projectItem> ProjectItemList(int pageindex)
        {
            try
            {
                return dal.ProjectItemList(pageindex);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        public int GetProjectItemRowCounts()
        {
            try
            {
                return dal.GetProjectItemRowCounts();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        #endregion

        #region 移民项目

        ///<summary>
        ///移民项目
        /// </summary>
        public List<Project> ImmigrantShow()
        {
            return dal.ImmigrantShow();
        }
        ///<summary>
        ///获取移民项目详情
        /// </summary>
        /// <para>Id:项目ID</para>
        /// <returns></returns>
        public Project ImmigrantShow(int Id)
        {
            return dal.ImmigrantShow(Id);
        }

        ///<summary>
        ///上一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        public JiaJiNewWebModel.Project ImmigrantPrev(int Id)
        {
            try
            {
                return dal.ImmigrantPrev(Id);
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
        public JiaJiNewWebModel.Project ImmigrantNext(int Id)
        {
            try
            {
                return dal.ImmigrantNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 获取全部的移民项目
        /// </summary>
        /// <returns></returns>
        public List<Project> ImmigrantList(int pageindex)
        {
            try
            {
                return dal.ImmigrantList(pageindex);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        public int GetImmigrantRowCounts()
        {
           try
            {
                return dal.GetImmigrantRowCounts();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        #endregion


    }
}
