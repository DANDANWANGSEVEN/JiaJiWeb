using JiaJiNewWebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    public interface IProjectDAL
    {
        #region 背景提升项目
        ///<summary>
        ///项目显示
        /// </summary>
        List<projectItem> ProjectShow();

        ///<summary>
        ///获取背景提升项目详情
        /// </summary>
        /// <para>Id:项目ID</para>
        /// <returns></returns>
        projectItem ProjectItemShow(int Id);

        ///<summary>
        ///上一个背景提升项目
        ///<para>Id:背景提升项目Id</para>
        /// </summary>
        JiaJiNewWebModel.projectItem ProjectItemPrev(int Id);

        ///<summary>
        ///下一个背景提升项目
        ///<para>Id:背景提升项目Id</para>
        /// </summary>
        JiaJiNewWebModel.projectItem ProjectItemNext(int Id);
        /// <summary>
        /// 获取全部的移民项目
        /// </summary>
        /// <returns></returns>
        List<projectItem> ProjectItemList(int pageindex);
        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        int GetProjectItemRowCounts();

        #endregion

        #region 移民项目

        ///<summary>
        ///移民项目
        /// </summary>
        List<Project> ImmigrantShow();
        ///<summary>
        ///获取移民项目详情
        /// </summary>
        /// <para>Id:项目ID</para>
        /// <returns></returns>
        Project ImmigrantShow(int Id);

        ///<summary>
        ///上一个移民项目
        ///<para>Id:移民项目Id</para>
        /// </summary>
        JiaJiNewWebModel.Project ImmigrantPrev(int Id);

        ///<summary>
        ///下一个移民项目
        ///<para>Id:移民项目Id</para>
        /// </summary>
        JiaJiNewWebModel.Project ImmigrantNext(int Id);

        /// <summary>
        /// 获取全部的移民项目
        /// </summary>
        /// <returns></returns>
        List<Project> ImmigrantList(int pageindex);

        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        int GetImmigrantRowCounts();

        #endregion

    }
}
