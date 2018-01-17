using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 留学资讯表
    /// </summary>
    public class StudyAbroadInfo
    {
        /// <summary>
        /// 资讯编号
        /// </summary>
        public int InformationID { get; set; }
        /// <summary>
        /// 咨询标题
        /// </summary>
        public string  Title { get; set; }
        /// <summary>
        /// 资讯内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime InfoDate { get; set; }
        /// <summary>
        /// 资讯来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string  Author { get; set; }
        /// <summary>
        /// 阅读量
        /// </summary>
        public int ReadCount { get; set; }
        /// <summary>
        /// 主页是否显示（1显示 0不显示）
        /// </summary>
        public int LookYes { get; set; }





    }


}
