using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace JiaJiDAL
{
    public class DoDAL
    {

        /// <summary>
        /// 获取优势信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.DominantModel> ShowDominant()
        {
            try
            {
                //string sql = "select CountryDominantID,countrydominant.DominantID,countrydominant.CountryID,CountryName,DominantName,Chance from countrydominant left join dominant on countrydominant.DominantID=dominant.DominantID  left join country on countrydominant.CountryID=country.CountryID";
                string sql = "select DominantID,DominantName,dominant.CountryID,CountryName from dominant left join country on dominant.CountryID=country.CountryID";
                List<JiaJiModels.DominantModel> list = MySqlDB.GetList<JiaJiModels.DominantModel>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 添加优势
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addDominant(JiaJiModels.DominantModel model)
        {
            try
            {
                string sql = "insert into dominant(DominantName,CountryID) VALUE('" + model.DominantName+ "',"+model.CountryID+") ";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除优势
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelDominant(string did)
        {
            try
            {
               
                string sql = "delete  from dominant where DominantID in (" + did + ") ";

                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改课程
        /// </summary>
        /// <returns></returns>
        public int UpdateDominant(JiaJiModels.DominantModel model)
        {
            try
            {

                string sql = "update dominant set DominantName='"+model.DominantName+"',CountryID="+model.CountryID+" where DominantID="+model.DominantID + "";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
