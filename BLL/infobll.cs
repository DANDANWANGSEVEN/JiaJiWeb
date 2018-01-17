using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
    public class infobll
    {
   
        
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Information> INshow(string Title)
        {
            return new infodal().INshow(Title);
        }
        /// <summary>
        /// 添加资讯信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int infoadd(JiaJiModels.Information model)
        {
            try
            {
                return new infodal().infoadd(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool infoDel(string did)
        {
            try
            {
                return new infodal().infoDel(did);
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <returns></returns>
        public int UpdateInformation(JiaJiModels.Information model)
        {
            try
            {
                return new infodal().UpdateInformation(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
