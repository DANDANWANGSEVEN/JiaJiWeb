using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;

namespace JiaJiNewWebIDAL
{
    public interface ILunBoImageDAL
    {
        /// <summary>
        /// 国家页面轮播图  根据上传时间倒叙
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        List<LunBoImageModel> LunBoList(int countryid, int educatonid);


        /// <summary>
        /// 不轮播图显示前两条
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        List<LunBoImageModel> NoLunBoList(int countryid, int educatonid);

        /// <summary>
        /// 首页留学图片
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        //List<LunBoImageModel> IndexLXueList();


        /// <summary>
        /// 首页资讯图片
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        List<Information> IndexInforImage();

        /// <summary>
        /// 北京西安资讯图片
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        List<Information> BeiXiInforImage(int site);


        /// <summary>
        /// 国家页面资讯图片
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        List<Information> CountryZiXunImage(int countryid);


        /// <summary>
        /// 二维码
        /// </summary>
        /// <returns></returns>
        List<erweima> ErWeiMaList();

    }
}
