using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWeb.DALFactory;
using JiaJiNewWebModel;

namespace JiaJiNewWebBLL
{
    public class ImageBLL
    {
        JiaJiNewWebIDAL.IImage ImageDal = Factory<JiaJiNewWebIDAL.IImage>.Create("ImgDAL");
        /// <summary>
        /// 获取首页轮播图
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.IndexImage> IndexImageLsit()
        {
            try
            {
                return ImageDal.IndexImageLsit();
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
}
