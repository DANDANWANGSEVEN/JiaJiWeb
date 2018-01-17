using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    public class LearnerModel
    {
        /// <summary>
        /// 语言主键ID
        /// </summary>
        public int LanguageID { get; set; }
        /// <summary>
        /// 语言名称
        /// </summary>
        public string LanguageName { get; set; }
        /// <summary>
        /// 语言标题
        /// </summary>
        public string LanguageTitle { get; set; }
        /// <summary>
        /// 语言介绍
        /// </summary>
        public string LanguageContent { get; set; }
        /// <summary>
        /// 学员ID
        /// </summary>
        public int LearnerID { get; set; }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// 学员名字
        /// </summary>
        public string LearnName { get; set; }
        /// <summary>
        /// 学员手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public string Date { get; set; }

        public string GoTime { get; set; }
        ///<summary>
        ///学员成绩
        /// </summary>
        public string Sorce { get; set; }
            
        /// <summary>
        /// 分享ID
        /// </summary>
        public int ShareID { get; set; }
        /// <summary>
        /// 分享标题
        /// </summary>
        public string ShareTitle { get; set; }
        /// <summary>
        /// 分享内容
        /// </summary>
        public string ShareContent { get; set; }       
        /// <summary>
        /// 分享日期
        /// </summary>
        public string ShareDate { get; set; }
        /// <summary>
        /// 分享项目ID
        /// </summary>
        public int Pro_ID { get; set; }
        ///<summary>
        ///语言学习感悟
        /// </summary>
        public string LearnerGonsis { get; set; }

        public string LearnerContent { get; set; }

        public int HeatHot { get; set; }

        public string LearnImage { get; set; }


        /// <summary>
        /// 学员成绩关系主键
        /// </summary>
        public int LearnSorceID { get; set; }



    }
    
}
