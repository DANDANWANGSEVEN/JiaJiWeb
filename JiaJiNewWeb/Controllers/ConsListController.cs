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
    public class ConsListController : Controller
    {
        TeamBLL tbll = new TeamBLL();
        OptionBLL optionbll = new OptionBLL();
        // GET: ConsList
        public ActionResult ConsList()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        /// <summary>
        /// 获取团队
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        public string GetTeam(int areaid,int pageindex)
         {
            return JsonConvert.SerializeObject(tbll.GetTeam(areaid,pageindex));
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        public int GetRowCounts(int areaid)
        {
            return tbll.GetRowCounts(areaid);
        }
        /// <summary>
        /// 根据团队ID获取其案例
        /// </summary>
        /// <param name="teamid">团队ID</param>
        /// <returns></returns>
        public string GetAnLiByTeam(int teamid)
        {
            return JsonConvert.SerializeObject(tbll.GetAnliByTeam(teamid));
        }
        /// <summary>
        /// 获取地区
        /// </summary>
        /// <returns></returns>
        public string GetArea()
        {
            return JsonConvert.SerializeObject(tbll.GetArea());
        }
    }
}