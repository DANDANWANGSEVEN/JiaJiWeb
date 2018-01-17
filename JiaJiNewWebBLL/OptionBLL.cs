using JiaJiNewWebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebIDAL;
using JiaJiNewWeb.DALFactory;

namespace JiaJiNewWebBLL
{
    public class OptionBLL
    {
        IOptionDAL dal = Factory<IOptionDAL>.Create("OptionDAL");
        ///<summary>
        ///获取热度前六的观点
        /// </summary>
        public List<Option> HotOption()
        {
            return dal.HotOption();
        }
        
        ///<summary>
        ///观点详情
        /// </summary>
        public Option OptionShow(int Id)
        {
            return dal.OptionShow(Id);
        }

        ///<summary>
        ///观点图片详情
        /// </summary>
        public List<JiaJiNewWebModel.Option> HotOptionImage()
        {
            try
            {
                return dal.HotOptionImage();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        ///<summary>
        ///上一个观点
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public Option OptionPrev(int Id)
        {
            try
            {
                return dal.OptionPrev(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        ///<summary>
        ///下一个观点
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public Option OptionNext(int Id)
        {
            try
            {
                return dal.OptionNext(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        ///<summary>
        ///获取全部观点
        /// </summary>
        public List<JiaJiNewWebModel.Option> OptionList(int pageindex)
        {
            try
            {
                return dal.OptionList(pageindex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts()
        {
            try
            {
                return dal.GetRowCounts();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
