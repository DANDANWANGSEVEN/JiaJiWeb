using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiBLL
{
    public  class LearnerBll
    {

        #region 学员列表

        /// <summary>
        /// 获取学员列表
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.LearnerModel> showLearner()
        {
            try
            {
                return new JiaJiDAL.LearnerDal().showLearner();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加学员列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addLearner(JiaJiModels.LearnerModel model)
        {
            try
            {

                return new JiaJiDAL.LearnerDal().addLearner(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除学员列表
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelLearner(string did)
        {
            try
            {
                return new JiaJiDAL.LearnerDal().DelLearner(did);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改学员列表
        /// </summary>
        /// <returns></returns>
        public int UpdateLearner(JiaJiModels.LearnerModel model)
        {
            try
            {
                return new JiaJiDAL.LearnerDal().UpdateLearner(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        #endregion


        #region 高分学员

        /// <summary>
        /// 获取高分学员
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.LearnerModel> showMaxScoStu()
        {
            try
            {
                return new JiaJiDAL.LearnerDal().showMaxScoStu();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加高分学员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addMaxScoStu(JiaJiModels.LearnerModel model)
        {
            try
            {
                return new JiaJiDAL.LearnerDal().addMaxScoStu(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除高分学员
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelMaxScoStu(string did)
        {
            try
            {
                return new JiaJiDAL.LearnerDal().DelMaxScoStu(did);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改高分学员
        /// </summary>
        /// <returns></returns>
        public int UpdateMaxScoStu(JiaJiModels.LearnerModel model)
        {
            try
            {
                return new JiaJiDAL.LearnerDal().UpdateMaxScoStu(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion





    }
}
