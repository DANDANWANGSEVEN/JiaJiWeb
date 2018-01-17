using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    /// <summary>
    /// 二维码
    /// </summary>
   public  class ErWeiMaModel
    {
        /// <summary>
        /// 二维码编号
        /// </summary>
        public int EWMID { get; set; }
        /// <summary>
        /// 二维码标题
        /// </summary>
        public string EWMTitle { get; set; }
        /// <summary>
        /// 二维码路径
        /// </summary>
        public string EWMUrl { get; set; }
        /// <summary>
        /// 二维码上传日期
        /// </summary>
        public string EWMUpdate { get; set; }

    }


    /// <summary>
    /// 首页轮播图
    /// </summary>
    public class IndexLunBo
    {
        public int ImageID { get; set; }
        public string  ImageUrl { get; set; }
        public string  ImageUpDate { get; set; }
        public string ImageProduce { get; set; }
    }



    /// <summary>
    /// 国家轮播图
    /// </summary>
    public class LunBoImage
    {
        public int LunImageID { get; set; }

        public string ImageUrl { get; set; }

        public int IsLunBo { get; set; }


        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public string UpDate { get; set; }

        public int EducationID { get; set; }

        public string EducationName { get; set; }

    }





}
