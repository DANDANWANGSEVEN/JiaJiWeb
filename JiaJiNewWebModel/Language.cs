using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 语言表
    /// </summary>
    public class Language
    {
        /// <summary>
        /// 语言编号
        /// </summary>
        public int LanguageID { get; set; }

        /// <summary>
        /// 语言名称
        /// </summary>
        public string LanguageName { get; set; }
        ///<summary>
        ///语言标题
        /// </summary>
        public string LanguageTitle { get; set; }

        /// <summary>
        /// 语言内容
        /// </summary>
        public string LanguageContent { get; set; }
    }


    /// <summary>
    /// 课程表
    /// </summary>
    public class Course
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 课程内容
        /// </summary>
        public string CourseContent { get; set; }
        /// <summary>
        /// 课程详情
        /// </summary>
        public string CourseDetail { get; set; }

        public int CourseReadCount { get; set; }

        public string CourseDate { get; set; }

        public string CourseKeyWord { get; set; }

    }

    /// <summary>
    /// 语言课程关系表
    /// </summary>
    public class LanguageCourseRela
    {
        /// <summary>
        /// 语言课程关系主键
        /// </summary>
        public int LanguageCourseRelaID { get; set; }
        /// <summary>
        /// 语言主键
        /// </summary>
        public int LanguageID { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        public int CourseID { get; set; }

        /// <summary>
        /// 课程详情
        /// </summary>
        public string CourseDetail { get; set; }

        public int CourseReadCount { get; set; }
    }



}
