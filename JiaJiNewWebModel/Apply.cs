using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 留学申请表
    /// </summary>
   public class Apply
    {
        /// <summary>
        /// 申请编号
        /// </summary>
        public int ApplyID { get; set; }
        /// <summary>
        /// 申请国家编号
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// 申请人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 申请人电话
        /// </summary>
        public string  Phone { get; set; }
        /// <summary>
        /// 计划留学时间
        /// </summary>
        public DateTime  GoTime { get; set; }

    }

    /// <summary>
    /// 国家表
    /// </summary>
    public class Country
    {
        /// <summary>
        /// 国家编号
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// 国家名称
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// 国家优势
        /// </summary>
        public string CountryYouShi { get; set; }
        /// <summary>
        /// 国家图片
        /// </summary>
        public string CountryImg { get; set; }

        /// <summary>
        /// 国家页面图片
        /// </summary>
        public string CountryImg2 { get; set; }

        /// <summary>
        /// 是否是国家
        /// </summary>
        public int IsCountry { get; set; }

        /// <summary>
        /// 国家活动图1
        /// </summary>
        public string CountryActiveImg1 { get; set; }

        /// <summary>
        /// 国家活动图2
        /// </summary>
        public string CountryActiveImg2 { get; set; }


    }
    /// <summary>
    /// 海外留学
    /// </summary>
    public class HaiWaiLiuXue
    {
        /// <summary>
        /// 海外留学编号
        /// </summary>
        public int HaiWaiLiuXueID { get; set; }
        /// <summary>
        /// 海外留学标题
        /// </summary>
        public string HaiWaiLiuXueTitle { get; set; }
    }
    /// <summary>
    /// 海外国家关系表
    /// </summary>
    public class HaiWai_Country
    {
        /// <summary>
        /// 海外国家关系编号
        /// </summary>
        public int HaiWaiCountryID { get; set; }
        /// <summary>
        /// 国家编号
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// 国家名称
        /// </summary>
        public String CountryName { get; set; }
        /// <summary>
        /// 国家优势
        /// </summary>
        public string CountryYouShi { get; set; }
        /// <summary>
        /// 国家图片
        /// </summary>
        public string CountryImg { get; set; }
        /// <summary>
        /// 海外留学编号
        /// </summary>
        public int HaiWaiLiuXueID { get; set; }
        /// <summary>
        /// 海外留学标题
        /// </summary>
        public string HaiWaiLiuXueTitle { get; set; }
        /// <summary>
        /// 百分比
        /// </summary>
        public int BaiFengBi { get; set; }

        public string CountryActiveImg1 { get; set; }

        public string CountryActiveImg2 { get; set; }
    }

    /// <summary>
    /// 申请国家学历关系表
    /// </summary>
    public class AppCounRela
    {
        /// <summary>
        /// 关系编号
        /// </summary>
        public int AppCounRelaID { get; set; }
        /// <summary>
        /// 申请编号
        /// </summary>
        public int ApplyID { get; set; }
        public string ApplyTitle { get; set; }
        public string ApplyContent { get; set; }

        /// <summary>
        /// 国家编号
        /// </summary>
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        /// <summary>
        /// 学历编号
        /// </summary>
        public int EducationID { get; set; }
        public string EducationName { get; set; }

    }



}
