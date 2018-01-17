using JiaJiDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiBLL
{
    public class ApplyBLL
    {
        #region 获取免费留学方案
        /// <summary>
        /// 获取免费留学方案
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Apply> StuApplyList()
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().StuApplyList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 删除资讯信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelApply(string applyid)
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().DelApply(applyid);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion


        #region  留学时间规划

        /// <summary>
        /// 获取留学规时间规划
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ApplyModel.ArrangeTime> ShowArrangTime()
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().ShowArrangTime();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加留学规时间规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addArrangeTime(JiaJiModels.ApplyModel.ArrangeTime model)
        {
            try
            {

                return new JiaJiDAL.ApplyDAL().addArrangeTime(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除留学规时间规划
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelArrangetime(string ids)
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().DelArrangetime(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改留学规时间规划
        /// </summary>
        /// <returns></returns>
        public int UpdArrangeTime(JiaJiModels.ApplyModel.ArrangeTime model)
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().UpdArrangeTime(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region 留学申请条件
        /// <summary>
        /// 获取留学申请条件
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ApplyModel.ApplyCondition> ShowApplyCondition()
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().ShowApplyCondition();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加留学申请条件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addApplyCondition(JiaJiModels.ApplyModel.ApplyCondition model)
        {
            try
            {

                return new JiaJiDAL.ApplyDAL().addApplyCondition(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除留学申请条件
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelApplyCondition(string ids)
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().DelApplyCondition(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改留学申请条件
        /// </summary>
        /// <returns></returns>
        public int UpdApplyCondition(JiaJiModels.ApplyModel.ApplyCondition model)
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().UpdApplyCondition(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取留学申请内容
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ApplyModel.ApplyContentInfo> ShowApplyContent()
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().ShowApplyContent();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加留学申请内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addApplyContent(JiaJiModels.ApplyModel.ApplyContentInfo model)
        {
            try
            {

                return new JiaJiDAL.ApplyDAL().addApplyContent(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除留学申请内容
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelApplyContent(string ids)
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().DelApplyContent(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改留学申请内容
        /// </summary>
        /// <returns></returns>
        public int UpdApplyContent(JiaJiModels.ApplyModel.ApplyContentInfo model)
        {
            try
            {
                return new JiaJiDAL.ApplyDAL().UpdApplyContent(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion




        /// <summary>
        /// 留学材料
        /// </summary>
        /// <param name="Con"></param>
        /// <returns></returns>
        public int ArrangeCondition(JiaJiModels.ApplyModel.ApplyCondition Con)
        {
            return new JiaJiDAL.ApplyDAL().ArrangeCondition(Con);
        }
        /// <summary>
        /// 留学规划类别
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ProgramType(JiaJiModels.ApplyModel.StudentProgramType type)
        {
            return new JiaJiDAL.ApplyDAL().ProgramType(type);
        }
    }
}
