using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiModels;
using JiaJiDAL;

namespace JiaJiBLL
{
    public class AreaesBll
    {
        
        /// <summary>
        /// 添加地区
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AreasesAdd(areases model)
        {
            return new JiaJiDAL.AreasesDal().AreasesAdd(model);
        }

        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.areases> ShowArea()
        {
            try
            {
                return new JiaJiDAL.AreasesDal().ShowArea();
            }
            catch (Exception e)
            {
                return null;
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
                return new JiaJiDAL.AreasesDal().DelAreas(ids);
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
                return new JiaJiDAL.AreasesDal().UpdAreases(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
