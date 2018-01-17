using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
   public class TeamIndexModel
    {
        /// <summary>
        /// 团队ID
        /// </summary>
        public int TeamID { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string  Position { get; set; }
        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkDate { get; set; }
       /// <summary>
       /// 擅长地区
       /// </summary>
        public string ShenQing { get; set; }
        /// <summary>
        /// 顾问介绍
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 首页显示1
        /// </summary>
        public string  Image1 { get; set; }
        /// <summary>
        /// 内页显示2
        /// </summary>
        public string Image2 { get; set; }

        /// <summary>
        /// 顾问介绍
        /// </summary>
        public string  TeamProduce { get; set; }


    }
}
