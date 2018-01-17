using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace JiaJiDAL
{
    public class ProjectDAL
    {
        /// <summary>
        /// 添加移民项目
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int AddPro(JiaJiModels.ProjectModel pro)
        {
            try
            {
                string sql = " insert into project(EnglistName,ProjectTitle,ProjectContent,Date,Image,ProjectProfile,ProjectKeyWord,ProjectReadCount,ProjectAuthor,ProjectSource) values('" + pro.EnglistName+"','"+pro.ProjectTitle+"','"+pro.ProjectContent+"','"+pro.Date+"','"+pro.Image+"','"+pro.ProjectProfile+"','"+pro.ProjectKeyWord+"',0,'"+pro.ProjectAuthor+"','"+pro.ProjectSource+"')";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取移民项目信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ProjectModel> ShowProject()
        {
            try
            {
                string sql = "SELECT * from project order by projectID DESC";
                List<JiaJiModels.ProjectModel> ProjectModellist = MySqlDB.GetList<JiaJiModels.ProjectModel>(sql, CommandType.Text, null);

                return ProjectModellist;
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
                string sql = "delete from project where ProjectID in (" + projectid + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改移民项目
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int UpdPro(JiaJiModels.ProjectModel pro)
        {
            try
            {
                string sql = "update project set EnglistName='"+pro.EnglistName+"',ProjectTitle='"+pro.ProjectTitle+"',ProjectContent='"+pro.ProjectContent+"',`Date`='"+pro.Date+ "',Image='" + pro.Image+ "',ProjectProfile='"+pro.ProjectProfile+"',ProjectKeyWord='"+pro.ProjectKeyWord+"',ProjectAuthor='"+pro.ProjectAuthor+ "',ProjectSource='"+pro.ProjectSource+"' where ProjectID=" + pro.ProjectID+"";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;

            }
            catch(Exception ex)
            {
                return 0;
            }
        }

    }
}
