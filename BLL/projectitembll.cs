using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
   public class projectitembll
    {
      
        /// <summary>
        /// 背景添加
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int proadd(JiaJiModels.projectitem pro)
        {
            return new JiaJiDAL.projectitemdal().proadd(pro);
        }


        /// <summary>
        /// 获取背景提升信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.projectitem> ShowProjectitem()
        {
            try
            {
                return new JiaJiDAL.projectitemdal().ShowProjectitem();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除背景提升信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelProjectitem(string ProjectitemID)
        {
            try
            {
                return new JiaJiDAL.projectitemdal().DelProjectitem(ProjectitemID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 背景修改
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int Updpro(JiaJiModels.projectitem pro)
        {
            try
            {
                return new JiaJiDAL.projectitemdal().Updpro(pro);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
