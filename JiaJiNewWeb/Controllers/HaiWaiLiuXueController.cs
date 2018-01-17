using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using JiaJiNewWebBLL;
using Newtonsoft.Json;

namespace JiaJiNewWeb.Controllers
{
    public class HaiWaiLiuXueController : Controller
    {
        // GET: HaiWaiLiuXue

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 海外留学列表
        /// </summary>
        /// <returns></returns>
        public ActionResult HaiWaiLiuXueList()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new JiaJiNewWebBLL.ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = new JiaJiNewWebBLL.OptionBLL().HotOption();

            return View();
        }


        /// <summary>
        /// 获取策略信息
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string GetStrategyList(int pageindex)
        {
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.StrategyBLL().GetStrategyList(pageindex));
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public int GetStraRowCounts()
        {
           
            try
            {
                return new JiaJiNewWebBLL.StrategyBLL().GetStraRowCounts();
            }
           
            catch(Exception ex)
            {
                return 0;
            }

        }


    }
}