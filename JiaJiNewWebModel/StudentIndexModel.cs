using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
   public class StudentIndexModel
    {
        /// <summary>
        /// 学生编号
        /// </summary>
        public int StudentID { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 学生分数
        /// </summary>
        public string  Score { get; set; }
        /// <summary>
        /// 学生图片
        /// </summary>
        public string Image { get; set; }

        public string CollegeImg { get; set; }

        /// <summary>
        /// 就读院校
        /// </summary>
        public string JiuDuXueyuan { get; set; }
        /// <summary>
        /// 录取院校
        /// </summary>
        public string LuQuXueYuan { get; set; }
        /// <summary>
        /// 成功案例ID
        /// </summary>
        public int SuccessID { get; set; }

        /// <summary>
        /// 学历编号
        /// </summary>
        public int EducationID { get; set; }
        public string EducationName { get; set; }

        public int CollegeID { get; set; }
        public string CollegeName { get; set; }

        public int SRelationID { get; set; }


    }
}
