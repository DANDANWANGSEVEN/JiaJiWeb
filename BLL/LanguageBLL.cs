using JiaJiDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiBLL
{
    public class LanguageBLL
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
                return new JiaJiDAL.LanguageDAL().ShowShare();
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
                return new JiaJiDAL.LanguageDAL().AddShare(model);

            }
            catch (Exception ex)
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
                return new JiaJiDAL.LanguageDAL().DeleteShare(shareids);

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
                return new JiaJiDAL.LanguageDAL().UpdateShare(model);

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
                return new JiaJiDAL.LanguageDAL().ShowLangCour();
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
                return new JiaJiDAL.LanguageDAL().ShowCourse();

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

                return new JiaJiDAL.LanguageDAL().addCourse(model);
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
                return new JiaJiDAL.LanguageDAL().DelCourse(did);
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
                return new JiaJiDAL.LanguageDAL().UpdateCourse(model);
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
        //    return dal.CourseAdd(model);
        //}

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
                return new JiaJiDAL.LanguageDAL().ShowLanguage();
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
                return new JiaJiDAL.LanguageDAL().addLanguage(model);
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
                return new JiaJiDAL.LanguageDAL().DelLanguage(did);
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
                return new JiaJiDAL.LanguageDAL().UpdateLanguage(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


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
                return new JiaJiDAL.LanguageDAL().ShowLanguagePeiXun();
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
                return new JiaJiDAL.LanguageDAL().addLanguagePeiXun(model);
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
                return new JiaJiDAL.LanguageDAL().DelLanguagePeiXun(did);
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
                return new JiaJiDAL.LanguageDAL().UpdateLanguagePeiXun(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion



        LanguageDAL dal = new LanguageDAL();
        /// <summary>
        /// 语言添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int LanguageAdd(JiaJiModels.LearnerModel model)
        {
            return dal.LanguageAdd(model);
        }

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.projectitem> Project()
        {
            return dal.Project();
        }
        
    }
}
