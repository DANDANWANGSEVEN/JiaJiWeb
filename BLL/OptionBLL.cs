using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiBLL
{
  public  class OptionBLL
    {
        /// <summary>
        /// 添加嘉际观点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddOption(JiaJiModels.OptionModel model)
        {
         
            return new JiaJiDAL.OptionDAL().AddOption(model);
        }

        /// <summary>
        /// 嘉际观点显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.OptionModel> ShowOptions()
        {
            try
            {
                return new JiaJiDAL.OptionDAL().ShowOptions();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除嘉际观点
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelOptions(string optionid)
        {
            try
            {
                return new JiaJiDAL.OptionDAL().DelOptions(optionid);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改观点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdOptions(JiaJiModels.OptionModel model)
        {
            try
            {
                return new JiaJiDAL.OptionDAL().UpdOptions(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
