using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiBLL
{
    public  class EducetionBll
    {

        #region 学历
        /// <summary>
        /// 显示学历
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.educationtype> ShowEducation()
        {
            try
            {
                return new JiaJiDAL.EducationDal().ShowEducation();
            }
            catch (Exception e)
            {
                return null;
            }



        }

        /// <summary>
        /// 地区学历
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddEducation(JiaJiModels.educationtype model)
        {
            try
            {
                return new JiaJiDAL.EducationDal().AddEducation(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除学历
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelEducation(string ids)
        {
            try
            {
                return new JiaJiDAL.EducationDal().DelEducation(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// xiugai学历
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdEducation(JiaJiModels.educationtype model)
        {
            try
            {
                return new JiaJiDAL.EducationDal().UpdEducation(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion







    }
}
