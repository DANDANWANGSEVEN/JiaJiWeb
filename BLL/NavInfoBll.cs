using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
using JiaJiModels;

namespace JiaJiBLL
{
    public class NavInfoBll
    {
        public List<NavInfo> GetNavList()
        {
            return new JiaJiDAL.NavInfoDal().GetNavList();
        }

        public List<string> GetAllCountry()
        {
            return new NavInfoDal().GetAllCountry();
        }

        public List<NavInfo> GetNavInfo(string Country, int ParentID, string BuWei)
        {
            return new NavInfoDal().GetNavInfo(Country, ParentID, BuWei);
        }

        public List<NavInfo> GetTypeByCountry(string country)
        {
            return new NavInfoDal().GetTypeByCountry(country);
        }

        public List<NavInfo> GetTypeByCountryId(int countryId)
        {
            return new JiaJiDAL.NavInfoDal().GetTypeByCountryId(countryId);
        }

        public bool EditByModelContent(JiaJiModels.NavInfo model)
        {
            return new NavInfoDal().EditByModelContent(model);
        }
        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="NavID"></param>
        /// <returns></returns>
        public NavInfo GetModelByNavID(int NavID)
        {
            return new NavInfoDal().GetModelById(NavID);
        }
        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddByModel(NavInfo model)
        {
            return new NavInfoDal().AddByModel(model);
        }
        /// <summary>
        /// 编辑一条信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditByModel(NavInfo model)
        {
            return new NavInfoDal().EditByModel(model);
        }
        /// <summary>
        /// 删除一条信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteByModel(NavInfo model)
        {
            return new NavInfoDal().DeleteByModel(model);
        }
        /// <summary>
        /// 删除信息包括子节点
        /// </summary>
        /// <param name="RootID">删除节点ID</param>
        /// <returns></returns>
        public bool DeleteByRootID(int RootID)
        {
            return new NavInfoDal().DeleteByRootID(RootID);
        }
    }
}
