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
using System.IO;

namespace JiaJiNewWebDAL
{
    public class StudentProgramDAL : IStudentProgramDAL
    {

        #region 国家规划
        ///<summary>
        ///规划详情
        ///<para>Id:规划ID</para>
        /// </summary>
        public StudentProgram StudentShow(int Id)
        {
            try
            {
                string sql1 = "update `studentprogram` set ReadCount=ReadCount+1 where StudentProgramID=" + Id + "";
                MySqlDB.nonquery(sql1, CommandType.Text, null);
                string sql = "select * from studentprogram left join country on studentprogram.CountryID=country.CountryID left join educationtype on studentprogram.EducationID=educationtype.EducationID where StudentProgramID = @Id";
                MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                StudentProgram student = new StudentProgram();
                student.Author = dt.Rows[0]["Author"].ToString();
                //student.Image = Convert.ToBase64String((byte[])dt.Rows[0]["Image"]);
                student.CountryName = dt.Rows[0]["CountryName"].ToString();
                student.EducationName = dt.Rows[0]["EducationName"].ToString();
                student.ReadCount = (int)dt.Rows[0]["ReadCount"];
                student.StudentProgramContent = dt.Rows[0]["StudentProgramContent"].ToString();
                student.StudentProgramTitle = dt.Rows[0]["StudentProgramTitle"].ToString();
                student.Source = dt.Rows[0]["Source"].ToString();
                student.StudentKeyWord= dt.Rows[0]["StudentKeyWord"].ToString(); 
                student.StudentProfile = dt.Rows[0]["StudentProfile"].ToString();
                student.Imageurl= dt.Rows[0]["Imageurl"].ToString();

                Log4netHelper.WriteLog("日志报告");
                return student;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误日志", ex);
                throw ex;
            }

        }

        /// <summary>
        /// 获取具体国家规划列表
        /// </summary>
        /// <returns></returns>
        public List<StudentProgram> StudentProgramList(int pageindex)
        {
            try
            {
                int pagesize = 8;
                string sql = "SELECT SQL_CALC_FOUND_ROWS * FROM studentprogram left join country on studentprogram.CountryID=country.CountryID left join educationtype on studentprogram.EducationID=educationtype.EducationID  ORDER BY ReadCount DESC LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS(); ";

                List<StudentProgram> list = MySqlDB.GetList<StudentProgram>(sql, System.Data.CommandType.Text, null);
                //foreach (var v in list)
                //{
                //    v.StudentProgramContent = Help.Chinese(v.StudentProgramContent);
                //}
                //foreach (var item in list)
                //{
                //    if (item.StudentProgramContent.Length > 50)
                //    {
                //        item.StudentProgramContent = item.StudentProgramContent.Substring(0, 50) + "...";
                //    }
                //}

                return list;
            }
            catch(Exception ex)
            {
                Log4netHelper.WriteLog("错误日志", ex);
                return null;
            }
          
        }
        /// <summary>
        /// 获取国家规划页数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts()
        {
            try
            {
                string sql2 = "select count(1) from studentprogram";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
                return i = i % 8 == 0 ? i / 8 : (i / 8) + 1;
            }
            catch(Exception ex)
            {
                Log4netHelper.WriteLog("错误日志", ex);
                return 0;
            }
           
        }





        ///<summary>
        ///上一个规划
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public StudentProgram StudentPrev(int Id)
        {
            try
            {
                StudentProgram stu = new StudentProgram();
                DataTable dt1 = MySqlDB.GetDataTable("select min(StudentProgramID) from studentprogram", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    stu.StudentProgramTitle = "已是第一章了";
                    return stu;
                }
                else
                {
                    string sql = "select *  from studentprogram where StudentProgramID <@Id order by StudentProgramID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };

                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    stu.StudentProgramID = (int)dt.Rows[0]["StudentProgramID"];
                    stu.StudentProgramTitle = dt.Rows[0]["StudentProgramTitle"].ToString();
                    Log4netHelper.WriteLog("日志报告");
                    return stu;
                }

            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }
        ///<summary>
        ///下一个规划
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public StudentProgram StudentNext(int Id)
        {
            try
            {
                StudentProgram infor = new StudentProgram();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(StudentProgramID) from studentprogram", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.StudentProgramTitle = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from studentprogram where StudentProgramID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.StudentProgramID = (int)dt.Rows[0]["StudentProgramID"];
                    infor.StudentProgramTitle = dt.Rows[0]["StudentProgramTitle"].ToString();
                    Log4netHelper.WriteLog("日志报告");
                    return infor;

                }
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                return null;
            }
        }

        ///<summary>
        ///留学规划类别后五条
        ///<param></param>
        /// </summary>
        /// <returns></returns>
        public List<StudentProgramType> TypeShow()
        {
            try
            {
              
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * from studentprogramtype limit 5 ");

                List<StudentProgramType> list = MySqlDB.GetList<StudentProgramType>(sql.ToString(), CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        #endregion


        ///<summary>
        ///申请条件后四条
        /// </summary>
        /// <para></para>
        /// <returns></returns>
        public List<ApplyContentInfo> ApplyShow(int countryid,int educationid)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select applycontentinfo.ApplyConditionID,applycontentinfo.ApplyConditionID,ApplyTitle,applycontentinfo.ApplyContent,applycontentinfo.CountryID,CountryName,applycontentinfo.EducationID,EducationName from ApplyContentInfo  ");
                sql.Append(" left join applycondition on applycontentinfo.ApplyConditionID=applycondition.ApplyID ");
                sql.Append(" left join country on applycontentinfo.CountryID=country.CountryID ");
                sql.Append(" left join educationtype on applycontentinfo.EducationID=educationtype.EducationID ");
                sql.Append(" where applycontentinfo.CountryID="+countryid+" and applycontentinfo.EducationID="+educationid+" ");
                sql.Append(" GROUP BY applycontentinfo.ApplyConditionID order by applycondition.ApplyID ");

                List<ApplyContentInfo> list = MySqlDB.GetList<ApplyContentInfo>(sql.ToString(), CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        ///<summary>
        ///申请时间规划表
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ArrangeTime> ArrangeShow(int countryid,int educationid)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select ArrangeID,ArrangeMonth,ArrangeContent from arrangetime where CountryID="+countryid+" and EducationID="+educationid+ " GROUP BY ShowID ORDER BY ShowID limit 7 ");

                List<ArrangeTime> list = MySqlDB.GetList<ArrangeTime>(sql.ToString(), CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }

        }



    }
}
