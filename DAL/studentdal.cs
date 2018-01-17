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
    public class studentdal
    {
        //public int Stuadd(Models.student stu)
        //{
        //    try
        //    {

        //        string sql = "insert into student(StudentName,Score,Image,ImageType,JiuDuXueyuan) values('" + stu.StudentName + "','" + stu.Score + "','" + stu.Image + "','" + stu.JiuDuXueyuan + "')";
        //        MySqlDB.nonquery(sql, CommandType.Text, null);
        //        string sqll = "select   StudentID from student ORDER BY StudentID DESC limit 1";
        //        DataTable dt = MySqlDB.GetDataTable(sqll, CommandType.Text, null);
        //        int stuid = Convert.ToInt32(dt.Rows[0]["StudentID"]);
        //        string susql = "insert into successful(SuccessTitle,SuccessContent,SuccessDate)VALUES('"+stu.SuccessTitle+"','"+stu.SuccessContent+"','"+stu.SuccessDate+"')";
        //        MySqlDB.nonquery(susql, CommandType.Text, null);
        //        string sucsql = "select   SuccessId from successful ORDER BY SuccessID DESC limit 1";
        //        DataTable sudt = MySqlDB.GetDataTable(sucsql, CommandType.Text, null);
        //        int cgid= Convert.ToInt32(sudt.Rows[0]["SuccessId"]);
        //        string zhsql = "insert into successful_relation(SuccessID,CountryID,EducationID,StudentID,CollegeID)VALUES("+cgid+","+stu.countryid+","+stu.xueliid+","+stuid+","+stu.lqid+")";
        //        MySqlDB.nonquery(zhsql, CommandType.Text, null);
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}
        /// <summary>
        /// 学历添加
        /// </summary>
        /// <param name="ename"></param>
        /// <returns></returns>
        public int EaucationAdd(string ename)
        {
            try
            {
                string sql = "INSERT into educationtype(EducationName) VALUES('" + ename + "')";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取学历列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.educationtype> Edushow()
        {
            try
            {
                string sql = "select * from educationtype";
                List<JiaJiModels.educationtype> list = MySqlDB.GetList<JiaJiModels.educationtype>(sql, CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取团队列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Team> Tshow()
        {
            try
            {
                string sql = "SELECT * from team";
                return MySqlDB.GetList<JiaJiModels.Team>(sql, CommandType.Text, null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        /// <summary>
        /// 添加学生信息和学生团队关系表
        /// </summary>
        /// <returns></returns>
        public int stuadd(JiaJiModels.student stu)
        {
            try
            {
                string sql = "insert into student(StudentName,Score,Image,JiuDuXueyuan,EducationID) VALUES(?studentname,?score,?image,?jiuduxueyuan,?educationid)";
                MySqlParameter[] pars =
                {
                    new MySqlParameter("?studentname",stu.StudentName),
                    new MySqlParameter("?score",stu.Score),
                    new MySqlParameter("?image",stu.Image),
                    new MySqlParameter("?jiuduxueyuan",stu.JiuDuXueyuan),
                    new MySqlParameter("?educationid",stu.EducationID)
                };
                MySqlDB.nonquery(sql, CommandType.Text, pars);
                string stusql = "select   StudentID from student ORDER BY StudentID DESC limit 1";
                DataTable dt = MySqlDB.GetDataTable(stusql, CommandType.Text, null);
                int stid = Convert.ToInt32(dt.Rows[0]["StudentID"]);
                string slq = "insert into teamrelation(TeamID,StudentID) VALUES(?teamid,?studentid)";
                MySqlParameter[] parss =
                {
                    new MySqlParameter("?teamid",stu.teamid),
                    new MySqlParameter("?studentid",stid)
                };
                MySqlDB.nonquery(slq, CommandType.Text, parss);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #region 学生列表

        /// <summary>
        /// 获取学生列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.student> stushow()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select StudentID,StudentName,Score,student.CollegeID,CollegeImg,JiuDuXueyuan,student.EducationID,student.CountryID,country.CountryName,educationtype.EducationName ");
                sql.Append(" from student  ");
                sql.Append(" left join educationtype on student.EducationID=educationtype.EducationID ");
                sql.Append(" LEFT JOIN country ON student.CountryID=country.CountryID left join college on student.CollegeID=college.CollegeID order by StudentID desc ");

                List<JiaJiModels.student> studentlist = MySqlDB.GetList<JiaJiModels.student>(sql.ToString(), CommandType.Text, null);
                return studentlist;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelStudent(string StudentID)
        {
            try
            {

                string sql = "delete from successful_relation where StudentID in (" + StudentID + ");";
                sql += "delete from student where StudentID in (" + StudentID + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addStu(JiaJiModels.student model)
        {
            try
            {

                string sql = "insert into student(StudentName,Score,CollegeID,JiuDuXueyuan,EducationID,CountryID) VALUES('"+model.StudentName+"','"+model.Score+"',"+model.CollegeID+",'"+model.JiuDuXueyuan+"',"+model.EducationID+","+model.CountryID+")";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <returns></returns>
        public int UpdateStu(JiaJiModels.student model)
        {
            try
            {
                string sql = "Update study_abroad.student set StudentName = '" + model.StudentName + "', Score = '" + model.Score + "', CollegeID = " + model.CollegeID + ", `JiuDuXueyuan`= '" + model.JiuDuXueyuan  + "', EducationID = " + model.EducationID + ",CountryID =" + model.CountryID + " where StudentID =" + model.StudentID + " ";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion

        #region 国家页面留学规划
        /// <summary>
        /// 获取国家页面留学规划
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.studentprogramtype> showcounguihua()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select * from studentprogramtype ");

                List <JiaJiModels.studentprogramtype> studentlist = MySqlDB.GetList<JiaJiModels.studentprogramtype>(sql.ToString(), CommandType.Text, null);
                return studentlist;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 删除国家页面留学规划
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool Delcounguihua(string TypeID)
        {
            try
            {

                string sql = "delete from studentprogram where TypeID in ("+ TypeID + ");";
                sql = "delete from studentprogramtype where TypeID in (" + TypeID + ") ";

                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加国家页面留学规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addcounguihua(JiaJiModels.studentprogramtype model)
        {
            try
            {

                string sql = "insert into studentprogramtype(TypeName) VALUES('" + model.TypeName + "')";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 修改国家页面留学规划
        /// </summary>
        /// <returns></returns>
        public int Updatecounguihua(JiaJiModels.studentprogramtype model)
        {
            try
            {
                string sql = "Update study_abroad.studentprogramtype set TypeName = '" + model.TypeName + "' where TypeID =" + model.TypeID + " ";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }





        #endregion




    }
}
