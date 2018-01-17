using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    /// <summary>
    /// 课程
    /// </summary>
   public class CourseModel
    {
        /// <summary>
        /// 课程主键ID
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 课程介绍
        /// </summary>
        public string CourseContent { get; set; }
        /// <summary>
        /// 课程详情
        /// </summary>
        public string CourseDetail { get; set; }
        public int CourseReadCount { get; set; }

        /// <summary>
        /// 获取语言ID
        /// </summary>
        public string CourseDate { get; set; }

        public string CourseKeyWord { get; set; }
        public int LanguageID { get; set; }


    }
    /// <summary>
    /// 语言
    /// </summary>
    public class Languages
    {
        public int LanguageID { get; set; }

        public string LanguageName { get; set; }

        public string LanguageTitle { get; set; }

        public string LanguageContent { get; set; }


    }
    /// <summary>
    /// 语言课程关系表
    /// </summary>
    public class languagerelation
    {
        public int LRelationID { get; set; }

        public int LanguageID { get; set; }

        public string LanguageName { get; set; }

        public string LanguageTitle { get; set; }

        public string LanguageContent { get; set; }

        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public string CourseContent { get; set; }

        public string CourseDetail { get; set; }

        public int CourseReadCount { get; set; }
        public string CourseDate { get; set; }

        public string CourseKeyWord { get; set; }

    }

    /// <summary>
    /// 语言培训
    /// </summary>
    public class Language_PeiXun
    {
        public int LanguagePx_ID { get; set; }

        public string Language_Name { get; set; }

        public string Language_Content { get; set; }
    }

}
