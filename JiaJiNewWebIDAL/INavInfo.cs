using JiaJiNewWebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    public interface INavInfo
    {
        List<JiaJiNewWebModel.NavInfoModel> GetAllNavInfoByGuoJia(string GuoJia);
        bool AddByModel(JiaJiNewWebModel.NavInfoModel model);
        bool EditByModel(JiaJiNewWebModel.NavInfoModel model);
        bool DeleteByModel(JiaJiNewWebModel.NavInfoModel model);

        ///<summary>
        ///上一个导航标题
        ///<para>Id:导航标题Id</para>
        /// </summary>
        NavInfoModel GetModelByIdPrev(int Id);
        ///<summary>
        ///下一个导航标题
        ///<para>Id:导航标题Id</para>
        /// </summary>
        NavInfoModel GetModelByIdNext(int Id);

    }
}
