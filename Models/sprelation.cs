using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    /// <summary>
    /// 留学规划
    /// </summary>
    public class StudentProgram
    {
        /// <summary>
        /// 规划Id
        /// </summary>
        public int StudentProgramID { get; set; }
        /// <summary>
        /// 规划标题
        /// </summary>
        public string StudentProgramTitle { get; set; }
        /// <summary>
        /// 规划内容
        /// </summary>
        public string StudentProgramContent { get; set; }
        ///<summary>
        ///规划来源
        /// </summary>
        public string Source { get; set; }
        ///<summary>
        ///作者
        /// </summary>
        public string Author { get; set; }
        ///<summary>
        ///阅读数
        /// </summary>
        public int ReadCount { get; set; }
        ///<summary>
        ///规划图片
        /// </summary>
        public string ImageUrl { get; set; }
        ///<summary>
        ///规划国家
        /// </summary>
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        ///<summary>
        ///学历要求
        /// </summary>
        public string EducationName { get; set; }
        public int EducationID { get; set; }

        public int TypeID { get; set; }
        public string TypeName { get; set; }

        public string StudentKeyWord { get; set; }
        public string StudentProfile { get; set; }

    }
}
