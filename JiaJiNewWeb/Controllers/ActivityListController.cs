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
    public class ActivityListController : Controller
    {
        ActiveBLL abll = new ActiveBLL();
        OptionBLL optionbll = new OptionBLL();
        // GET: ActivityList
        public ActionResult ActivityList()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        /// <summary>
        /// 获取活动
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string GetActiveList(int pageindex)
        {
            return JsonConvert.SerializeObject(abll.ActiveList(pageindex));
        }
        public int GetRowCounts()
        {
            return abll.GetRowCounts();
        }
    }
}