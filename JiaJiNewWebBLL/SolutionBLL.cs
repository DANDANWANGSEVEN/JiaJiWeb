using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWeb.DALFactory;
namespace JiaJiNewWebBLL
{
  public  class SolutionBLL
    {

        JiaJiNewWebIDAL.ISolutionDAL udal = Factory<JiaJiNewWebIDAL.ISolutionDAL>.Create("SolutionDAL");
        /// <summary>
        /// 首页显示解决方案的信息的信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Solution> SolutionIndexList()
        {
            return udal.SolutionIndexList();
        }

        /// <summary>
        /// 首页显示解决方案步骤
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Solution_BuZhou> SolutionBuZhouList()
        {


            try
            {
                return udal.SolutionBuZhouList();
            }
            catch (System.Exception ex)
            {
                return null;

            }
        }

    }
}
