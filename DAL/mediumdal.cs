using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace JiaJiDAL
{
    public class mediumdal
    {
        /// <summary>
        /// 添加媒体合作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int mediumadd(JiaJiModels.medium model)
        {
            try
            {
                string sql =string.Format("insert into medium(MediumName,MediumTitle,MediumImg,`UpDate`,MediumUrl) Values('{0}','{1}','{2}','{3}','{4}')", model.MediumName,model.MediumTitle,model.MediumImg,model.UpDate,model.MediumUrl);
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// 显示媒体信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.medium> ShowMedium()
        {

            try
            {
                string sql = "select MediumID,MediumName,MediumTitle,MediumImg,`UpDate`,MediumUrl from medium";
                List<JiaJiModels.medium> mediumlist = MySqlDB.GetList<JiaJiModels.medium>(sql, CommandType.Text, null);
                return mediumlist;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 删除媒体信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelMedium(string did)
        {
            try
            {
                string sql = "delete from medium where MediumID in (" + did + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改媒体合作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdMedium(JiaJiModels.medium model)
        {
            try
            {
                string sql = "update medium set MediumName = '"+model.MediumName+"', MediumTitle = '"+model.MediumTitle+ "', MediumImg = '" + model.MediumImg+ "',MediumUrl='"+model.MediumUrl+"' WHERE MediumID =" + model.MediumID+" ";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



    }
}
