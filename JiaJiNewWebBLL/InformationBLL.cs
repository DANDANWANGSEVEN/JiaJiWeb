using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
    public class InformationBLL
    {
        JiaJiNewWebIDAL.IInformationDAL idal = JiaJiNewWeb.DALFactory.Factory<JiaJiNewWebIDAL.IInformationDAL>.Create("InformationDAL");
        /// <summary>
        /// 热门资讯显示前6条
        /// </summary>
        /// <returns></returns>
        public List<Information> GetInformationTopList(int countryid)
        {
            return idal.GetInformationTopList(countryid);
        }
        /// <summary>
        /// 根据热度显示资讯列表（分页）
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public List<Information> GetInformationList(int pageindex)
        {
            return idal.GetInformationList(pageindex);
        }

        /// <summary>
        /// 获取搜索结果的行数
        /// </summary>
        /// <param name="selcontent"></param>
        /// <returns></returns>
        public int SelectRowCounts(string selcontent)
        {
            try
            {
                return idal.SelectRowCounts(selcontent);
            }

            catch (Exception ex)
            {
                return 0;
            }

        }


        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts()
        {
            return idal.GetRowCounts();
        }

        /// <summary>
        /// 热门资讯显示前6条
        /// </summary>
        /// <returns></returns>

        public List<Information> GetInformationTopList()
        {
            return idal.GetInformationTopList();
        }

        ///<summary>
        ///获取资讯的详情
        /// InformationID:资讯ID
        /// </summary>
        public Information InformationShow(int InformationID)
        {
            return idal.InformationShow(InformationID);
        }

        /// <summary>
        /// 北京资讯
        /// </summary>
        /// <returns></returns>

        public List<Information> GetBeiJingInfor()
        {
            try
            {
                return idal.GetBeiJingInfor();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// xian资讯
        /// </summary>
        /// <returns></returns>
        public List<Information> GetXiAnInfor()
        {
            try
            {
                return idal.GetXiAnInfor();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// 搜索关键字
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Home.SearchDetails> Select(JiaJiNewWebModel.Home.selectmodel model)
        {
            try
            {
                return idal.Select(model);
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        ///<summary>
        ///上一个留学资讯
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public Information inforPrev(int Id)
        {
            try
            {
                return idal.InforPrev(Id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        ///<summary>
        ///下一个留学资讯
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public Information inforNext(int Id)
        {
            try
            {
                return idal.InforNext(Id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

