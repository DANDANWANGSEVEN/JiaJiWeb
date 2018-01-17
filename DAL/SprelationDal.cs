using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using JiaJiModels;

namespace JiaJiDAL
{
    public class SprelationDal
    {
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


        #region 国家
        /// <summary>
        /// 获取国家信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.country> Countryshow()
        {
            try
            {
              
               string sql = "select * from country where IsCountry=1";
              
                List<JiaJiModels.country> list = MySqlDB.GetList<JiaJiModels.country>(sql, CommandType.Text, null);

                //var url = System.Configuration.ConfigurationManager.AppSettings["WebSiteUrl"].ToString();
                //list.ForEach(m => { m. = url.EndsWith("/") ? url + m.MediumImg : string.Format("{0}/{1}", url, m.MediumImg); });

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<JiaJiModels.country> allshow()
        {
            try
            {

                string sql = "select * from country";

                List<JiaJiModels.country> list = MySqlDB.GetList<JiaJiModels.country>(sql, CommandType.Text, null);

                //var url = System.Configuration.ConfigurationManager.AppSettings["WebSiteUrl"].ToString();
                //list.ForEach(m => { m. = url.EndsWith("/") ? url + m.MediumImg : string.Format("{0}/{1}", url, m.MediumImg); });

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取语言背景移民
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.country> LBYshow()
        {
            try
            {

                string sql = "select * from country where IsCountry=0";

                List<JiaJiModels.country> list = MySqlDB.GetList<JiaJiModels.country>(sql, CommandType.Text, null);

                //var url = System.Configuration.ConfigurationManager.AppSettings["WebSiteUrl"].ToString();
                //list.ForEach(m => { m. = url.EndsWith("/") ? url + m.MediumImg : string.Format("{0}/{1}", url, m.MediumImg); });

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除国家
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelCountry(string ids)
        {
            try
            {

                string sql = " delete from information where CountryID in (" + ids + ");";
                sql = " delete from information where CountryID in (" + ids + "); ";
                sql += "delete from active where CountryID in (" + ids + "); ";
                sql += "delete from strategy where CountryID in (" + ids + "); ";
                sql += "delete from student where CountryID in (" + ids + "); ";
                sql += " delete from studentprogram where CountryID in (" + ids + "); ";
                sql += "delete from sprelation where CountryID in (" + ids + ");";
                sql += "deletet from lunboimage where CountryID in (" + ids + "); ";
                sql += "delete from learner where CountryID in (" + ids + "); ";
                sql += "delete from countrydominant where CountryID in (" + ids + "); ";
                sql += "delete from country where CountryID in (" + ids + ")";

                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 添加国家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCountry(JiaJiModels.country model)
        {
            try
            {

                string sql = " INSERT into country(CountryName,CountryYouShi,CountryImg,CountryImg2,IsCountry,CountryActiveImg1,CountryActiveImg2) values('" + model.CountryName + "', '" + model.CountryYouShi + "', '" + model.CountryImg + "', '" + model.CountryImg2 + "',1,'"+model.CountryActiveImg1+"','"+model.CountryActiveImg2+"')";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 添加YBY
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddLBY(JiaJiModels.country model)
        {
            try
            {

                string sql = " INSERT into country(CountryName,CountryYouShi,CountryImg,CountryImg2,IsCountry) values('" + model.CountryName + "', '" + model.CountryYouShi + "', '" + model.CountryImg + "', '" + model.CountryImg2 + "',0)";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改国家
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdCountry(JiaJiModels.country model)
        {
            try
            {

                string sql = " update country set CountryName='"+model.CountryName+"',CountryYouShi='"+model.CountryYouShi+ "',CountryImg='" + model.CountryImg+ "',CountryImg2='" + model.CountryImg2+ "',CountryActiveImg1='" + model.CountryActiveImg1+ "',CountryActiveImg2='" + model.CountryActiveImg2+"' where CountryID=" + model.CountryID+" ";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region 留学规划文章
        /// <summary>
        /// 获取留学规划信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.StudentProgram> ShowLiuXueGuiHua()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select studentprogram.StudentProgramID,studentprogram.StudentProgramTitle,studentprogram.StudentProgramContent,studentprogram.`Source`,studentprogram.Author,studentprogram.ReadCount,studentprogram.ImageUrl,studentprogram.CountryID,studentprogram.EducationID,CountryName,EducationName,studentprogram.TypeID,TypeName,StudentKeyWord,StudentProfile ");
                sql.Append(" from studentprogram LEFT JOIN country on studentprogram.CountryID=Country.CountryID  ");
                sql.Append(" left join educationtype on studentprogram.EducationID=educationtype.EducationID left join studentprogramtype on studentprogram.TypeID=studentprogramtype.TypeID where studentprogram.EducationID=1 or studentprogram.EducationID=2  ORDER BY studentprogram.StudentProgramID desc  ");
                List<JiaJiModels.StudentProgram> sprelationlist = MySqlDB.GetList<JiaJiModels.StudentProgram>(sql.ToString(), CommandType.Text, null);
                return sprelationlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除留学规划信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelLiuXueGuiHua(string ids)
        {
            try
            {
                string sql = "delete from studentprogram where StudentProgramID in (" + ids + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 添加留学规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int StudentprogramAdd(JiaJiModels.StudentProgram model)
        {
            try
            {
                string sql = " INSERT into studentprogram(studentprogram.StudentProgramTitle,studentprogram.StudentProgramContent,studentprogram.`Source`,studentprogram.Author,studentprogram.ImageUrl,studentprogram.CountryID,studentprogram.EducationID,studentprogram.TypeID,ReadCount,StudentKeyWord,StudentProfile) values('" + model.StudentProgramTitle+"', '"+model.StudentProgramContent+"', '"+model.Source+"', '"+model.Author+"', '"+model.ImageUrl+"',"+model.CountryID+","+model.EducationID+ ","+model.TypeID+",0,'"+model.StudentKeyWord+"','"+model.StudentProfile+"') ";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        /// <summary>
        /// 修改留学规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdStudentprogram(JiaJiModels.StudentProgram model)
        {
            try
            {
                string sql = " update studentprogram set studentprogram.StudentProgramTitle='"+model.StudentProgramTitle+"',studentprogram.StudentProgramContent='"+model.StudentProgramContent+"',studentprogram.`Source`='"+model.Source+"',studentprogram.Author='"+model.Author+"',studentprogram.ImageUrl='" + model.ImageUrl+"',studentprogram.CountryID="+model.CountryID+",studentprogram.EducationID="+model.EducationID+ ",studentprogram.TypeID="+model.TypeID+ ",StudentKeyWord='"+model.StudentKeyWord+ "',StudentProfile='"+model.StudentProfile+"'  where studentprogram.StudentProgramID =" + model.StudentProgramID+"";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion


    }
}
