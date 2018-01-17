using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 图片表
    /// </summary>
   public  class IndexImage
    {

        public string ImageUpDate { get; set; }

        public string ImageProduce { get; set; }

        /// <summary>
        /// 图片编号
        /// </summary>
        public int ImageID { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string  ImageUrl { get; set; }

    }

    /// <summary>
    /// 页面表
    /// </summary>
    public class Page
    {
        /// <summary>
        /// 页面表编号
        /// </summary>
        public int PageID { get; set; }
        /// <summary>
        /// 页面名称
        /// </summary>
        public string PageName { get; set; }
        /// <summary>
        /// 图片所在位置
        /// </summary>
        public string ImageAddress { get; set; }
    }

    /// <summary>
    /// 页面图片关系表
    /// </summary>
    public class ImagePageRela
    {
        /// <summary>
        /// 页面图片关系主键
        /// </summary>
        public int ImagePageRelaID { get; set; }
        /// <summary>
        /// 页面编号
        /// </summary>
        public int PageID { get; set; }
        /// <summary>
        /// 图片编号
        /// </summary>
        public int ImageID { get; set; }
    }

}
