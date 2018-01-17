using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
   public class statrgybll
    {
       
        /// <summary>
        /// 攻略添加
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public int addstat(JiaJiModels.strategy stat)
        {
            return new JiaJiDAL.strategydal().addstat(stat);
        }

        /// <summary>
        /// 策略显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.strategy> ShowStrategy()
        {
            try
            {
                return new JiaJiDAL.strategydal().ShowStrategy();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除策略信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelStrategy(string ids)
        {
            try
            {
                return new JiaJiDAL.strategydal().DelStrategy(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改攻略信息
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public int Updatestrategy(JiaJiModels.strategy stat)
        {
            try
            {
                return new JiaJiDAL.strategydal().Updatestrategy(stat);
            }
            catch (Exception ex)
            {
                var s = ex;
                return 0;
            }
        }



    }
}
