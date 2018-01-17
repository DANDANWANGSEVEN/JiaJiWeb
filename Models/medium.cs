using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
   public class medium
    {
        /// <summary>
        /// 媒体主键ID
        /// </summary>
        public int MediumID { get; set; }
        /// <summary>
        /// 媒体名称
        /// </summary>
        public string MediumName { get; set; }
        /// <summary>
        /// 媒体标题
        /// </summary>
        public string MediumTitle { get; set; }
        /// <summary>
        /// 媒体图片
        /// </summary>
        public string MediumImg { get; set; }

        /// <summary>
        /// 媒体链接
        /// </summary>
        public string MediumUrl { get; set; }

        /// <summary>
        /// 上传日期
        /// </summary>
        public string  UpDate { get; set; }
    }
}
