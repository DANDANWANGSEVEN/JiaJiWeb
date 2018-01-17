using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiDAL
{
    public class LearnerDal
    {

        #region 学员列表

        /// <summary>
        /// 获取学员列表
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.LearnerModel> showLearner()
        {
            try
            {
                string sql = "select * from learner left join country on learner.CountryID = country.CountryID order by LearnerID desc ";
                List<JiaJiModels.LearnerModel> list = MySqlDB.GetList<JiaJiModels.LearnerModel>(sql.ToString(),System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加学员列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addLearner(JiaJiModels.LearnerModel model)
        {
            try
            {

                string sql = "INSERT INTO study_abroad.learner (LearnName,Phone, GoTime, LearnImage,CountryID)VALUES ('"+model.LearnName+"','"+model.Phone+"','"+model.GoTime+ "','" + model.LearnImage+"',"+model.CountryID+")";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除学员列表
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelLearner(string did)
        {
            try
            {
                //string sql = "delete from learner where LearnerID in (" + did + ");";
                //sql += "delete from shares where LearnerID in (" + did + ");";
                //sql += "delete from learnsorce where LearnerID in (" + did + "); ";

                string sql = "delete from shares where LearnerID in (" + did + ")";
                sql = "delete from learnsorce where LearnerID in (" + did + ");";
                sql += "delete from learner where LearnerID in (" + did + ");";

                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改学员列表
        /// </summary>
        /// <returns></returns>
        public int UpdateLearner(JiaJiModels.LearnerModel model)
        {
            try
            {
                string sql = "Update study_abroad.learner set LearnName = '" + model.LearnName + "', Phone = '" + model.Phone + "', GoTime = '" + model.GoTime + "', `LearnImage`= '" + model.LearnImage + "', CountryID = " + model.CountryID + " where LearnerID =" + model.LearnerID + " ";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region 高分学员

        /// <summary>
        /// 获取高分学员列表
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.LearnerModel> showMaxScoStu()
        {
            try
            {
                string sql = "select * from learnsorce left join learner on learnsorce.LearnerID=learner.LearnerID left join languages on learnsorce.LanguageID=languages.LanguageID order by LearnSorceID DESC ";
                List<JiaJiModels.LearnerModel> list = MySqlDB.GetList<JiaJiModels.LearnerModel>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加高分学员列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addMaxScoStu(JiaJiModels.LearnerModel model)
        {
            try
            {
                string sql = "insert into learnsorce(LearnerID,LanguageID,Sorce,LearnerGonsis,LearnerContent,HeatHot) VALUES(" + model.LearnerID+","+model.LanguageID+",'"+model.Sorce+"','"+model.LearnerGonsis+"','"+model.LearnerContent + "',0)";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除高分学员列表
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelMaxScoStu(string did)
        {
            try
            {
                string sql = "delete from learnsorce where LearnSorceID in (" + did + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改高分学员列表
        /// </summary>
        /// <returns></returns>
        public int UpdateMaxScoStu(JiaJiModels.LearnerModel model)
        {
            try
            {
                string sql = "Update study_abroad.learnsorce set LearnerID = " + model.LearnerID + ", LanguageID = " + model.LanguageID + ", Sorce = '" + model.Sorce + "', `LearnerGonsis`= '" + model.LearnerGonsis + "',LearnerContent='"+model.LearnerContent+"' where LearnSorceID =" + model.LearnSorceID+ " ";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
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
