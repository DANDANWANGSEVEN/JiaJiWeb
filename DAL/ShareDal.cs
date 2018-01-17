using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiaJiModels;

namespace JiaJiDAL
{
   public  class ShareDal
    {


        /// <summary>
        /// 获取学员分享列表
        /// </summary>
        /// <returns></returns>
        
        public List<JiaJiModels.ShareModel> INshow()
        {
            try
            {

                string sql = "SELECT InformationID,Title,Content,InfoDate,`Source`,Author,ReadCount,LookYes,information.CountryID,information.Site,areases.AreaID,areases.AreaName from information left join country on information.CountryID=country.CountryID left join areases on information.Site=areases.AreaID order by InformationID desc ";
                List<JiaJiModels.ShareModel> list = MySqlDB.GetList<JiaJiModels.ShareModel>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加学员分享列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int infoadd(JiaJiModels.ShareModel model)
        {
            try
            {

                string sql = "INSERT INTO study_abroad.information (Title, Content, InfoDate, Source, Author, ReadCount, LookYes, CountryID,Site)VALUES ('" + model.Title + "', '" + model.Content + "', '" + model.InfoDate + "', '" + model.Source + "', '" + model.Author + "', " + model.ReadCount + ", " + model.LookYes + ", " + model.CountryID + "," + model.Site + ")";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除学员分享列表
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool infoDel(string did)
        {
            try
            {
                string sql = "delete from information where InformationID in ('" + did + "')";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改学员分享列表
        /// </summary>
        /// <returns></returns>
        public int UpdateInformation(JiaJiModels.ShareModel model)
        {
            try
            {
                string sql = "Update study_abroad.information set Title = '" + model.Title + "', Content = '" + model.Content + "', InfoDate = '" + model.InfoDate + "', `Source`= '" + model.Source + "', Author = '" + model.Author + "', ReadCount =" + model.ReadCount + ", LookYes =" + model.LookYes + ", CountryID =" + model.CountryID + ",site =" + model.Site + " where informationID =" + model.InformationID + " ";
                int he = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }






    }
}
