using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using JiaJiModels;
namespace JiaJiDAL
{
    public class teamdal
    {

        #region 获取团队标题信息

        /// <summary>
        /// 获取团队标题信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Team> Titleshow()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select * from  term_relation left join team on term_relation.TeamID=team.TeamID ");
                sql.Append(" left join team_title on term_relation.TeamTitleID=team_title.TeamTitleID ");
                sql.Append(" left join team_content on term_relation.ContentID=team_content.ContentID order by TermRealID desc  ");
                List<JiaJiModels.Team> list = MySqlDB.GetList<JiaJiModels.Team>(sql.ToString(), CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 删除团队标题信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelTeamTitle(string ids)
        {
            try
            {
                string sql = "select * from term_relation where TermRealID in (" + ids + ")";
                string contentids = "";
                var dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    contentids += dt.Rows[i][0].ToString() + ",";
                }
                contentids = contentids.TrimEnd(',');

                sql = "delete from team_content where ContentID in (" + contentids + ");";
                sql += "delete from term_relation where TermRealID in (" + ids + ");";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取团队标题
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Team> showTitle()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select TeamTitleID,TitleName from  team_title ");
                List<JiaJiModels.Team> list = MySqlDB.GetList<JiaJiModels.Team>(sql.ToString(), CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加标题内容
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int InsertTitle(Team t)
        {
            try
            {
                string sql = "insert into team_content(Content) VALUE ('" + t.Content + "');select @@IDENTITY ;";

                int teamcontentid = Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][0]);

                sql = "insert into team_title(TitleName) value ('"+t.TitleName+ "');select @@IDENTITY ;";

                int titleid= Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][0]);

                sql = "insert into term_relation(TeamID, TeamTitleID,ContentID) values(" + t.TeamID + "," + titleid + "," + teamcontentid + ")";

                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// 字节数组转化成string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 修改团队标题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateTitle(JiaJiModels.Team model)
        {
            try
            {

                string sql = "select * from term_relation where TermRealID=" + model.TermRealID + "";
                int titleid= Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][2]);
                int contentid = Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][3]);

                sql = "update team_content set Content='" + model.Content + "' where team_content.ContentID=" + contentid + ";";
                sql += " update team_title set TitleName='"+model.TitleName+ "' where TeamTitleID="+ titleid + ";  ";
                sql += "update term_relation set term_relation.TeamID=" + model.TeamID + ",term_relation.TeamTitleID=" + titleid + ",term_relation.ContentID=" + contentid + " where term_relation.TermRealID=" + model.TermRealID + "";


                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion


        #region 精英团队

        public List<Team> Team()
        {
            try
            {
                string sql = "select TeamID,Name from Team";
                List<Team> list = MySqlDB.GetList<Team>(sql.ToString(), CommandType.Text, null);

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 获取团队基本信息
        /// </summary>
        /// <returns></returns>
        public List<Team> GetTeam()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select * from team LEFT JOIN arearelation on team.TeamID=arearelation.TeamID left join areases on arearelation.AreaID=areases.AreaID order by AreaRelaID desc ");

                List<Team> list = MySqlDB.GetList<Team>(sql.ToString(), CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 添加团队信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addTeam(JiaJiModels.Team model)
        {
            try
            {

                string sql = "INSERT INTO study_abroad.team (`Name`, `Position`,WorkDate,ShenQing,Image1,Image2,TeamProduce,SuccessCount,SuccessContent,SuccessKeyWord,SuccessProfile) VALUE ('" + model.Name+"','"+model.Position+"','"+model.WorkDate+"','"+model.ShenQing+"','"+model.Image1+"','"+model.Image2+"','"+model.TeamProduce+"','"+model.SuccessCount+"','"+model.SuccessContent+"','"+model.SuccessKeyWord + "','"+model.SuccessProfile+"');select @@IDENTITY;";

                int Teamid = Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][0]);

                sql = "insert into arearelation(TeamID, AreaID) values(" + Teamid + "," + model.AreaID + ")";

                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除团队信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelTeamInfo(string ids)
        {
            try
            {

                string sql = "select TeamID from arearelation where AreaRelaID in (" + ids + ") ";

                //string sql = "select * from team where TeamID in (" + TeamID + "); ";

                string teamids = "";
                var dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    teamids += dt.Rows[i][0].ToString() + ",";
                }
                teamids = teamids.TrimEnd(',');

                sql = "delete from term_relation where TeamID in (" + teamids + ");";
                sql += "delete from team where TeamID in (" + teamids + ");";
                sql += "DELETE from arearelation where AreaRelaID in (" + teamids + ");";

                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        

        /// <summary>
        /// 修改tuandui信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateTeam(JiaJiModels.Team model)
        {
            try
            {
                string sql = "select TeamID from arearelation where AreaRelaID=" + model.AreaRelaID + "";
                int teamid = Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0]["TeamID"]);
                sql = "update team set `Name`='"+model.Name+"',`Position`='"+model.Position+"',WorkDate='"+model.WorkDate+"',ShenQing='"+model.ShenQing+ "',Image1='" + model.Image1+ "',Image2='" + model.Image2+"',TeamProduce='"+model.TeamProduce+"',SuccessCount='"+model.SuccessCount+ "',SuccessContent='"+model.SuccessContent+ "',SuccessKeyWord='" + model.SuccessKeyWord + "',SuccessProfile='"+model.SuccessProfile+"' where TeamID=" + teamid+"; ";
                sql += "update arearelation set TeamID="+teamid+",AreaID="+model.AreaID+" where arearelation.AreaRelaID="+model.AreaRelaID + "";

                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        /// <summary>
        /// 添加团队
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool InsertTeam(Team t)
        {
            try
            {
                string sql = "insert into team (Name,Position,WorkDate,ShenQing,Image1,Image2,TeamProduce) values(?name,?position,?workdate,?shenqing,?image1,?image2,?TeamProduce)";
                MySqlParameter[] pars =
                {
                new MySqlParameter("?name",t.Name),
                new MySqlParameter("?position",t.Position),
                new MySqlParameter("?workdate",t.WorkDate),
                new MySqlParameter("?shenqing",t.ShenQing),
                new MySqlParameter("?image1",t.Image1),
                new MySqlParameter("?image2",t.Image2),
                new MySqlParameter("?TeamProduce",t.TeamProduce)
                };
                MySqlDB.nonquery(sql, CommandType.Text, pars);
                string sql2 = "select TeamID from team ORDER BY TeamID desc LIMIT 1";
                int teamid = MySqlDB.scalar(sql2, CommandType.Text, null);
                string sql3 = "insert into arearelation (TeamID,AreaID) values(?teamid,?areaid)";
                MySqlParameter[] pars3 =
                {
                    new MySqlParameter("?teamid",teamid),
                    new MySqlParameter("?areaid",t.AreaID)
                };
                MySqlDB.nonquery(sql3, CommandType.Text, pars3);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion


    }
}
