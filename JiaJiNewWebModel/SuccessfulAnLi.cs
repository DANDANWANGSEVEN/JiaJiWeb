using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 成功案例表
    /// </summary>
   public  class SuccessfulAnLi
    {
        /// <summary>
        /// 成功案例主键
        /// </summary>
        public int SuccessID { get; set; }
        /// <summary>
        /// 成功案例标题
        /// </summary>
        public string SuccessTitle { get; set; }
        /// <summary>
        /// 成功案例内容
        /// </summary>
        public string SuccessContent { get; set; }
        /// <summary>
        /// 成功案例日期
        /// </summary>
        public string  SuccessDate { get; set; }

    }

    /// <summary>
    /// 成功案例信息关系表
    /// </summary>
    public class SuccessfulInfo_Relation
    {
        /// <summary>
        /// 成功案例信息关系主键
        /// </summary>
        public int SRelationID { get; set; }
        /// <summary>
        /// 成功案例国家编号
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// 成功案例学生编号
        /// </summary>
        public int StudentID { get; set; }
        /// <summary>
        /// 成功案例录取学院编号
        /// </summary>
        public int CollegeID { get; set; }


        /// <summary>
        /// 成功案例主键
        /// </summary>
        public int SuccessID { get; set; }
        /// <summary>
        /// 成功案例标题
        /// </summary>
        public string SuccessTitle { get; set; }
        /// <summary>
        /// 成功案例内容
        /// </summary>
        public string SuccessContent { get; set; }
        /// <summary>
        /// 成功案例日期
        /// </summary>
        public string SuccessDate { get; set; }

        public string CollegeImg { get; set; }

        /// <summary>
        /// 学院名称
        /// </summary>
        public string CollegeName { get; set; }
        /// <summary>
        /// 学历类别编号
        /// </summary>
        public int EducationID { get; set; }
        /// <summary>
        /// 学历名称
        /// </summary>
        public string EducationName { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 学生分数
        /// </summary>
        public string Score { get; set; }
        /// <summary>
        /// 学生图片编号
        /// </summary>
        public int ImageID { get; set; }
    }


    /// <summary>
    /// 学院表
    /// </summary>
    public class College
    {
        /// <summary>
        /// 学院编号
        /// </summary>
        public int CollegeID { get; set; }
        /// <summary>
        /// 学院名称
        /// </summary>
        public string CollegeName { get; set; }

        public string CollegeImg { get; set; }

    }

    /// <summary>
    /// 学历类别表
    /// </summary>
    public class EducationType
    {

        /// <summary>
        /// 学历类别编号
        /// </summary>
        public int EducationID { get; set; }
        /// <summary>
        /// 学历名称
        /// </summary>
        public string EducationName { get; set; }


    }




}
