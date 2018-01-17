using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JiaJiDAL
{
   public class activedal
    {

        /// <summary>
        /// 获取活动信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Active> Activeshow()
        {
            try
            {
                string sql = "select active.ActiveID,active.ActiveTitle,active.ActiveDate,active.Datails,active.ActivePhone,active.HeatID,country.CountryName,country.CountryID,areases.AreaID,areases.AreaName,active.Site,ActiveKeyWord,ActiveProfile from active left join country on active.CountryID=country.CountryID left join areases on active.Site=areases.AreaID order by  active.ActiveID desc";
                List<JiaJiModels.Active> list = MySqlDB.GetList<JiaJiModels.Active>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加活动信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Activeadd(JiaJiModels.Active model)
        {
            try
            {
                string sql = "insert into active(ActiveTitle,ActiveDate,Site,Datails,ActivePhone,HeatID,CountryID,ActiveKeyWord,ActiveProfile) Values('" + model.ActiveTitle+"','"+model.ActiveDate+"',"+model.Site+",'"+model.Datails+"','"+model.ActivePhone+"',0,"+model.CountryID+",'"+model.ActiveKeyWord+"','"+model.ActiveProfile+"')";

                int h = MySqlDB.nonquery(sql,CommandType.Text,null);
                return h;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
       
        /// <summary>
        /// 删除活动信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool actionDel(string ids)
        {
            try
            {
                string sql = "DELETE from active where ActiveID in (" + ids + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h>0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改活动
        /// </summary>
        /// <returns></returns>
        public int ActiveUpd(JiaJiModels.Active model)
        {
            try
            {
                string sql = "update active set ActiveTitle = '"+model.ActiveTitle+"', ActiveDate = '"+model.ActiveDate+"', Site ="+model.Site+", Datails = '"+model.Datails+"', ActivePhone = '"+model.ActivePhone+"', CountryID="+model.CountryID+ ",ActiveKeyWord='"+model.ActiveKeyWord+ "',ActiveProfile='"+model.ActiveProfile+"'  where ActiveID =" + model.ActiveID+" ";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;

            }
            catch(Exception ex)
            {
                return 0;
            }
        }



    }
}
