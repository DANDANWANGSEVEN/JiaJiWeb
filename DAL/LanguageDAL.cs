using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace JiaJiDAL
{
    public class LanguageDAL
    {

        #region 学员分享
        /// <summary>
        /// 学员分享
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ShareModel> ShowShare()
        {
            
            try
            {
                string sql = "SELECT ShareID,ShareTitle,ShareContent,shares.LearnerID,Learner.LearnName,ShareDate,shares.Pro_ID,projectitem.Pro_Name,ShareImg,ShareKeyword,ShareProfile,ShareReadCount from shares left join  Learner on shares.LearnerID=Learner.LearnerID LEFT JOIN projectitem on shares.Pro_ID=projectitem.Pro_ID order by ShareID desc ";
                List<JiaJiModels.ShareModel> list = MySqlDB.GetList<JiaJiModels.ShareModel>(sql, CommandType.Text, null);

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加学员分享
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddShare(JiaJiModels.ShareModel model)
        {

            try
            {
                string sql = "insert into shares(ShareTitle,ShareContent,LearnerID,ShareDate,Pro_ID,ShareImg,ShareKeyword,ShareProfile,ShareReadCount) values('" + model.ShareTitle+"','"+model.ShareContent+"',"+model.LearnerID+",'"+model.ShareDate+"',"+model.Pro_ID+ ",'" + model.ShareImg+"','"+model.ShareKeyword+"','"+model.ShareProfile+"',0)";
                return MySqlDB.nonquery(sql,System.Data.CommandType.Text,null);

            }
            catch(Exception ex)
            {
                return 0;
            }
        }



        /// <summary>
        /// 删除学员分享
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteShare(string shareids)
        {

            try
            {
                string sql = "delete form shares where ShareID="+ shareids + "";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 修改学员分享
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateShare(JiaJiModels.ShareModel model)
        {

            try
            {
                string sql = "Update shares set ShareTitle='"+model.ShareTitle+"',ShareContent='"+model.ShareContent+"',LearnerID="+model.LearnerID+",ShareDate='"+model.ShareDate+"',Pro_ID="+model.Pro_ID+ ",ShareImg='" + model.ShareImg+ "',ShareKeyword='"+model.ShareKeyword+"',ShareProfile='"+model.ShareProfile+"'  where ShareID=" + model.ShareID+"";
                return MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion

        #region 语言管理
        /// <summary>
        /// 显示语言
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Languages> ShowLanguage()
        {
            try
            {
                string sql = "select * from Languages";
                List<JiaJiModels.Languages> list = MySqlDB.GetList<JiaJiModels.Languages>(sql, CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加语言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addLanguage(JiaJiModels.Languages model)
        {
            try
            {

                string sql = "insert into Languages(LanguageName,LanguageTitle,LanguageContent) values('" + model.LanguageName + "','" + model.LanguageTitle + "','"+model.LanguageContent+"')";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除语言
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelLanguage(string did)
        {
            try
            {
                string sql = "delete from languagerelation where LanguageID in (" + did + "); ";
                 sql += "delete from Languages where LanguageID in (" + did + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改语言
        /// </summary>
        /// <returns></returns>
        public int UpdateLanguage(JiaJiModels.Languages model)
        {
            try
            {
                string sql = "UPDATE course set LanguageName='" + model.LanguageName + "',LanguageTitle='" + model.LanguageTitle + "',LanguageContent='"+model.LanguageContent+ "' where LanguageID=" + model.LanguageID + "";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion

        #region 课程管理
        /// <summary>
        /// 语言课程关系显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.languagerelation> ShowLangCour()
        {
            try
            {
                string sql = "select * from languagerelation left join course on languagerelation.CourseID = course.CourseID left join languages on languagerelation.LanguageID = languages.LanguageID ORDER BY LRelationID DESC";
                List<JiaJiModels.languagerelation> list = MySqlDB.GetList<JiaJiModels.languagerelation>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 显示课程
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.CourseModel> ShowCourse()
        {
            try
            {
                string sql = "select * from course";
                List<JiaJiModels.CourseModel> list = MySqlDB.GetList<JiaJiModels.CourseModel>(sql, CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addCourse(JiaJiModels.CourseModel model)
        {
            try
            {

                string sql = "insert into course(CourseName,CourseContent,CourseDetail,CourseReadCount,CourseDate,CourseKeyWord) values ('" + model.CourseName + "','" + model.CourseContent + "','"+model.CourseDetail+"',0,'"+model.CourseDate+"','"+model.CourseKeyWord+"');select @@IDENTITY; ";

                int courseid =Convert.ToInt32( MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][0]);

                sql = "insert into languagerelation(LanguageID, Courseid) values(" + model.LanguageID + ","+ courseid + ")";

                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除课程
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelCourse(string did)
        {
            try
            {
                //首先在关系中查出该选中关系的编号
                string sql = "select* from languagerelation where LRelationID in (" + did + ") ";

                //获取选中关系编号对应的课程编号
                string courseids = "";
                var dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    courseids += dt.Rows[i][2].ToString() + ",";
                }
                courseids = courseids.TrimEnd(',');

                //删除选中的关系编号
                sql = "delete from languagerelation where LRelationID in (" + did + ");";
                //删除课程表中相对应的课程
                sql += "delete from course where CourseID in ("+ courseids + ")";
                
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <returns></returns>
        public int UpdateCourse(JiaJiModels.languagerelation model)
        {
            try
            {

                //首先查出选中关系表中的主键
                string sql = "select * from languagerelation where LRelationID=" + model.LRelationID+"";
                int courseid = Convert.ToInt32(MySqlDB.GetDataTable(sql, CommandType.Text, null).Rows[0][2]);
                sql = "UPDATE course set CourseName='" + model.CourseName + "',CourseContent='" + model.CourseContent + "',CourseDetail='"+model.CourseDetail+ "',CourseDate='"+model.CourseDate+"',CourseKeyWord='"+model.CourseKeyWord+"' where course.CourseID=" + courseid + ";";
                sql += "update languagerelation set LanguageID=" + model.LanguageID + ",CourseID=" + courseid + " where LRelationID=" + model.LRelationID + " ";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        /// <summary>
        /// 课程添加
        /// </summary>
        /// <param name="model"></param>
        /// <param name="LanID"></param>
        /// <returns></returns>
        //public int CourseAdd(JiaJiModels.CourseModel model)
        //{
        //    string sql = "insert into course(CourseName,CourseContent)values(@Name,@Content)";
        //    MySqlParameter[] para = {
        //        new MySqlParameter("@Name",model.CourseName),
        //        new MySqlParameter("@Content",model.CourseContent)
        //    };
        //    MySqlDB.nonquery(sql, CommandType.Text, para);
        //    string sql1 = "select CourseID from course where CourseName=@CourseName";
        //    MySqlParameter[] para1 = {
        //        new MySqlParameter("@CourseName",model.CourseName)
        //    };
        //    DataTable dt = MySqlDB.GetDataTable(sql1, CommandType.Text, para1);
        //    int CourseID = (int)dt.Rows[0][0];
        //    string sql2 = "insert into languagerelation(LanguageID,CourseID)values(@LanID,@CourseID)";
        //    MySqlParameter[] para2 = {
        //        new MySqlParameter("@LanID",model.LanguageID),
        //        new MySqlParameter("@CourseID",CourseID)
        //    };
        //    MySqlDB.nonquery(sql2, CommandType.Text, para2);
        //    return 1;
        //}
        #endregion

        #region 语言培训

        /// <summary>
        /// 显示语言培训
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Language_PeiXun> ShowLanguagePeiXun()
        {
            try
            {
                string sql = "select * from language_peixun ";
                List<JiaJiModels.Language_PeiXun> list = MySqlDB.GetList<JiaJiModels.Language_PeiXun>(sql, CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加语言培训
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addLanguagePeiXun(JiaJiModels.Language_PeiXun model)
        {
            try
            {
                string sql = "insert into language_peixun(Language_Name,Language_Content) values('" + model.Language_Name + "','" + model.Language_Content + "')";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除语言培训
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelLanguagePeiXun(string did)
        {
            try
            {
                string sql = "delete from language_peixun where LanguagePx_ID in (" + did + "); ";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改语言培训
        /// </summary>
        /// <returns></returns>
        public int UpdateLanguagePeiXun(JiaJiModels.Language_PeiXun model)
        {
            try
            {
                string sql = "UPDATE language_peixun set Language_Name='" + model.Language_Name + "',Language_Content='" + model.Language_Content + "' where LanguagePx_ID=" + model.LanguagePx_ID + "";
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
        /// 语言添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int LanguageAdd(JiaJiModels.LearnerModel model)
        {
            string sql = "insert into languages(LanguageName,LanguageTitle,LanguageContent)value(@Name,@Title,@Content)";
            MySqlParameter[] para = {
                new MySqlParameter("@Name",model.LanguageName),
                new MySqlParameter("@TItle",model.LanguageTitle),
                new MySqlParameter("@Content",model.LanguageContent)
            };
            return MySqlDB.nonquery(sql, System.Data.CommandType.Text, para);
        }

        /// <summary>
        /// 获取背景提升项目
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.projectitem> Project()
        {
            string sql = "select * from projectitem";
            List<JiaJiModels.projectitem> list = MySqlDB.GetList<JiaJiModels.projectitem>(sql, CommandType.Text, null);
            return list;
        }
       
        


    }
}
