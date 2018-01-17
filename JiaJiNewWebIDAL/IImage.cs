using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
   public interface IImage
    {

        /// <summary>
        /// 获取首页轮播图
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.IndexImage> IndexImageLsit();

    }
}
