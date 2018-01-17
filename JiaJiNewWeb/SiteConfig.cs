using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace JiaJiNewWeb
{
    public class SiteConfig
    {
        /// <summary>
        /// 前台地址
        /// </summary>
        public static readonly string SiteUrl = "";
        /// <summary>
        /// 图片上传路径
        /// </summary>
        public static readonly string ImgUploadPath = ConfigurationManager.AppSettings["ImgUploadPath"].ToString().EndsWith("\\") ? ConfigurationManager.AppSettings["ImgUploadPath"].ToString() : ConfigurationManager.AppSettings["ImgUploadPath"].ToString() + "\\";
        /// <summary>
        /// 图片上传文件夹
        /// </summary>
        public static readonly string ImgUploadDirectory = ConfigurationManager.AppSettings["ImgUploadDirectory"].ToString().EndsWith("\\") ? ConfigurationManager.AppSettings["ImgUploadDirectory"].ToString() : ConfigurationManager.AppSettings["ImgUploadDirectory"].ToString() + "\\";



    }
}