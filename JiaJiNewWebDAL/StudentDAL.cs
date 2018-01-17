using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JiaJiNewWeb.Common;
namespace JiaJiNewWebDAL
{
  public  class StudentDAL:JiaJiNewWebIDAL.IStudentDAL
    {
       /// <summary>
       /// 获取学生的轮播信息
       /// </summary>
       /// <param name="Index">开始条数</param>
       /// <param name="GoIndex">结束条数</param>
       /// <returns>学生信息的List集合</returns>
        public List<JiaJiNewWebModel.StudentIndexModel> StudentIndexList(int Index,int GoIndex)
        { 
            try
            {
                //select a.StudentName,a.JiuDuXueyuan,a.Score,a.CollegeID,d.CollegeImg,d.CollegeName,b.SuccessID,CountryName,EducationName from student a
                //               INNER JOIN Successful_Relation b on a.StudentID = b.StudentID
                //               INNER JOIN College d ON b.CollegeID = d.CollegeID left join country on a.CountryID = country.CountryID left join educationtype on a.EducationID = educationtype.EducationID  LIMIT " + Index + ","+ GoIndex+ "; SELECT FOUND_ROWS(); "; 

                string sql = @"select SRelationID,StudentName,JiuDuXueyuan,Score,student.CollegeID,CollegeName,college.CollegeImg,educationtype.EducationName from Successful_Relation" +
                              " left join student on Successful_Relation.StudentID=student.StudentID" +
                              " left join educationtype on educationtype.EducationID=student.EducationID" +
                              " left join College on student.CollegeID=College.CollegeID LIMIT " + Index + "," + GoIndex + "; SELECT FOUND_ROWS();"
                              ;

                List<JiaJiNewWebModel.StudentIndexModel> list = MySqlDB.GetList<JiaJiNewWebModel.StudentIndexModel>(sql, CommandType.Text, null);             
                Log4netHelper.WriteLog("系统日志，请求了StudentDAL类下的StudentIndexList方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;

            }


        }



        /// <summary>
        /// 获取每个国家的学生
        /// </summary>
        /// <param name="Index">开始条数</param>
        /// <param name="GoIndex">结束条数</param>
        /// <returns>学生信息的List集合</returns>
        public List<JiaJiNewWebModel.StudentIndexModel> CountryStuList(int countryid,int Index, int GoIndex)
        {
            try
            {
                //string sql = @"select a.StudentName,a.JiuDuXueyuan,a.Score,a.CollegeID,d.CollegeImg,d.CollegeName,b.SuccessID,a.CountryID,CountryName,EducationName from student a 
                //               INNER JOIN Successful_Relation b on a.StudentID=b.StudentID 
                //               INNER JOIN College d ON b.CollegeID=d.CollegeID left join country on a.CountryID=country.CountryID left join educationtype on a.EducationID=educationtype.EducationID where a.CountryID=" + countryid + "  LIMIT " + Index + "," + GoIndex + "; SELECT FOUND_ROWS();";

                string sql = @"select SRelationID,StudentName,JiuDuXueyuan,Score,student.CollegeID,CollegeName,college.CollegeImg,educationtype.EducationName from Successful_Relation" +
                              " left join student on Successful_Relation.StudentID=student.StudentID" +
                              " left join educationtype on educationtype.EducationID=student.EducationID" +
                              " left join College on student.CollegeID=College.CollegeID where CountryID="+ countryid + " LIMIT " + Index + "," + GoIndex + "; SELECT FOUND_ROWS();"
                              ;



                List<JiaJiNewWebModel.StudentIndexModel> list = MySqlDB.GetList<JiaJiNewWebModel.StudentIndexModel>(sql, CommandType.Text, null);
                Log4netHelper.WriteLog("系统日志，请求了StudentDAL类下的StudentIndexList方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;

            }


        }



        /// <summary>
        /// 获取学生信息的数量
        /// </summary>
        /// <returns></returns>
        public int CountStudentInfo()
        {

            try
            {
                string sql = @"select COUNT(1) from Successful_Relation a INNER JOIN student b on a.StudentID = b.StudentID INNER JOIN College d ON b.CollegeID = d.CollegeID ";

                int ids= MySqlDB.scalar(sql, CommandType.Text, null);
                Log4netHelper.WriteLog("系统日志：请求了ActiveDal类下的CountStudentInfo方法");
                return ids;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return 0;
            }
          
        }
    }
}
