using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebIDAL;
using JiaJiNewWeb.DALFactory;
using JiaJiNewWebModel;

namespace JiaJiNewWebBLL
{
    public class LanguageBLL
    {
        ILanguageDAL dal = Factory<ILanguageDAL>.Create("LanguageDAL");
        /// <summary>
        /// 语言内容
        /// </summary>
        /// <returns></returns>
        public Language LanguageShow(int Id)
        {
            return dal.LanguageShow(Id);
        }
        /// <summary>
        /// 语言课程
        /// </summary>
        /// <param name="Id">语言类别ID</param>
        /// <returns></returns>
        public List<Course> CourseShow(int Id)
        {
            return dal.CourseShow(Id);
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
                return dal.CourseDetail(courseid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///上一个课程
        ///<para>Id:课程Id</para>
        /// </summary>
        public JiaJiNewWebModel.Course CoursePrev(int Id)
        {
            try
            {
                return dal.CoursePrev(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///<summary>
        ///下一个课程
        ///<para>Id:课程Id</para>
        /// </summary>
        public JiaJiNewWebModel.Course CourseNext(int Id)
        {
            try
            {
                return dal.CourseNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///<summary>
        ///语言学员列表
        /// <para>ID:语言ID</para>
        /// </summary>
        public List<JiaJiNewWebModel.LernerScore> LearnShow(int Id)
        {
            return dal.LearnShow(Id);
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
                return dal.PageLearnShow(Id, pageindex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// js获取高分学员的数量
        /// </summary>
        /// <param name="languageid"></param>
        /// <returns></returns>
        public int GetRowCounts(int languageid)
        {
            try
            {
                return dal.GetRowCounts(languageid);
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
                return dal.MaxStuContent(LearnSorceID);
            }
            catch (Exception ex)
            {
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
                return dal.MaxStuContentPrev(Id);
            }
            catch (Exception ex)
            {
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
                return dal.MaxStuContentNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        ///<summary>
        ///语言显示
        /// </summary>
        public List<Language> Language()
        {
            return dal.Language();
        }

        /// <summary>
        /// 获取语言培训的内容信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Language_PeiXunModel> GetPeixunList()
        {
            return dal.GetPeixunList();
        }
    }
}
