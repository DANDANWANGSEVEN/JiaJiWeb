using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    /// <summary>
    /// 项目内容加载接口
    /// </summary>
    public interface IProjectItemDAL
    {


        /// <summary>
        /// 获取项目列表信息
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.projectItem> GetProductList();

        /// <summary>
        /// 获取项目对应的图片
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.projectItem> GetProImgList(int proid);


        /// <summary>
        /// 获取项目对应学员分享的内容列表信息
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Share> GetShareList(int id);

        /// <summary>
        /// 获取分享详情
        /// </summary>
        /// <returns></returns>
        JiaJiNewWebModel.Share GetShareContent(int shareid);


        /// <summary>
        /// 获取所有的学员分享
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Share> GetAllShareList(int pageindex);

        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        int GetShareRowCounts();

        /// <summary>
        /// 获取首加载时
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Share> GetFirstList();


        ///<summary>
        ///上一个分享
        ///<para>Id:分享Id</para>
        /// </summary>
        JiaJiNewWebModel.Share SharePrev(int Id);
        ///<summary>
        ///下一个分享
        ///<para>Id:分享Id</para>
        /// </summary>
        JiaJiNewWebModel.Share ShareNext(int Id);



    }
}
