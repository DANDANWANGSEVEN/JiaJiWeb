using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 学员分享表
    /// </summary>
   public  class Share
    {
        /// <summary>
        /// 分享编号
        /// </summary>
        public int ShareID { get; set; }
        /// <summary>
        /// 分享标题
        /// </summary>
        public string ShareTitle { get; set; }

        /// <summary>
        /// 分享图片
        /// </summary>
        public string ShareImg { get; set; }

        /// <summary>
        /// 分享内容
        /// </summary>
        public string  ShareContent { get; set; }
        /// <summary>
        /// 学员编号
        /// </summary>
        public int LearnerID { get; set; }
        public string LearnName { get; set; }
        /// <summary>
        /// 分享日期
        /// </summary>
        public string  ShareDate { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public  int Pro_ID { get; set; }
        public string Pro_Name { get; set; }
        public string Pro_Img { get; set; }

        /// <summary>
        /// 项目活动图片
        /// </summary>
        public string ProactiveImg1 { get; set; }
        /// <summary>
        /// 项目活动图片
        /// </summary>
        public string ProactiveImg2 { get; set; }
        /// <summary>
        /// 分享关键字
        /// </summary>
        public string ShareKeyword { get; set; }
        /// <summary>
        /// 分享简介
        /// </summary>
        public string ShareProfile { get; set; }
        /// <summary>
        /// 阅读量
        /// </summary>
        public int ShareReadCount { get; set; }


    }
    /// <summary>
    /// 项目表 projectItem
    /// </summary>
    public class projectItem
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int Pro_ID { get; set; }
       /// <summary>
       /// 项目名称
       /// </summary>
        public string Pro_Name { get; set; }
        /// <summary>
        /// 项目内容
        /// </summary>
        public string Pro_Content { get; set; }

        /// <summary>
        /// 项目图片
        /// </summary>
        public string Pro_Img { get; set; }

        /// <summary>
        /// 项目活动图片
        /// </summary>
        public string ProactiveImg1 { get; set; }
        /// <summary>
        /// 项目活动图片
        /// </summary>
        public string ProactiveImg2 { get; set; }
        /// <summary>
        /// 项目简介
        /// </summary>
        public string Pro_Profile { get; set; }
        /// <summary>
        /// 项目关键字
        /// </summary>
        public string Pro_KeyWord { get; set; }
        /// <summary>
        /// 发表作者
        /// </summary>
        public string Pro_Author { get; set; }
        /// <summary>
        /// 阅读量
        /// </summary>
        public int Pro_ReadCount { get; set; }
        /// <summary>
        /// 发表日期
        /// </summary>
        public string Pro_Date { get; set; }
        /// <summary>
        /// 背景提升来源
        /// </summary>
        public string Pro_Source { get; set; }


    }




}
