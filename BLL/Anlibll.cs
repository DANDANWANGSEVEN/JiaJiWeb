using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
   public class Anlibll
    {

        #region 成功案例

        /// <summary>
        /// 显示成功案例列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public List<JiaJiModels.Anli> ShowSuccessAnli()
        {
            try
            {
                return new JiaJiDAL.Anlidal().ShowSuccessAnli();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 删除成功案例
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DelAnli(string ids)
        {
            try
            {
                return new JiaJiDAL.Anlidal().DelAnli(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 成功案例添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Anliadd(JiaJiModels.Anli model, int teamid)
        {
            try
            {
                return new JiaJiDAL.Anlidal().Anliadd(model, teamid);

            }
            catch (Exception)
            {

                return 0;
            }
        }


        /// <summary>
        /// 修改成功案例
        /// </summary>
        /// <returns></returns>
        public int UpdateAnLi(JiaJiModels.Anli model, int teamid)
        {
            try
            {
                return new JiaJiDAL.Anlidal().UpdateAnLi(model, teamid);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        #endregion




        Anlidal dal = new Anlidal();
      


    }
}
