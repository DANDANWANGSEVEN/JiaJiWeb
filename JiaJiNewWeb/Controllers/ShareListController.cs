using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace JiaJiNewWeb.Controllers
{
    public class ShareListController : Controller
    {
        // GET: ShareList

        #region 学员分享

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShareListIndex()
        {
            ViewBag.activelist = new JiaJiNewWebBLL.ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist =new JiaJiNewWebBLL.OptionBLL().HotOption();
            return View();
        }
        /// <summary>
        /// 获取分享
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string GetAllShareList(int pageindex)
        {
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectItemBLL().GetAllShareList(pageindex));
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public int GetShareRowCounts()
        {
            try
            {
                return new JiaJiNewWebBLL.ProjectItemBLL().GetShareRowCounts();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

        #region 高分学员
        public ActionResult MaxScoreStuList()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new JiaJiNewWebBLL.ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = new JiaJiNewWebBLL.OptionBLL().HotOption();
            return View();
        }

        /// <summary>
        /// 获取高分学员
        /// </summary>
        /// <param name="areaid">语言ID</param>
        /// <returns></returns>
        public string PageLearnShow(int LanguageId, int pageindex)
        {
            return JsonConvert.SerializeObject( new JiaJiNewWebBLL.LanguageBLL().PageLearnShow(LanguageId, pageindex));
        }
        /// <summary>
        /// 获取高分学员的数量
        /// </summary>
        /// <param name="teamid"></param>
        /// <returns></returns>
        public int GerRowCounts(int id)
        {
            return new JiaJiNewWebBLL.LanguageBLL().GetRowCounts(id);
        }


        /// <summary>
        /// 高分学员内容详细页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MaxScoreStuContent()
        {
            ViewBag.activelist = new JiaJiNewWebBLL.ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = new JiaJiNewWebBLL.OptionBLL().HotOption();
            return View();
        }
        /// <summary>
        /// 高分学员详情
        /// </summary>
        /// <param name="LearnSorceID"></param>
        /// <returns></returns>
        public string MaxScoreStuContentShow(int LearnSorceID)
        {
            try
            {
                Session["learnsorceid"] = LearnSorceID;
                string list = JsonConvert.SerializeObject(new JiaJiNewWebBLL.LanguageBLL().MaxStuContent(LearnSorceID));
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        ///<summary>
        ///上一个高分学员内容详细页面    
        /// </summary>
        public string MaxScoreStuContentPrve()
        {
            int Id = Convert.ToInt32(Session["learnsorceid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.LanguageBLL().MaxStuContentPrev(Id));

        }
        ///<summary>
        ///下一个高分学员内容详细页面 
        /// </summary>
        public string MaxScoreStuContentNext()
        {
            int Id = Convert.ToInt32(Session["learnsorceid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.LanguageBLL().MaxStuContentNext(Id));
        }



        #endregion



    }
}