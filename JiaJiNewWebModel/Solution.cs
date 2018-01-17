using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 解决方案
    /// </summary>
   public  class Solution
    {
        /// <summary>
        /// 解决方案编号
        /// </summary>
        public int SolutionID { get; set; }
        /// <summary>
        /// 解决方案标题
        /// </summary>
        public string SolutionTitle { get; set; }

    }

    public class Solution_BuZhou
    {
        public int SolutionBuZhouID { get; set; }

        public String SolutionBuZhou { get; set; }
    }

}
