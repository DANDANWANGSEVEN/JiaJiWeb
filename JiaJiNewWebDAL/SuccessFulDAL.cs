using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using MySql.Data.MySqlClient;
using System.Data;
using JiaJiNewWeb.Common;
using JiaJiNewWebIDAL;


namespace JiaJiNewWebDAL
{
    public class SuccessFulDAL : ISuccessFulDAL
    {
        /// <summary>
        /// 获取成功案列详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SuccessInfor SuccessfulShow(int Id)
        {
            try
            {
                //string sql = "select * from successful_relation " +
                //    "INNER JOIN student d ON a.StudentID = d.StudentID " +
                //    "INNER JOIN country b ON d.CountryID = b.CountryID " +
                //     "INNER JOIN educationtype c ON d.EducationID = c.EducationID " +
                //     "INNER JOIN successful e ON a.SuccessID = e.SuccessID " +
                //     "INNER JOIN college f ON a.CollegeID = f.CollegeID where a.SRelationID=@Id";

                StringBuilder sql = new StringBuilder();
                sql.Append(" select * from successful_relation ");
                sql.Append(" left join successful on successful_relation.SuccessID=successful.SuccessID ");
                sql.Append(" left join student on student.StudentID=successful_relation.StudentID ");
                sql.Append(" LEFT JOIN college on college.CollegeID=student.CollegeID ");
                sql.Append(" left join educationtype on educationtype.EducationID=student.EducationID ");
                sql.Append(" left join country on country.CountryID=student.CountryID ");
                sql.Append(" where successful_relation.SRelationID=@Id ");

                MySqlParameter[] para = {
                    new MySqlParameter("@Id",Id)
                };
                DataTable dt = MySqlDB.GetDataTable(sql.ToString(), CommandType.Text, para);
                SuccessInfor infor = new SuccessInfor();
                infor.StudentName = dt.Rows[0]["StudentName"].ToString();
                //infor.CollegeID =(int)dt.Rows[0]["CollegeID"];
                infor.CollegeName = dt.Rows[0]["CollegeName"].ToString();
                infor.CountryName = dt.Rows[0]["CountryName"].ToString();
                infor.EducationName = dt.Rows[0]["EducationName"].ToString();
                infor.JiuDuXueyuan = dt.Rows[0]["JiuDuXueyuan"].ToString();
                infor.Score = dt.Rows[0]["Score"].ToString();
                infor.SuccessContent = dt.Rows[0]["SuccessContent"].ToString();
                infor.SuccessDate = dt.Rows[0]["SuccessDate"].ToString();
                infor.SuccessTitle = dt.Rows[0]["SuccessTitle"].ToString();

                Log4netHelper.WriteLog("日志报告");
                return infor;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }
        ///<summary>
        ///上一个成功案列
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public SuccessInfor SuccessPrev(int Id)
        {
            try
            {
                SuccessInfor infor = new SuccessInfor();
                DataTable dt1 = MySqlDB.GetDataTable("select min(SRelationID) from successful_relation", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    infor.SuccessTitle = "已是第一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from successful_relation a INNER JOIN successful e ON a.SuccessID = e.SuccessID  where SRelationID <@Id order by SRelationID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.SuccessID = (int)dt.Rows[0]["SRelationID"];
                    infor.SuccessTitle = dt.Rows[0]["SuccessTitle"].ToString();
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
        ///下一个成功案列
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public SuccessInfor SuccessNext(int Id)
        {
            try
            {
                SuccessInfor infor = new SuccessInfor();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(SRelationID) from successful_relation", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.SuccessTitle = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from successful_relation a INNER JOIN successful e ON a.SuccessID = e.SuccessID  where SRelationID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.SuccessID = (int)dt.Rows[0]["SRelationID"];
                    infor.SuccessTitle = dt.Rows[0]["SuccessTitle"].ToString();
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

    }
}
