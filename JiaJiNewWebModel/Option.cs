using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    public class Option
    {
        /// <summary>
        /// 观点ID
        /// </summary>
        public int OptionID { get; set; }
        ///<summary>
        ///观点标题
        /// </summary>
        public string OptionTitle { get; set; }
        ///<summary>
        ///观点内容
        /// </summary>
        public string OptionContent { get; set; }
        ///<summary>
        ///作者
        /// </summary>
        public string Author { get; set; }
        ///<summary>
        ///来源
        /// </summary>
        public string Source { get; set; }
        ///<summary>
        ///日期
        /// </summary>
        public string Date { get; set; }
        ///<summary>
        ///观点热度
        /// </summary>
        public int OptionHot { get; set; }
        /// <summary>
        /// 观点关键词
        /// </summary>
        public string OptionKeyWord { get; set; }
        /// <summary>
        /// 观点图片
        /// </summary>
        public string OptionUrl { get; set; }

    }
}
