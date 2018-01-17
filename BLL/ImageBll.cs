using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiBLL
{
   public  class ImageBll
    {

        #region 二维码管理


        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ErWeiMaModel> ShowErWeiMa()
        {
            try
            {

                return new JiaJiDAL.ImageDal().ShowErWeiMa();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加二维码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddErWeiMa(JiaJiModels.ErWeiMaModel model)
        {
            try
            {
                return new JiaJiDAL.ImageDal().AddErWeiMa(model);

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除二维码
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelErWeiMa(string did)
        {
            try
            {
                return new JiaJiDAL.ImageDal().DelErWeiMa(did);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改二维码
        /// </summary>
        /// <returns></returns>
        public int UpdateErWeiMa(JiaJiModels.ErWeiMaModel model)
        {
            try
            {
                return new JiaJiDAL.ImageDal().UpdateErWeiMa(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }





        #endregion

        #region 首页轮播图
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.IndexLunBo> ShowIndexLunBo()
        {
            try
            {

                return new JiaJiDAL.ImageDal().ShowIndexLunBo();
                    
             }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddIndexLunBo(JiaJiModels.IndexLunBo model)
        {
            try
            {
                return new JiaJiDAL.ImageDal().AddIndexLunBo(model);


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
        public bool DelIndexLunBo(string did)
        {
            try
            {
                return new JiaJiDAL.ImageDal().DelIndexLunBo(did);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int UpdateIndexLunBo(JiaJiModels.IndexLunBo model)
        {
            try
            {
                return new JiaJiDAL.ImageDal().UpdateIndexLunBo(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion

        #region  国家页图片

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.LunBoImage> ShowCounImage()
        {
            try
            {

                return new JiaJiDAL.ImageDal().ShowCounImage();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCounImage(JiaJiModels.LunBoImage model)
        {
            try
            {

                return new JiaJiDAL.ImageDal().AddCounImage(model);
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
        public bool DelCounImage(string did)
        {
            try
            {
                return new JiaJiDAL.ImageDal().DelCounImage(did);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int UpdateCounImage(JiaJiModels.LunBoImage model)
        {
            try
            {
                return new JiaJiDAL.ImageDal().UpdateCounImage(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        #endregion



    }
}
