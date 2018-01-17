using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
using JiaJiModels;

namespace JiaJiBLL
{
    public class SprelationBll
    {
       
        /// <summary>
        /// 显示学历信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.educationtype> Edushow()
        {
            return new JiaJiDAL.SprelationDal().Edushow();
        }

        #region 国家
        /// <summary>
        /// 显示国家信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.country> Countryshow()
        {
            return new JiaJiDAL.SprelationDal().Countryshow();
        }
        public List<JiaJiModels.country> allshow()
        {
            try
            {

                return new JiaJiDAL.SprelationDal().allshow();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取语言背景移民
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.country> LBYshow()
        {
            try
            {

                return new JiaJiDAL.SprelationDal().LBYshow();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 删除国家
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelCountry(string ids)
        {
            try
            {
                return new JiaJiDAL.SprelationDal().DelCountry(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 添加留学规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCountry(JiaJiModels.country model)
        {
            try
            {
                return new JiaJiDAL.SprelationDal().AddCountry(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 添加YBY
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddLBY(JiaJiModels.country model)
        {
            try
            {

                return new JiaJiDAL.SprelationDal().AddLBY(model);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改留学规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdCountry(JiaJiModels.country model)
        {
            try
            {
                return new JiaJiDAL.SprelationDal().UpdCountry(model);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        #endregion

        #region 留学规划
        /// <summary>
        /// 获取留学规划信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.StudentProgram> ShowLiuXueGuiHua()
        {
            try
            {
                return new JiaJiDAL.SprelationDal().ShowLiuXueGuiHua();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除留学规划信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelLiuXueGuiHua(string SPRelationID)
        {
            try
            {
                return new JiaJiDAL.SprelationDal().DelLiuXueGuiHua(SPRelationID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加留学规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int StudentprogramAdd(JiaJiModels.StudentProgram model)
        {
            try
            {
                return new JiaJiDAL.SprelationDal().StudentprogramAdd(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        /// <summary>
        /// 修改留学规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdStudentprogram(JiaJiModels.StudentProgram model)
        {
            try
            {
                return new JiaJiDAL.SprelationDal().UpdStudentprogram(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

    }
}
