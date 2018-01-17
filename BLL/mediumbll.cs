using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
   public class mediumbll
    {
        mediumdal dal = new mediumdal();
        /// <summary>
        /// 添加媒体合作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int mediumadd(JiaJiModels.medium model)
        {
            return new JiaJiDAL.mediumdal().mediumadd(model);
        }


        /// <summary>
        /// 显示媒体信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.medium> ShowMedium()
        {
            return new JiaJiDAL.mediumdal().ShowMedium();
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
                return new JiaJiDAL.mediumdal().UpdMedium(model);
            }
            catch (Exception ex)
            {
                return 0;
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
                return new JiaJiDAL.mediumdal().DelMedium(did);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
