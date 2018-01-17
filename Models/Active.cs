using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    /// <summary>
    /// 最新活动表
    /// </summary>
    public  class Active
    {
        /// <summary>
        /// 活动主键编号
        /// </summary>
        public int ActiveID { get; set; }
        /// <summary>
        /// 活动标题
        /// </summary>
        public string ActiveTitle { get; set; }
        
        /// <summary>
        /// 活动日期
        /// </summary>
        public string ActiveDate { get; set; }
        /// <summary>
        /// 活动地点
        /// </summary>
        public int Site { get; set; }
        public int AreaID { get; set; }
        public String AreaName { get; set; }
        /// <summary>
        /// 活动详情
        /// </summary>
        public string  Datails { get; set; }
        /// <summary>
        /// 活动报名电话
        /// </summary>
        public string ActivePhone { get; set; }
        /// <summary>
        /// 活动热度
        /// </summary>
        public int HeatID { get; set; }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        /// <summary>
        /// 活动关键字
        /// </summary>
        public string ActiveKeyWord { get; set; }
        /// <summary>
        /// 活动简介
        /// </summary>
        public string ActiveProfile { get; set; }

    }




}
