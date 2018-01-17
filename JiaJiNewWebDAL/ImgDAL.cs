using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebDAL
{
   public class ImgDAL: JiaJiNewWebIDAL.IImage
    {

        /// <summary>
        /// 获取首页轮播图
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.IndexImage> IndexImageLsit()
        {
            try
            {
                string sql = "select  * from indeximage ORDER BY ImageUpDate DESC Limit 0,3";

                List<JiaJiNewWebModel.IndexImage> indeximglist= MySqlDB.GetList<JiaJiNewWebModel.IndexImage>(sql, System.Data.CommandType.Text, null);
                return indeximglist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}
