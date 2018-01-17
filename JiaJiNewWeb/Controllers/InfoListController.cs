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
    public class InfoListController : Controller
    {
        InformationBLL ibll = new InformationBLL();
        OptionBLL optionbll = new OptionBLL();
        // GET: InfoList
        public ActionResult InfoList()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        /// <summary>
        /// 获取资讯信息
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string GetInformationList(int pageindex)
        {
            return JsonConvert.SerializeObject(ibll.GetInformationList(pageindex));
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts()
        {
            try
            {
                return ibll.GetRowCounts();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



    }
}