using JiaJiDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiBLL
{
    public class ProjectBLL
    {
        ProjectDAL dal = new ProjectDAL();
        /// <summary>
        /// 添加移民项目
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int AddPro(JiaJiModels.ProjectModel pro)
        {
            return dal.AddPro(pro);
        }

        /// <summary>
        /// 获取移民项目信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ProjectModel> ShowProject()
        {
            try
            {
                return dal.ShowProject();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除移民项目
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelProject(string projectid)
        {
            try
            {
                return dal.DelProject(projectid);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加移民项目
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int UpdPro(JiaJiModels.ProjectModel pro)
        {
            try
            {
                return new JiaJiDAL.ProjectDAL().UpdPro(pro);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }



    }
}
