using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
namespace JiaJiDAL
{
    public class Anlidal
    {


        #region 成功案例

        /// <summary>
        /// 显示成功案例列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public List<JiaJiModels.Anli> ShowSuccessAnli()
        {
            try
            {
                StringBuilder sqlstring = new StringBuilder();
                sqlstring.Append(" select SRelationID,successful_relation.StudentID,successful.SuccessID,StudentName,SuccessTitle,SuccessContent from successful_relation  ");
                sqlstring.Append(" left join successful on successful_relation.SuccessID=successful.SuccessID ");
                //sqlstring.Append(" left join team_anli on successful_relation.SuccessID=team_anli.SuccessID ");
                //sqlstring.Append(" left join team on team.TeamID=team_anli.TeamID ");
                sqlstring.Append(" left join student on successful_relation.StudentID=student.StudentID order by successful_relation.SRelationID DESC ");
                List<JiaJiModels.Anli> list = MySqlDB.GetList<JiaJiModels.Anli>(sqlstring.ToString(), CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 删除成功案例
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DelAnli(string ids)
        {
            try
            {
                string sql = "select * from successful_relation where SRelationID in (" + ids + ")";
                string successid = "";
                var dt = MySqlDB.GetDataTable(sql,CommandType.Text, null);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    successid += dt.Rows[i][1].ToString() + ",";
                }
                successid = successid.TrimEnd(',');
                sql = "delete from successful where SuccessID in (" + successid + ") ;";
                sql += "delete from team_anli where SuccessID in (" + successid + ") ;";
                sql += "delete from successful_relation where SRelationID in (" + ids + ") ";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 成功案例添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Anliadd(JiaJiModels.Anli model,int teamid)
        {
            try
            {
                
                string sql = "insert into successful(SuccessTitle,SuccessContent,SuccessDate) VALUES('"+model.SuccessTitle+"', '"+model.SuccessContent+"', '"+model.SuccessDate+ "');select @@IDENTITY";

                int successid = Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][0]);

                sql = "insert into successful_relation(SuccessID,StudentID) VALUES("+ successid + ","+model.StudentID+");";
                //sql += "insert into team_anli(TeamID,SuccessID) VALUES("+ teamid + "," + successid + ")";

                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;

            }
            catch (Exception)
            {

                return 0;
            }
        }

        /// <summary>
        /// 修改成功案例
        /// </summary>
        /// <returns></returns>
        public int UpdateAnLi(JiaJiModels.Anli model,int teamid)
        {
            try
            {
                //查出关系表中的内容
                string sql = "select * from successful_relation where SRelationID=" + model.SRelationID + "";
                int successid = Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][1]);
                string teamidsql = "select count(1) from team_anli where SuccessID="+ successid + " ";
                int countteam = MySqlDB.scalar(teamidsql, CommandType.Text, null);
                sql = "update successful set SuccessTitle='"+model.SuccessTitle+"',SuccessContent='"+model.SuccessContent+"',SuccessDate='"+model.SuccessDate+"' where SuccessID="+successid+"; ";
                if (countteam > 0)
                {
                    sql += "update team_anli set team_anli.TeamID=" + teamid + " where SuccessID=" + successid + ";";
                }
                else
                {
                    sql += "insert into team_anli(TeamID,SuccessID) VALUES(" + teamid + "," + successid + ");";
                }
                sql += "update successful_relation set StudentID="+model.StudentID+ " where SuccessID=" + successid + " ";

                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion





        /// <summary>
        /// 显示成功案例列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        //public List<JiaJiModels.Anli> ShowSuccessAnli()
        //{
        //    try
        //    {
        //        StringBuilder sqlstring = new StringBuilder();
        //        sqlstring.Append(" select StudentName,student.EducationID, EducationName,successful_relation.CountryID,CountryName,CollegeName,SuccessTitle,SuccessContent,SuccessDate,JiuDuXueyuan from successful_relation left join successful on successful_relation.SuccessID=successful.SuccessID ");
        //        sqlstring.Append(" left join country on successful_relation.CountryID=country.CountryID ");
        //        sqlstring.Append(" left join student on successful_relation.StudentID=student.StudentID ");
        //        sqlstring.Append(" left join college on successful_relation.CollegeID=college.CollegeID ");
        //        sqlstring.Append(" left join educationtype on educationtype.EducationID=student.EducationID ");
        //        List<JiaJiModels.Anli> list = MySqlDB.GetList<JiaJiModels.Anli>(sqlstring.ToString(), CommandType.Text, null);
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}




        /// <summary>
        /// 成功关系表添加
        /// </summary>
        /// <param name="successID"></param>
        /// <param name="CountryID"></param>
        /// <param name="studentID"></param>
        /// <param name="collegeID">录取学院ID</param>
        /// <returns></returns>
        public int AddSuccessRealtion(int successID,int CountryID,int studentID,int collegeID)
        {

            string sql = "insert into successful_relation(successID,CountryID,studentid,collegeID) values (" + successID + "," + CountryID + "," + studentID + "," + collegeID + ")";
            return MySqlDB.nonquery(sql,CommandType.Text,null);
        }




    }
}
