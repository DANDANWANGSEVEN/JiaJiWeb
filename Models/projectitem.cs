using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
   public class projectitem
    {
        /// <summary>
        /// 背景主键ID
        /// </summary>
        public int Pro_ID { get; set; }
        /// <summary>
        /// 背景名称
        /// </summary>
        public string Pro_Name { get; set; }
        /// <summary>
        /// 背景内容
        /// </summary>
        public string Pro_Content { get; set; }
        /// <summary>
        /// 背景图片
        /// </summary>
        public string  Pro_Img { get; set; }

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
