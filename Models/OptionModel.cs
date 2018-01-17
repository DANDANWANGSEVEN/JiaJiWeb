using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
   public class OptionModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string OptionTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string OptionContent { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 热度
        /// </summary>
        public int OptionHot { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public int OptionID { get; set; }
        /// <summary>
        /// 观点关键词
        /// </summary>
        public string OptionKeyWord { get; set; }

        public string OptionUrl { get; set; }


    }
}
