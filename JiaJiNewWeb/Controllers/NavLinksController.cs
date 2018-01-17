using JiaJiNewWebBLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaJiNewWeb.Controllers
{
    public class NavLinksController : Controller
    {
        // GET: NavLinks
        public ActionResult NavLinks()
        {
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex(); //加载活动
            ViewBag.optionlist = new OptionBLL().HotOption();   //加载观点
            return View();
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string NavInfoShow(int Id)
        {
            try
            {
                Session["Nid"] = Id;
                string list = JsonConvert.SerializeObject(new JiaJiNewWebBLL.NavInfoBLL().GetModelById(Id));
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        ///<summary>
        ///上一个导航链接    
        /// </summary>
        public string NavInfoPrve()
        {
            int Id = Convert.ToInt32(Session["Nid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.NavInfoBLL().GetModelByIdPrev(Id));

        }
        ///<summary>
        ///下一个导航链接 
        /// </summary>
        public string NavInfoNext()
        {
            int Id = Convert.ToInt32(Session["Nid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.NavInfoBLL().GetModelByIdNext(Id));
        }



    }
}