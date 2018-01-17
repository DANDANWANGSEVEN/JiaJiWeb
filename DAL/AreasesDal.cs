using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiModels;
using MySql.Data.MySqlClient;

namespace JiaJiDAL
{
    public class AreasesDal
    {
        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.areases> ShowArea()
        {
            try
            {
                string sql = "select AreaID,AreaName from areases ";
                List<JiaJiModels.areases> arealist = MySqlDB.GetList<JiaJiModels.areases>(sql, System.Data.CommandType.Text, null);
                return arealist;
            }
            catch (Exception e)
            {
                return null;
            }



        }

        /// <summary>
        /// 地区添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AreasesAdd(areases model)
        {
            try
            {
                string sql = "insert into areases(AreaName) values('"+model.AreaName+"')";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除地区信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelAreas(string ids)
        {
            try
            {
                string sql = "delete from active where Site in ("+ids+"); ";
                sql = "delete from areases where AreaID in (" + ids + ")";

                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 地区修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdAreases(areases model)
        {
            try
            {
                string sql = "Update areases set AreaName='"+model.AreaName+"' where AreaID="+model.AreaID+"";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
