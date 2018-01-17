using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiDAL
{
    public  class ImageDal
    {


        #region 二维码管理


        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ErWeiMaModel> ShowErWeiMa()
        {
            try
            {

                string sql = "select EWMID,EWMTitle,EWMUrl,EWMUpdate from erweimainfo order by EWMUpdate desc";
                List<JiaJiModels.ErWeiMaModel> list = MySqlDB.GetList<JiaJiModels.ErWeiMaModel>(sql.ToString(), System.Data.CommandType.Text, null);


                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加二维码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddErWeiMa(JiaJiModels.ErWeiMaModel model)
        {
            try
            {

                string sql = "INSERT INTO erweimainfo (EWMTitle, EWMUrl, EWMUpdate)VALUES ('" + model.EWMTitle + "', '" + model.EWMUrl + "', '"+model.EWMUpdate+"')";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除二维码
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelErWeiMa(string did)
        {
            try
            {
                string sql = "delete from erweimainfo where EWMId in (" + did + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改二维码
        /// </summary>
        /// <returns></returns>
        public int UpdateErWeiMa(JiaJiModels.ErWeiMaModel model)
        {
            try
            {
                string sql = "Update erweimainfo set EWMTitle = '" + model.EWMTitle + "', EWMUrl = '" + model.EWMUrl + "', EWMUpdate = '" + model.EWMUpdate + "' where EWMID="+model.EWMID+" ";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }





        #endregion

        #region 首页轮播图

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.IndexLunBo> ShowIndexLunBo()
        {
            try
            {

                string sql = "select * from indeximage order by ImageID desc";
                List<JiaJiModels.IndexLunBo> list = MySqlDB.GetList<JiaJiModels.IndexLunBo>(sql.ToString(), System.Data.CommandType.Text, null);

                //var url = System.Configuration.ConfigurationManager.AppSettings["WebSiteUrl"].ToString();
                //list.ForEach(m => { m.ImageUrl = url.EndsWith("/") ? url + m.ImageUrl : string.Format("{0}/{1}", url, m.ImageUrl); });

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddIndexLunBo(JiaJiModels.IndexLunBo model)
        {
            try
            {

                string sql = "INSERT INTO indeximage (ImageUrl, ImageUpDate,ImageProduce)VALUES ('" + model.ImageUrl + "', '" + model.ImageUpDate + "','"+model.ImageProduce+"')";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelIndexLunBo(string did)
        {
            try
            {
                string sql = "delete from indeximage where ImageID in (" + did + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int UpdateIndexLunBo(JiaJiModels.IndexLunBo model)
        {
            try
            {
                string sql = "Update indeximage set ImageUrl = '" + model.ImageUrl + "', ImageUpDate = '" + model.ImageUpDate + "', ImageProduce='"+model.ImageProduce+"' where ImageID="+model.ImageID+" ";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion

        #region  国家页图片

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.LunBoImage> ShowCounImage()
        {
            try
            {

                string sql = "select * from lunboimage  LEFT JOIN country on lunboimage.CountryID=country.CountryID LEFT JOIN educationtype on lunboimage.EducationID=educationtype.EducationID  order by LunImageID desc";
                List<JiaJiModels.LunBoImage> list = MySqlDB.GetList<JiaJiModels.LunBoImage>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCounImage(JiaJiModels.LunBoImage model)
        {
            try
            {

                string sql = "INSERT INTO lunboimage(ImageUrl, IsLunBo, CountryID,`UpDate`,EducationID) VALUE('" + model.ImageUrl + "', " + model.IsLunBo + ","+model.CountryID+",'"+model.UpDate+"',"+model.EducationID+")";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelCounImage(string did)
        {
            try
            {
                string sql = "delete from lunboimage where LunImageID in (" + did + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int UpdateCounImage(JiaJiModels.LunBoImage model)
        {
            try
            {
                string sql = "Update lunboimage set ImageUrl = '" + model.ImageUrl + "', IsLunBo = " + model.IsLunBo + ",CountryID="+model.CountryID+ ",`UpDate`='"+model.UpDate+"',EducationID="+model.EducationID+"  where LunImageID=" + model.LunImageID + " ";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        #endregion

    }
}
