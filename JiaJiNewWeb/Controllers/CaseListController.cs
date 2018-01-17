using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiNewWebModel;
using JiaJiNewWebBLL;
using Newtonsoft.Json;
namespace JiaJiNewWeb.Controllers
{
    public class CaseListController : Controller
    {
        SuccessFulRelationBLL sbll = new SuccessFulRelationBLL();
        // GET: CaseList
        public ActionResult CaseList()
        {
            ViewBag.indexzixun = new JiaJiNewWebBLL.LunBoImageBLL().IndexInforImage();  //首页资讯图片
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist =new JiaJiNewWebBLL.OptionBLL().HotOption();
            return View();
        }
        /// <summary>
        /// 根据条件获取案例
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        public string GetAnLi(int countryid,int educationid,int pageindex)
        {
            return JsonConvert.SerializeObject(sbll.GetAnLi(countryid, educationid, pageindex));
        }
        /// <summary>
        /// 获取国家
        /// </summary>
        /// <returns></returns>
        public string GetCountry()
        {
            return JsonConvert.SerializeObject(sbll.GetCountry());
        }
        /// <summary>
        /// 获取学历
        /// </summary>
        /// <returns></returns>
        public string GetEducationType()
        {
            return JsonConvert.SerializeObject(sbll.GetEducationType());
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <returns></returns>
        public int GerRowCounts(int countryid, int educationid)
        {
            return sbll.GetRowCounts(countryid, educationid);
        }
    }
}