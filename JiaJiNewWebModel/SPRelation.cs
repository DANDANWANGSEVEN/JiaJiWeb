using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
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
        public string Imageurl { get; set; }
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
        /// <summary>
        /// 关键字
        /// </summary>
        public string StudentKeyWord { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string StudentProfile { get; set; }

    }

    public class StudentProgramType
    {
        /// <summary>
        /// 规划ID
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 规划类别
        /// </summary>
        public string TypeName { get; set; }
    }
    /// <summary>
    /// 申请条件
    /// </summary>
    public class ApplyCondition
    {
        /// <summary>
        /// 申请条件ID
        /// </summary>
        public int ApplyID { get; set; }
        ///<summary>
        ///申请条件
        /// </summary>
        public string ApplyTitle { get; set; }
        ///<summary>
        ///申请条件内容
        /// </summary>
        public string ApplyContent { get; set; }
    }
    /// <summary>
    /// 申请条件内容表
    /// </summary>
    public class ApplyContentInfo
    {
        public int ApplyContentID { get; set; }

        public string ApplyContent { get; set; }

        public int CountryID { get; set; }

        public int EducationID { get; set; }

        public int ApplyConditionID { get; set; }
        /// <summary>
        /// 申请条件ID
        /// </summary>
        public int ApplyID { get; set; }
        ///<summary>
        ///申请条件
        /// </summary>
        public string ApplyTitle { get; set; }
    }

    /// <summary>
    /// 时间规划
    /// </summary>
    public class ArrangeTime
    {
        /// <summary>
        /// 规划时间ID
        /// </summary>
        public int ArrangeID { get; set; }
        ///<summary>
        ///规划月份
        /// </summary>
        public string ArrangeMonth { get; set; }
        ///<summary>
        ///规划内容
        /// </summary>
        public string ArrangeContent { get; set; }
        ///<summary>
        ///国家ID
        /// </summary>
        public int CountryID { get; set; }
        public string CountryName { get; set; }
       
        public int EducationID { get; set; }
        public string EducationName { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int ShowID { get; set; }
    }
}
