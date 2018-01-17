using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 攻略表
    /// </summary>
   public  class Strategy
    {
        /// <summary>
        /// 攻略编号
        /// </summary>
        public int StrategyID { get; set; }
        /// <summary>
        /// 攻略标题
        /// </summary>
        public string StrategyTitle { get; set; }
        /// <summary>
        /// 攻略内容
        /// </summary>
        public string StrategyContent { get; set; }
        /// <summary>
        /// 攻略日期
        /// </summary>
        public string   StrategyDate { get; set; }
        /// <summary>
        /// 攻略所属国家编号
        /// </summary>
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        ///<summary>
        ///攻略图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 攻略简介
        /// </summary>
        public string StrategyProfile { get; set; }
        /// <summary>
        /// 攻略关键字
        /// </summary>
        public string StrategyKeyWord { get; set; }
        /// <summary>
        /// 阅读量
        /// </summary>
        public int StrategyReadCount { get; set; }
        /// <summary>
        /// 攻略作者
        /// </summary>
        public string StrategyAuthor { get; set; }

    }



}
