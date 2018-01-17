using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 学员表
    /// </summary>
    public class Learner
    {
        /// <summary>
        /// 学员编号
        /// </summary>
        public int LernerID { get; set; }
        /// <summary>
        /// 国家编号
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// 学员姓名
        /// </summary>
        public string LearnerName { get; set; }
        /// <summary>
        /// 学员联系方式
        /// </summary>
        public string LearnerPhone { get; set; }
        /// <summary>
        /// 学员计划留学时间
        /// </summary>
        public DateTime LearnerGoTime { get; set; }

    }

    /// <summary>
    /// 学员分数关系表
    /// </summary>
    public class LernerScore
    {
        /// <summary>
        /// 学员分数关系主键
        /// </summary>
        public int LearnSorceID { get; set; }
        /// <summary>
        /// 学员编号
        /// </summary>
        public int LearnerID { get; set; }
        public string LearnName { get; set; }
        /// <summary>
        /// 学员所学语言编号
        /// </summary>
        public int LanguageID { get; set; }

        public string LanguageName { get; set; }
        /// <summary>
        /// 学员分数
        /// </summary>
        public string Sorce { get; set; }
        /// <summary>
        /// 学员分享标题
        /// </summary>
        public string LearnerGonsis { get; set; }
        /// <summary>
        /// 学员分享的内容
        /// </summary>
        public string LearnerContent { get; set; }
        /// <summary>
        /// 学员分享点击量
        /// </summary>
        public int HeatHot { get; set; }
        /// <summary>
        /// 学员图片
        /// </summary>
        public string LearnImage { get; set; }
    }


}
