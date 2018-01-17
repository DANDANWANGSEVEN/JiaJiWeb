using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace JiaJiNewWeb.Controllers
{
    public class ConsContentController : Controller
    {
        JiaJiNewWebBLL.TeamBLL bll = new JiaJiNewWebBLL.TeamBLL();
        // GET: ConsContent
        public ActionResult ConsContent(int Id)
        {
            Session["Id"] = Id;
            return View();
        }

        public ActionResult TeamXiangQing()
        {
            //List<JiaJiNewWebModel.Team> teamxiangqing = bll.SuccessCountList(pageindex,id);
            ViewBag.activelist = new JiaJiNewWebBLL.ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = new JiaJiNewWebBLL.OptionBLL().HotOption();
            return View();
        }

        public string TeamShow()
        {
            int Id = Convert.ToInt32(Session["Id"]);
            return JsonConvert.SerializeObject(bll.TeamShow(Id));
        }
        public string ContentShow()
        {
            int Id = Convert.ToInt32(Session["Id"]);
            return JsonConvert.SerializeObject(bll.ContentShow(Id));
        }

        public string SuccessCount()
        {
            int Id = Convert.ToInt32(Session["Id"]);
            int successcount =Convert.ToInt32(bll.SuccessCount(Id));
            return JsonConvert.SerializeObject(successcount);
        }
        public string GetSuccessCount(int pageindex,int teamid)
        {
            return JsonConvert.SerializeObject(bll.SuccessCountList(pageindex,teamid));
        }
        public int GerRowCounts(int teamid)
        {
            return bll.GetSuccessCount(teamid);
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <returns></returns>
        public string ImageShow()
        {
            return "";
        }


    }
}