using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
using JiaJiModels;

namespace JiaJiBLL
{
    public class FilialeBll
    {


        #region 分公司管理
        /// <summary>
        /// 分公司
        /// </summary>
        /// <returns></returns>
        public List<filialetext> FilialeShow()
        {
            try
            {
                return new JiaJiDAL.FilialeDal().FilialeShow();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 删除分公司信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelFiliale(string filialeID)
        {
            try
            {
                return new JiaJiDAL.FilialeDal().DelFiliale(filialeID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 添加分公司信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addFiliale(JiaJiModels.filialetext model)
        {
            try
            {

                return new JiaJiDAL.FilialeDal().addFiliale(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改分公司信息
        /// </summary>
        /// <returns></returns>
        public int UpdateFiliale(JiaJiModels.filialetext model)
        {
            try
            {
                return new JiaJiDAL.FilialeDal().UpdateFiliale(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion


        #region 分公司介绍管理

        /// <summary>
        /// 获取分公司信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.filialetext> ShowFenGongsi()
        {
            try
            {
                return new JiaJiDAL.FilialeDal().ShowFenGongsi();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 删除分公司信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelFilialeText(string filialeTextID)
        {
            try
            {
                return new JiaJiDAL.FilialeDal().DelFilialeText(filialeTextID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加分公司介绍
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addFilialeText(JiaJiModels.filialetext model)
        {
            try
            {
                return new JiaJiDAL.FilialeDal().addFilialeText(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改分公司介绍
        /// </summary>
        /// <returns></returns>
        public int UpdateFilialeText(JiaJiModels.filialetext model)
        {
            try
            {
                return new JiaJiDAL.FilialeDal().UpdateFilialeText(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }





        #endregion




    }
}
