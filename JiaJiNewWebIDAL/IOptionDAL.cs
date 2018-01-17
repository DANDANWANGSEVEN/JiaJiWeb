using JiaJiNewWebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    public interface IOptionDAL
    {
        ///<summary>
        ///获取热度前六的观点
        /// </summary>
        List<Option> HotOption();

        /// <summary>
        /// 全阿布观点
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.Option> OptionList(int pageindex);

        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        int GetRowCounts();

        ///<summary>
        ///观点详情
        /// </summary>
       Option OptionShow(int Id);

        ///<summary>
        ///观点图片详情
        /// </summary>
       List<JiaJiNewWebModel.Option> HotOptionImage();

        ///<summary>
        ///上一个观点
        ///<para>Id:成功案列Id</para>
        /// </summary>
        Option OptionPrev(int Id);


        ///<summary>
        ///下一个观点
        ///<para>Id:成功案列Id</para>
        /// </summary>
        Option OptionNext(int Id);

    }
}
