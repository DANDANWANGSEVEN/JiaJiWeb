using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using JiaJiNewWeb.Common;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
namespace JiaJiNewWebDAL
{
    public class TeamDAL : JiaJiNewWebIDAL.ITeamDAL
    {
        /// <summary>
        /// 团队列表
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        public List<Team> GetTeam(int areaid, int pageindex)
        {
            try
            {
            int pagesize = 5;
            string sql = "SELECT SQL_CALC_FOUND_ROWS b.TeamID,b.`Name`,b.Position,b.WorkDate,b.ShenQing,c.AreaID,c.AreaName,b.Image1,b.SuccessKeyWord,b.SuccessContent,b.SuccessProfile from arearelation a " +
            "INNER JOIN team b ON a.TeamID = b.TeamID " +
            " INNER JOIN areases c ON a.AreaID = c.AreaID " +
            " WHERE c.AreaID = " + areaid + " LIMIT " + (pageindex - 1) * pagesize + "," + pagesize + ";" +
            " SELECT FOUND_ROWS(); ";
            //string sql = "SELECT b.TeamID,b.`Name`,b.Position,b.WorkDate,b.ShenQing,c.AreaID,c.AreaName from arearelation a INNER JOIN team b ON a.TeamID = b.TeamID INNER JOIN area c ON a.AreaID = c.AreaID  WHERE c.AreaID=" + areaid;
            List<Team> list = MySqlDB.GetList<Team>(sql, System.Data.CommandType.Text, null);
            return list.ToList();
            }
           catch(Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 团队显示成功案例文章
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Team TeamSuccessContent(int Id)
        {
            try
            {
                string sql = "select * from team where TeamID=@Id";
                MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                Team t = new Team();
                t.Name = dt.Rows[0][1].ToString();
                t.Position = dt.Rows[0][2].ToString();
                t.ShenQing = dt.Rows[0][4].ToString();
                t.WorkDate = dt.Rows[0][3].ToString();
                t.Image2 = dt.Rows[0][6].ToString();
                t.SuccessCount = dt.Rows[0]["SuccessCount"].ToString();
                t.SuccessContent= dt.Rows[0]["SuccessContent"].ToString();
                t.SuccessKeyWord= dt.Rows[0]["SuccessKeyWord"].ToString();
                Log4netHelper.WriteLog("日志报告");
                return t;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }


        }


        /// <summary>
        /// js获取团队行数
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        public int GetRowCounts(int areaid)
        {
            try
            {
                string sql2 = "SELECT count(1) from arearelation a " +
                "INNER JOIN team b ON a.TeamID = b.TeamID " +
                "INNER JOIN areases c ON a.AreaID = c.AreaID  WHERE c.AreaID = " + areaid + "";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);

                return i % 5 == 0 ? i / 5 : (i / 5) + 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }

        /// <summary>
        /// 通过团队ID查找其成功案例
        /// </summary>
        /// <param name="teamid">团队ID</param>
        /// <returns></returns>
        public List<SuccessfulAnLi> GetAnliByTeam(int teamid)
        {
            //    string sql = @"SELECT * from successful where SuccessID in
            //(SELECT SuccessID from team_anli where TeamID = " + teamid + ")";

            string sql = @"SELECT * from successful where successful.SuccessID in
        (SELECT SuccessID from team_anli where TeamID = " + teamid + ")";
            DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, default(MySqlParameter[]));
            List<SuccessfulAnLi> list = new List<SuccessfulAnLi>();
            foreach (DataRow item in dt.Rows)
            {
                SuccessfulAnLi anLi = new SuccessfulAnLi();
                anLi.SuccessID = Convert.ToInt32(item["SuccessID"]);
                anLi.SuccessTitle = item["SuccessTitle"].ToString();
                list.Add(anLi);
            }
            return list;
        }
        /// <summary>
        /// 获取地区
        /// </summary>
        /// <returns></returns>
        public List<Area> GetArea()
        {
            string sql = "SELECT * from areases limit 2";
            List<Area> list = MySqlDB.GetList<Area>(sql, System.Data.CommandType.Text, null);
            return list;
        }

        /// <summary>
        /// 团队首页介绍信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.TeamIndexModel> TeamindexList()
        {
            try
            {
                //string sql = @" select a.Image1,a.TeamID,a.Name,a.Position,a.WorkDate,a.ShenQing,c.Content 
                //            from Team a INNER JOIN Term_Relation b on a.TeamID = b.TeamID
                //            inner join team_content c ON c.ContentID = b.ContentID  LIMIT 4";

                string sql = "select TeamID,`Name`,Position,WorkDate,ShenQing,Image1,Image2,TeamProduce from Team LIMIT 4";

                List<JiaJiNewWebModel.TeamIndexModel> list = MySqlDB.GetList<JiaJiNewWebModel.TeamIndexModel>(sql, System.Data.CommandType.Text, null);
                foreach (JiaJiNewWebModel.TeamIndexModel item in list)
                {
                    item.Content = Help.Chinese(item.TeamProduce);
                }


                Log4netHelper.WriteLog("系统日志，请求了ActiveDal类下的ActiveLsitIndex方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;
            }
        }

        /// <summary>
        /// 团队分国家显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.TeamIndexModel> CountryTeamList(string countryname)
        {
            try
            {
                string sql = "select TeamID,`Name`,Position,WorkDate,ShenQing,Image1,Image2,TeamProduce from Team where ShenQing like '%" + countryname + "%' LIMIT 4";

                List<JiaJiNewWebModel.TeamIndexModel> list = MySqlDB.GetList<JiaJiNewWebModel.TeamIndexModel>(sql, System.Data.CommandType.Text, null);
                foreach (JiaJiNewWebModel.TeamIndexModel item in list)
                {
                    item.Content = Help.Chinese(item.TeamProduce);
                }


                Log4netHelper.WriteLog("系统日志，请求了ActiveDal类下的ActiveLsitIndex方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;

            }
        }



        ///<summary>
        ///顾问内页
        ///<para>Id:顾问ID</para>
        /// </summary>
        public Team TeamShow(int Id)
        {
            try
            {
                string sql = "select * from team where TeamID=@Id";
                MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                Team t = new Team();
                t.Name = dt.Rows[0][1].ToString();
                t.Position = dt.Rows[0][2].ToString();
                t.ShenQing = dt.Rows[0][4].ToString();
                t.WorkDate = dt.Rows[0][3].ToString();
                t.Image2 = dt.Rows[0][6].ToString();
                t.SuccessCount = dt.Rows[0]["SuccessCount"].ToString();
                Log4netHelper.WriteLog("日志报告");
                return t;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }


        }

        /// <summary>
        /// 顾问内容
        /// </summary>
        /// <param name="Id">顾问ID</param>
        /// <returns></returns>
        public List<TeamInfor> ContentShow(int Id)
        {
            try
            {
                string sql = "select d.TitleName,c.Content from  team a INNER JOIN term_relation b on a.TeamID = b.TeamID INNER JOIN team_content c on b.ContentID = c.ContentID INNER JOIN team_title d on b.TeamTitleID = d.TeamTitleID where a.TeamID = @Id";
                MySqlParameter[] para =  {
                new MySqlParameter("@Id",Id)

            };
                List<TeamInfor> list = new List<TeamInfor>();
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                foreach (DataRow item in dt.Rows)
                {
                    TeamInfor team = new TeamInfor();
                    team.Title = item["TitleName"].ToString();
                    team.Content = item["Content"].ToString();
                    list.Add(team);
                }

                Log4netHelper.WriteLog("日志报告");
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }
        ///<summary>
        ///成功案列
        ///<param name="Id">顾问ID</param>
        /// </summary>
        public string SuccessCount(int Id)
        {
            try
            {
                string sql = @"SELECT count(1) as 'count' FROM successful_relation WHERE StudentID in
(select StudentID from teamrelation where TeamID = @Id)";
                MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                string count = dt.Rows[0][0].ToString();
                Log4netHelper.WriteLog("日志报告");
                return count;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }

        public List<Team> SuccessCountList(int pageindex,int teamid)
        {
            try
            {
                int pagesize = 6;

                StringBuilder sql = new StringBuilder();

                sql.Append(" SELECT SQL_CALC_FOUND_ROWS successful_relation.SRelationID,StudentName, Score, student.CollegeID,JiuDuXueyuan,student.EducationID,student.CountryID,successful_relation.SuccessID ");
                sql.Append(" ,CollegeName,EducationName,CountryName,SuccessTitle,CollegeImg FROM successful_relation                                       ");
                sql.Append(" LEFT JOIN student on successful_relation.StudentID = student.StudentID                                                        ");
                sql.Append(" left join college on student.CollegeID = college.CollegeID                                                                    ");
                sql.Append(" left join educationtype on student.EducationID = educationtype.EducationID                                                    ");
                sql.Append(" left join country on student.CountryID = country.CountryID                                                                    ");
                sql.Append(" left join successful on successful.SuccessID = successful_relation.SuccessID                                                  ");
                sql.Append(" WHERE successful_relation.StudentID in                                                                                        ");
                sql.Append(" (select StudentID from teamrelation where TeamID = "+ teamid + ")  ORDER BY successful_relation.SRelationID DESC  LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS();");


                List<Team> list = MySqlDB.GetList<Team>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int GetSuccessCount(int Id)
        {
            string sql = "SELECT count(1) as 'count' FROM successful_relation WHERE StudentID in (select StudentID from teamrelation where TeamID ="+ Id + " )";
            int i = MySqlDB.scalar(sql, System.Data.CommandType.Text, null);
            return i = i % 6 == 0 ? i / 6: (i / 6) + 1;
        }

      
        /// <summary>
        /// 北京团队
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        public List<Team> GetBeiJingTeam()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT SQL_CALC_FOUND_ROWS b.TeamID,b.`Name`,b.Position,b.WorkDate,b.ShenQing,c.AreaID,c.AreaName,b.Image1,TeamProduce from arearelation a ");
                sql.Append(" INNER JOIN team b ON a.TeamID = b.TeamID  ");
                sql.Append(" INNER JOIN areases c ON a.AreaID = c.AreaID  WHERE c.AreaName = '北京' LIMIT 0,4 ");

                List<Team> list = MySqlDB.GetList<Team>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 西安团队
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        public List<Team> GetXiAnTeam()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT SQL_CALC_FOUND_ROWS b.TeamID,b.`Name`,b.Position,b.WorkDate,b.ShenQing,c.AreaID,c.AreaName,b.Image1,TeamProduce from arearelation a ");
                sql.Append(" INNER JOIN team b ON a.TeamID = b.TeamID  ");
                sql.Append(" INNER JOIN areases c ON a.AreaID = c.AreaID  WHERE c.AreaName = '西安' LIMIT 0,4 ");
                List<Team> list = MySqlDB.GetList<Team>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
