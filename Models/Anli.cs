using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
   public class Anli
    {

        public int SRelationID { get; set; }

        /// <summary>
        /// 案例ID
        /// </summary>
        public int SuccessID { get; set; }
        /// <summary>
        /// 案例标题
        /// </summary>
        public string SuccessTitle { get; set; }
        /// <summary>
        /// 案例内容
        /// </summary>
        public string SuccessContent { get; set; }
        /// <summary>
        /// 成功时间
        /// </summary>
        public string SuccessDate { get; set; }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// 国家名
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// 就读学院
        /// </summary>
        public string JiuDuXueyuan { get; set; }

        /// <summary>
        /// 学生主键ID
        /// </summary>
        public int StudentID { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 学院主键ID
        /// </summary>
        public int CollegeID { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        public string CollegeName { get; set; }
        /// <summary>
        /// 学历主键ID
        /// </summary>
        public int EducationID { get; set; }
        /// <summary>
        /// 学历主键名称
        /// </summary>
        public string EducationName { get; set; }

        public int TeamID { get; set; }

        public string TeamName { get; set; }

    }
}
