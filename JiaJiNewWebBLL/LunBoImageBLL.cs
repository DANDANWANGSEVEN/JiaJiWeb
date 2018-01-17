using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWeb.DALFactory;
using JiaJiNewWebModel;

namespace JiaJiNewWebBLL
{
    public  class LunBoImageBLL
    {

        JiaJiNewWebIDAL.ILunBoImageDAL lunbodal = Factory<JiaJiNewWebIDAL.ILunBoImageDAL>.Create("LunBoImaeDAL");


        /// <summary>
        /// 国家页面轮播图  根据上传时间倒叙
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        public List<LunBoImageModel> LunBoList(int countryid, int educatonid)
        {
            try
            {
                return lunbodal.LunBoList(countryid, educatonid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// 不轮播图显示前两条
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        public List<LunBoImageModel> NoLunBoList(int countryid,int educatonid)
        {
            try
            {
                return lunbodal.NoLunBoList(countryid, educatonid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 首页留学图片
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        //public List<LunBoImageModel> IndexLXueList()
        //{
        //    try
        //    {
        //        return lunbodal.IndexLXueList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        /// <summary>
        /// 首页资讯图片
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        public List<Information> IndexInforImage()
        {
            try
            {

                return lunbodal.IndexInforImage();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 北京西安资讯图片
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        public List<Information> BeiXiInforImage(int site)
        {

            try
            {
                return lunbodal.BeiXiInforImage(site);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        /// <summary>
        /// 国家页面资讯图片
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        public List<Information> CountryZiXunImage(int countryid)
        {
            try
            {

                return lunbodal.CountryZiXunImage(countryid);

            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// 二维码
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        public List<erweima> ErWeiMaList()
        {
            try
            {
                return lunbodal.ErWeiMaList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
