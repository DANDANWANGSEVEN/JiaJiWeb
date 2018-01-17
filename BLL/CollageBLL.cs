using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
namespace JiaJiBLL
{
   public class CollageBLL
    {
        CollageDAL dal = new CollageDAL();
        #region 学院
        /// <summary>
        /// 录取学院添加
        /// </summary>
        /// <param name="cname"></param>
        /// <returns></returns>
        public int collageadd(JiaJiModels.collages model)
        {
            try
            {
                return new JiaJiDAL.CollageDAL().collageadd(model);
            }
            catch (Exception ex)
            {
                var s = ex;
                return 0;
            }
        }

        /// <summary>
        /// 修改录取学院
        /// </summary>
        /// <returns></returns>
        public int UpdateCollege(JiaJiModels.collages model)
        {
            try
            {
                return new JiaJiDAL.CollageDAL().UpdateCollege(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 删除录取学院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelCollage(string ids)
        {
            try
            {
                return new JiaJiDAL.CollageDAL().DelCollage(ids);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 获取录取学院列表
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.collages> Collegehow()
        {
            try
            {
                return new JiaJiDAL.CollageDAL().Collegehow();
            }
            catch (Exception ex)
            {
                var s = ex;
                return null;
            }
        }
        #endregion
        /// <summary>
        /// 添加就读学院信息
        /// </summary>
        /// <param name="aname"></param>
        /// <returns></returns>
        public int Attendadd(string aname)
        {
            return dal.Attendadd(aname);
        }
        /// <summary>
        /// 获取就读学院列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Attending> Ashow()
        {
            return dal.Ashow();
        }
        /// <summary>
        /// 删除就读学院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelAttending(int id)
        {
            return dal.DelAttending(id);

        }
    }
}
