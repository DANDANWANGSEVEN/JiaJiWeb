using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
   public class student
    {
        /// <summary>
        /// 学生主键ID
        /// </summary>
        public int StudentID { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 学生成绩
        /// </summary>
        public string Score { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 就读学院
        /// </summary>
        public string JiuDuXueyuan { get; set; }
        /// <summary>
        /// 案例ID
        /// </summary>
        public int SuccessID { get; set; }
        /// <summary>
        /// 案例内容
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
        /// 学历ID
        /// </summary>
        public int EducationID { get; set; }
        /// <summary>
        /// 学历名称
        /// </summary>
        public string EducationName { get; set; }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        /// <summary>
        /// 团队ID
        /// </summary>
        public int teamid { get; set; }

        public int CollegeID { get; set; }
    }


    public class studentprogramtype
    {
        public int TypeID { get; set; }

        public string TypeName { get; set; }
    }


}
