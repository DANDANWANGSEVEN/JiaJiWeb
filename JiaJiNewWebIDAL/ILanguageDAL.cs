using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;

namespace JiaJiNewWebIDAL
{
    public interface ILanguageDAL
    {
        ///<summary>
        ///语言内容
        /// </summary>
        /// <returns></returns>
        Language LanguageShow(int Id);


        /// <summary>
        /// 语言课程
        /// </summary>
        /// <param name="Id">语言类别ID</param>
        /// <returns></returns>
        List<Course> CourseShow(int Id);

        /// <summary>
        /// 课程详情
        /// </summary>
        /// <param name="LearnSorceID"></param>
        /// <returns></returns>
        JiaJiNewWebModel.Course CourseDetail(int courseid);

        ///<summary>
        ///上一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        JiaJiNewWebModel.Course CoursePrev(int Id);

        ///<summary>
        ///下一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        JiaJiNewWebModel.Course CourseNext(int Id);

        ///<summary>
        ///语言学员列表
        /// <para>ID:语言ID</para>
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.LernerScore> LearnShow(int Id);

        /// <summary>
        /// 分页显示高分学员
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        List<JiaJiNewWebModel.LernerScore> PageLearnShow(int Id, int pageindex);

        /// <summary>
        /// js获取高分学员的数量
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        int GetRowCounts(int languageid);

        /// <summary>
        /// 高分学员详细页面
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        JiaJiNewWebModel.LernerScore MaxStuContent(int LearnSorceID);

        ///<summary>
        ///上一个高分学员
        ///<para>Id:高分学员Id</para>
        /// </summary>
        JiaJiNewWebModel.LernerScore MaxStuContentPrev(int Id);

        ///<summary>
        ///下一个高分学员
        ///<para>Id:高分学员Id</para>
        /// </summary>
        JiaJiNewWebModel.LernerScore MaxStuContentNext(int Id);

        ///<summary>
        ///语言显示
        /// </summary>
        List<Language> Language();
        /// <summary>
        /// 获取语言培训的内容信息
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Language_PeiXunModel> GetPeixunList();
    }
}
