using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    public interface ISolutionDAL
    {

        /// <summary>
        /// 首页显示解决方案的信息的信息
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Solution> SolutionIndexList();

        /// <summary>
        /// 首页显示解决方案步骤
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Solution_BuZhou> SolutionBuZhouList();


    }
}
