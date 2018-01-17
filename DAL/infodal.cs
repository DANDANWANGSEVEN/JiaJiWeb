using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace JiaJiDAL
{
    public class infodal
    {

        /// <summary>
        /// 获取资讯列表
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Information> INshow(string Title)
        {
            try
            {

                string sql = "SELECT InformationID,Title,Content,InfoDate,`Source`,Author,ReadCount,information.CountryID,information.Site,areases.AreaID,areases.AreaName,InformationImgUrl,InfoKeyWord,InformationProfile from information left join country on information.CountryID=country.CountryID left join areases on information.Site=areases.AreaID  order by InformationID desc  ";
                List<JiaJiModels.Information> list = MySqlDB.GetList<JiaJiModels.Information>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加资讯信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int infoadd(JiaJiModels.Information model)
        {
            try
            {

                string sql = "INSERT INTO study_abroad.information (Title, Content, InfoDate, Source, Author, ReadCount, CountryID,Site,InformationImgUrl,InfoKeyWord,InformationProfile)VALUES ('" + model.Title+"', '"+model.Content+"', '"+model.InfoDate+"', '"+model.Source+"', '"+model.Author+"', "+model.ReadCount+", "+model.CountryID+","+model.Site+",'"+model.InformationImgUrl+"','"+model.InfoKeyWord+"','"+model.InformationProfile+"')";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除资讯信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool infoDel(string did)
        {
            try
            {
                string sql = "delete from information where InformationID in (" + did + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <returns></returns>
        public int UpdateInformation(JiaJiModels.Information model)
        {
            try
            {
                string sql = "Update study_abroad.information set Title = '"+model.Title+"', Content = '"+model.Content+"', InfoDate = '"+model.InfoDate+"', `Source`= '"+model.Source+"', Author = '"+model.Author+"', CountryID ="+model.CountryID+",site ="+model.Site+ ",InformationImgUrl='"+model.InformationImgUrl+ "',InfoKeyWord='"+model.InfoKeyWord+ "',InformationProfile='"+model.InformationProfile+"' where informationID =" + model.InformationID+" ";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }




        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>double</returns>
        public static double ConvertDateTimeInt(System.DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return intResult;
        }

     

    }
}
