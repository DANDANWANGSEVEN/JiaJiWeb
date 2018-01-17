using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    /// <summary>
    /// 2.	留学资讯表
    /// </summary>
    public class Information
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        public int 	InformationID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string  Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string  Content { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public string InfoDate { get; set; }
        /// <summary>
        /// 来源 
        /// </summary>
        public string  Source { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string  Author { get; set; }
        /// <summary>
        /// 阅读量
        /// </summary>
        public int ReadCount { get; set; }
        /// <summary>
        /// 首页是否显示
        /// </summary>
        public int LookYes { get; set; }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID { get; set; }

        /// <summary>
        /// 国家名
        /// </summary>
        public string CountryName
        {
            get; set;
        }

        /// <summary>
        /// 地区
        /// </summary>
        public int Site { get; set; }
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        /// <summary>
        /// 资讯图片
        /// </summary>
        public string InformationImgUrl { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string InfoKeyWord { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string InformationProfile { get; set; }


    }
}
