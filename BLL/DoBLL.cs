using JiaJiDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiBLL
{
    public class DoBLL
    {
        DoDAL dal = new DoDAL();


        /// <summary>
        /// 获取优势信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.DominantModel> ShowDominant()
        {
            try
            {
                return dal.ShowDominant();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加优势
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addDominant(JiaJiModels.DominantModel model)
        {
            try
            {
                return new JiaJiDAL.DoDAL().addDominant(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除优势
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelDominant(string did)
        {
            try
            {
                return new JiaJiDAL.DoDAL().DelDominant(did);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 修改课程
        /// </summary>
        /// <returns></returns>
        public int UpdateDominant(JiaJiModels.DominantModel model)
        {
            try
            {
                return new JiaJiDAL.DoDAL().UpdateDominant(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
