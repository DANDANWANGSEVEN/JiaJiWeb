using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using System.Data;
using MySql.Data.MySqlClient;
using JiaJiNewWeb.Common;
using JiaJiNewWebIDAL;

namespace JiaJiNewWebDAL
{
    public class LanguageDAL : ILanguageDAL
    {
        /// <summary>
        /// 语言类别
        /// <para>Id:语言ID</para>
        /// </summary>
        /// <returns></returns>
        public Language LanguageShow(int Id)
        {
            try
            {               
                string sql = "select * from Languages where LanguageID='" + Id + "'";
                Language la = new Language();
                DataTable dt = MySqlDB.GetDataTable(sql,CommandType.Text,null);
                la.LanguageName = dt.Rows[0]["LanguageName"].ToString();
                la.LanguageTitle = dt.Rows[0]["LanguageTitle"].ToString();
                la.LanguageContent = dt.Rows[0]["LanguageContent"].ToString();
                return la;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
            
        }
        /// <summary>
        /// 语言课程
        /// </summary>
        /// <param name="Id">语言类别ID</param>
        /// <returns></returns>
        public List<Course> CourseShow(int Id)
        {
            try
            {
                string sql = "SELECT c.* from languagerelation a  INNER JOIN `languages` b on a.LanguageID=b.LanguageID " +
                                        "INNER JOIN course c on a.CourseID = c.CourseID where b.LanguageID = @Id limit 3";
                MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                List<Course> list = MySqlDB.GetList<Course>(sql, CommandType.Text, para);
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }

        /// <summary>
        /// 课程详情
        /// </summary>
        /// <param name="LearnSorceID"></param>
        /// <returns></returns>
        public JiaJiNewWebModel.Course CourseDetail(int courseid)
        {
            try
            {
                string sql = "update course set CourseReadCount=CourseReadCount+1 where CourseID="+ courseid + ";";
                sql += "SELECT * from course where CourseID="+ courseid ;
                Course model = new Course();
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                model.CourseID = (int)dt.Rows[0]["CourseID"];
                model.CourseName = dt.Rows[0]["CourseName"].ToString();
                model.CourseContent = dt.Rows[0]["CourseContent"].ToString();
                model.CourseDetail = dt.Rows[0]["CourseDetail"].ToString();
                model.CourseReadCount = Convert.ToInt32(dt.Rows[0]["CourseReadCount"].ToString());
                model.CourseDate = dt.Rows[0]["CourseDate"].ToString();
                model.CourseKeyWord = dt.Rows[0]["CourseKeyWord"].ToString();

                return model;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }
        ///<summary>
        ///上一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        public JiaJiNewWebModel.Course CoursePrev(int Id)
        {
            try
            {
                Course model = new Course();
                DataTable dt1 = MySqlDB.GetDataTable("select min(CourseID) from course", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.CourseName = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from course  where CourseID <@Id order by CourseID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.CourseID = (int)dt.Rows[0]["CourseID"];
                    model.CourseName = dt.Rows[0]["CourseName"].ToString();
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
        ///下一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        public JiaJiNewWebModel.Course CourseNext(int Id)
        {
            try
            {
                Course infor = new Course();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(CourseID) from course", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.CourseName = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from course where CourseID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.CourseID = (int)dt.Rows[0]["CourseID"];
                    infor.CourseName = dt.Rows[0]["CourseName"].ToString();
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
        ///语言学员列表
        /// <para>ID:语言ID</para>
        /// </summary>
        public List<JiaJiNewWebModel.LernerScore> LearnShow(int Id)
        {
            try
            {
               
                string sql = "SELECT a.LearnerID,a.LearnSorceID,a.Sorce,a.LearnerGonsis,c.LearnName,c.LearnImage,a.LearnerContent,a.HeatHot from learnsorce a INNER JOIN `languages` b on a.LanguageID=b.LanguageID " +
                             " INNER JOIN learner c on a.LearnerID = c.LearnerID where b.LanguageID = "+Id+" LIMIT 3";
             
                List<LernerScore> list = MySqlDB.GetList<LernerScore>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }

        /// <summary>
        /// 分页显示高分学员
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public List<JiaJiNewWebModel.LernerScore> PageLearnShow(int Id, int pageindex)
        {
            try
            {
                int pagesize = 5;
                string sql = "SELECT SQL_CALC_FOUND_ROWS a.LearnSorceID,a.LearnerID,a.LearnSorceID,a.Sorce,a.LearnerGonsis,c.LearnName,c.LearnImage,a.LearnerContent,a.LanguageID,b.LanguageName from learnsorce a INNER JOIN `languages` b on a.LanguageID=b.LanguageID " +
                             " INNER JOIN learner c on a.LearnerID = c.LearnerID where b.LanguageID = "+Id+"  LIMIT " + (pageindex - 1) * pagesize + "," + pagesize + ";" +
            " SELECT FOUND_ROWS(); ";
             
                List<LernerScore> list = MySqlDB.GetList<LernerScore>(sql, System.Data.CommandType.Text, null);
                return list.ToList();
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }

        /// <summary>
        /// js获取高分学员的数量
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        public int GetRowCounts(int languageid)
        {
            try
            {
                string sql2 = "SELECT count(1) from learnsorce a INNER JOIN `languages` b on a.LanguageID=b.LanguageID " +
                             " INNER JOIN learner c on a.LearnerID = c.LearnerID where b.LanguageID = " + languageid + "";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);

                return i % 5 == 0 ? i / 5 : (i / 5) + 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        /// <summary>
        /// 高分学员详细页面
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JiaJiNewWebModel.LernerScore MaxStuContent(int LearnSorceID)
        {
            try
            {
                string sql = "update learnsorce set HeatHot=HeatHot+1 where learnsorce.LearnSorceID=" + LearnSorceID + ";";
                sql += "SELECT a.LearnSorceID,a.LearnerID,a.Sorce,a.LearnerGonsis,c.LearnName,c.LearnImage,a.LearnerContent,a.HeatHot,a.LanguageID,b.LanguageName from learnsorce a INNER JOIN `languages` b on a.LanguageID = b.LanguageID INNER JOIN learner c on a.LearnerID = c.LearnerID INNER JOIN country d on c.CountryID = d.CountryID where a.LearnSorceID = " + LearnSorceID + "";
                LernerScore la = new LernerScore();
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                la.LearnSorceID= (int)dt.Rows[0]["LearnSorceID"];
                la.LearnerID= (int)dt.Rows[0]["LearnerID"];
                la.Sorce= dt.Rows[0]["Sorce"].ToString();
                la.LearnerGonsis = dt.Rows[0]["LearnerGonsis"].ToString();
                la.LearnName = dt.Rows[0]["LearnName"].ToString();
                la.LanguageID = (int)dt.Rows[0]["LanguageID"];
                la.LanguageName = dt.Rows[0]["LanguageName"].ToString();
                la.LearnImage = dt.Rows[0]["LearnImage"].ToString();
                la.LearnerContent = dt.Rows[0]["LearnerContent"].ToString();
                la.HeatHot=(int)dt.Rows[0]["HeatHot"];
                return la;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }

        ///<summary>
        ///上一个高分学员
        ///<para>Id:高分学员Id</para>
        /// </summary>
        public JiaJiNewWebModel.LernerScore MaxStuContentPrev(int Id)
        {
            try
            {
                LernerScore model = new LernerScore();
                DataTable dt1 = MySqlDB.GetDataTable("select min(LearnSorceID) from learnsorce", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.LearnerGonsis = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "SELECT a.LearnSorceID,a.LearnerID,a.Sorce,a.LearnerGonsis,c.LearnName,c.LearnImage,a.LearnerContent,a.HeatHot from learnsorce a INNER JOIN `languages` b on a.LanguageID=b.LanguageID INNER JOIN learner c on a.LearnerID = c.LearnerID where a.LearnSorceID <@Id order by LearnSorceID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.LearnSorceID = (int)dt.Rows[0]["LearnSorceID"];
                    model.LearnerGonsis = dt.Rows[0]["LearnerGonsis"].ToString();
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
        ///下一个高分学员
        ///<para>Id:高分学员Id</para>
        /// </summary>
        public JiaJiNewWebModel.LernerScore MaxStuContentNext(int Id)
        {
            try
            {
                LernerScore infor = new LernerScore();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(LearnSorceID) from learnsorce", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.LearnerGonsis = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "SELECT a.LearnSorceID,a.LearnerID,a.Sorce,a.LearnerGonsis,c.LearnName,c.LearnImage,a.LearnerContent,a.HeatHot from learnsorce a INNER JOIN `languages` b on a.LanguageID=b.LanguageID INNER JOIN learner c on a.LearnerID = c.LearnerID where a.LearnSorceID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.LearnSorceID = (int)dt.Rows[0]["LearnSorceID"];
                    infor.LearnerGonsis = dt.Rows[0]["LearnerGonsis"].ToString();
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
        ///语言显示
        /// </summary>
        public List<Language> Language()
        {
            try
            {
                string sql = "select * from Languages";
                List<Language> list = MySqlDB.GetList<Language>(sql, CommandType.Text, null);
                return list;
            }
            catch(Exception e)
            {
                return null;
            }
           
        }
        /// <summary>
        /// 获取语言培训的内容信息
        /// </summary>
        /// <returns></returns>
        public  List<JiaJiNewWebModel.Language_PeiXunModel> GetPeixunList()
        {
            try
            {
                string sql = "select  Language_Name,Language_Content from Language_PeiXun limit 6";
                List<Language_PeiXunModel> list = MySqlDB.GetList<Language_PeiXunModel>(sql, CommandType.Text,null);
                return list;
          
            } 
           
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }


    }
}
