using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
   public class Solutionbll
    {
        /// <summary>
        /// 解决方案添加
        /// </summary>
        /// <param name="sol"></param>
        /// <returns></returns>
        public int soladd(JiaJiModels.solution sol)
        {
            return new JiaJiDAL.solutiondal().soladd(sol);
        }

        /// <summary>
        /// 显示解决方案
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.solution> ShowSolution()
        {
            return new JiaJiDAL.solutiondal().ShowSolution();
        }

        /// <summary>
        /// 删除解决方案
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelSolution(string SolutionID)
        {
            try
            {
                return new JiaJiDAL.solutiondal().DelSolution(SolutionID);           
              }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 解决方案修改
        /// </summary>
        /// <param name="sol"></param>
        /// <returns></returns>
        public int UpdSolu(JiaJiModels.solution sol)
        {
            try
            {
                return new JiaJiDAL.solutiondal().UpdSolu(sol);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
