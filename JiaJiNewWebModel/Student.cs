using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 以被成功录取的学生表
    /// </summary>
   public  class Student
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
        public decimal Score { get; set; }
        /// <summary>
        /// 学生图片
        /// </summary>
        public int ImageID { get; set; }
        /// <summary>
        /// 就读学院
        /// </summary>
        public string JiuDuXueYuan { get; set; }
        /// <summary>
        /// 录取学院
        /// </summary>
        public string LuQuXueYuan { get; set; }
    }






}
