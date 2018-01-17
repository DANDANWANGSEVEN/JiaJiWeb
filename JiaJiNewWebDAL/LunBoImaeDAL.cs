using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiaJiNewWebModel;
using JiaJiNewWeb.Common;
using System.Data;
using MySql.Data.MySqlClient;

namespace JiaJiNewWebDAL
{
   public  class LunBoImaeDAL:JiaJiNewWebIDAL.ILunBoImageDAL
    {

        /// <summary>
        /// 国家页面轮播图  根据上传时间倒叙
        /// </summary>
        /// <param name="countryid"></param>
        /// <param name="educatonid"></param>
        /// <returns></returns>
        public List<LunBoImageModel> LunBoList(int countryid, int educatonid)
        {
            //,int educatonid
            try
            {

                StringBuilder sql = new StringBuilder();
                sql.Append(" select LunImageID,lunboimage.ImageUrl,lunboimage.EducationID,lunboimage.CountryID,CountryName,lunboimage.`UpDate`,lunboimage.IsLunBo from lunboimage   ");
                sql.Append(" left join country on lunboimage.CountryID=country.CountryID ");
                sql.Append(" left join educationtype on lunboimage.EducationID=educationtype.EducationID ");
                sql.Append(" where lunboimage.CountryID="+ countryid + " AND lunboimage.EducationID=" + educatonid + "  AND lunboimage.IsLunBo=1 ");
                sql.Append(" ORDER BY lunboimage.`UpDate` DESC LIMIT 3 ");

                List<LunBoImageModel> list = MySqlDB.GetList<LunBoImageModel>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;

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
        public List<LunBoImageModel> NoLunBoList(int countryid, int educatonid)
        {
            try
            {

                StringBuilder sql = new StringBuilder();
                sql.Append(" select lunboimage.ImageUrl,CountryName,lunboimage.`UpDate` from lunboimage   ");
                sql.Append(" left join country on lunboimage.CountryID=country.CountryID ");
                sql.Append(" left join educationtype on lunboimage.EducationID=educationtype.EducationID ");
                sql.Append(" where lunboimage.CountryID="+ countryid + " and lunboimage.EducationID=" + educatonid + " AND lunboimage.IsLunBo=0 ");
                sql.Append(" ORDER BY lunboimage.`UpDate` DESC LIMIT 2 ");

                List<LunBoImageModel> list = MySqlDB.GetList<LunBoImageModel>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        ///// <summary>
        ///// 首页留学图片
        ///// </summary>
        ///// <param name="countryid"></param>
        ///// <param name="educatonid"></param>
        ///// <returns></returns>
        //public List<LunBoImageModel> IndexLXueList()
        //{
        //    try
        //    {

        //        StringBuilder sql = new StringBuilder();
        //        sql.Append(" select lunboimage.ImageUrl,lunboimage.`UpDate` from lunboimage where IsLunBo=3 order by `UpDate` desc limit 2   ");

        //        List<LunBoImageModel> list = MySqlDB.GetList<LunBoImageModel>(sql.ToString(), System.Data.CommandType.Text, null);
        //        return list;

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
                string sql = "select InformationID,Title,InformationImgUrl from information where ReadCount=(select MAX(ReadCount) from information) limit 1";
                List<Information> list = MySqlDB.GetList<Information>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
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
                string sql = "select InformationID,Title,InformationImgUrl from information where ReadCount=(select MAX(ReadCount) from information where Site=" + site+ ") limit 1";
                List<Information> list = MySqlDB.GetList<Information>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
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

                string sql = "select InformationID,Title,InformationImgUrl from information where ReadCount=(select MAX(ReadCount) from information where CountryID=" + countryid + ") limit 1";
                List<Information> list = MySqlDB.GetList<Information>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
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

                StringBuilder sql = new StringBuilder();
                sql.Append(" select EWMTitle,EWMUrl from erweimainfo order by EWMUpdate desc limit 4   ");

                List<erweima> list = MySqlDB.GetList<erweima>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }




    }
}
