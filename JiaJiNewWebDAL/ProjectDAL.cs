using JiaJiNewWebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JiaJiNewWeb.Common;
using MySql.Data.MySqlClient;

namespace JiaJiNewWebDAL
{
    public class ProjectDAL:JiaJiNewWebIDAL.IProjectDAL
    {
        #region 游学项目
        ///<summary>
        ///项目显示
        /// </summary>
        public List<projectItem> ProjectShow()
        {
            try
            {
                string sql = "select  * from projectitem";
                List<projectItem> list = MySqlDB.GetList<projectItem>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
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
                string sql = "update projectitem set Pro_ReadCount=Pro_ReadCount+1 where Pro_ID="+ Id + ";";
                sql += "select * from projectitem where Pro_ID=" + Id + "";
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                projectItem pro = MySqlDB.fanshemodel<projectItem>(dt);
                return pro;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
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
                projectItem model = new projectItem();
                DataTable dt1 = MySqlDB.GetDataTable("select min(Pro_ID) from projectitem", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.Pro_Name = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from projectitem  where Pro_ID <@Id order by Pro_ID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.Pro_ID = (int)dt.Rows[0]["Pro_ID"];
                    model.Pro_Name = dt.Rows[0]["Pro_Name"].ToString();
                    Log4netHelper.WriteLog("日志报告");
                    return model;
                }

            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
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
                projectItem infor = new projectItem();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(Pro_ID) from projectitem", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.Pro_Name = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from projectitem WHERE Pro_ID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.Pro_ID = (int)dt.Rows[0]["Pro_ID"];
                    infor.Pro_Name = dt.Rows[0]["Pro_Name"].ToString();
                    Log4netHelper.WriteLog("日志报告");
                    return infor;

                }
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
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
                int pagesize = 5;
                string sql = "SELECT SQL_CALC_FOUND_ROWS * FROM projectitem  ORDER BY Pro_ID DESC LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS(); ";

                List<projectItem> list = MySqlDB.GetList<projectItem>(sql, System.Data.CommandType.Text, null);
                foreach (var v in list)
                {
                    v.Pro_Content = Help.Chinese(v.Pro_Content);
                }
                foreach (var item in list)
                {
                    if (item.Pro_Content.Length > 80)
                    {
                        item.Pro_Content = item.Pro_Content.Substring(0, 80) + "......";
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
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
                string sql2 = "select count(1) from projectitem";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
                return i = i % 5 == 0 ? i / 5 : (i / 5) + 1;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
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
            try
            {
                string sql = "select * from project order by Date desc limit 2";
                List<Project> list = MySqlDB.GetList<Project>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
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
                int pagesize = 5;
                string sql = "SELECT SQL_CALC_FOUND_ROWS * FROM project  ORDER BY ProjectID DESC LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS(); ";

                List<Project> list = MySqlDB.GetList<Project>(sql, System.Data.CommandType.Text, null);
                foreach (var v in list)
                {
                    v.ProjectContent = Help.Chinese(v.ProjectContent);
                }
                foreach (var item in list)
                {
                    if (item.ProjectContent.Length > 50)
                    {
                        item.ProjectContent = item.ProjectContent.Substring(0, 50) + "......";
                    }
                }

                return list;
            }
           catch(Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
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
                string sql2 = "select count(1) from project";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
                return i = i % 5 == 0 ? i / 5 : (i / 5) + 1;
            }
            catch(Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                return 0;
            }
           
        }


        ///<summary>
        ///上一个移民项目
        ///<para>Id:移民项目Id</para>
        /// </summary>
        public JiaJiNewWebModel.Project ImmigrantPrev(int Id)
        {
            try
            {
                Project model = new Project();
                DataTable dt1 = MySqlDB.GetDataTable("select min(ProjectID) from project", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.ProjectTitle = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from project  where ProjectID <@Id order by ProjectID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.ProjectID = (int)dt.Rows[0]["ProjectID"];
                    model.ProjectTitle = dt.Rows[0]["ProjectTitle"].ToString();
                    Log4netHelper.WriteLog("日志报告");
                    return model;
                }

            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }

        ///<summary>
        ///下一个移民项目
        ///<para>Id:移民项目Id</para>
        /// </summary>
        public JiaJiNewWebModel.Project ImmigrantNext(int Id)
        {
            try
            {
                Project infor = new Project();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(ProjectID) from project", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.ProjectTitle = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from project WHERE ProjectID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.ProjectID= (int)dt.Rows[0]["ProjectID"];
                    infor.ProjectTitle = dt.Rows[0]["ProjectTitle"].ToString();
                    Log4netHelper.WriteLog("日志报告");
                    return infor;

                }
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }

        ///<summary>
        ///获取移民项目详情
        /// </summary>
        /// <para>Id:项目ID</para>
        /// <returns></returns>
        public Project ImmigrantShow(int Id)
        {
            try
            {
                string sql = "update project set ProjectReadCount=ProjectReadCount+1 where ProjectID="+ Id + ";";
                sql += "select * from project where ProjectID='" + Id + "'";
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                Project pro = MySqlDB.fanshemodel<Project>(dt);
                return pro;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }

        #endregion
    }
}
