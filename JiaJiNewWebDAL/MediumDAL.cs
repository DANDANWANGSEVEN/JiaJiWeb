using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebDAL
{
    public class MediumDAL:JiaJiNewWebIDAL.IMediumDAL
    {
        /// <summary>
        /// 获取合作的媒体
        /// </summary>
        /// <returns></returns>
        public List<Medium> GetMedium()
        {
            try
            {
                string sql = "select MediumID,MediumName,MediumTitle,MediumImg,MediumUrl,`UpDate` from medium order by `UPDATE` desc LIMIT 3";
                List<Medium> list = MySqlDB.GetList<Medium>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
