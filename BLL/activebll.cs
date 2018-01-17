using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
   public class activebll
    {
       
        /// <summary>
        /// 显示活动
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Active> Activeshow()
        {
            return new JiaJiDAL.activedal().Activeshow();
        }

        /// <summary>
        /// 添加活动信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Actionadd(JiaJiModels.Active model)
        {
            try
            {
                return new JiaJiDAL.activedal().Activeadd(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool actionDel(string ids)
        {
            return new JiaJiDAL.activedal().actionDel(ids);
        }


        /// <summary>
        /// 修改活动
        /// </summary>
        /// <returns></returns>
        public int ActiveUpd(JiaJiModels.Active model)
        {
            try
            {
                return new JiaJiDAL.activedal().ActiveUpd(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



    }
}
