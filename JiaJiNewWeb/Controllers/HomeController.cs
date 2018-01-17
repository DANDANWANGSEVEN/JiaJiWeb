using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiNewWebModel;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace JiaJiNewWeb.Controllers
{
    public class HomeController : Controller
    {
        JiaJiNewWebBLL.ActiveBLL activebll = new JiaJiNewWebBLL.ActiveBLL();
        JiaJiNewWebBLL.InformationBLL infobll = new JiaJiNewWebBLL.InformationBLL();
        JiaJiNewWebBLL.ApplyBLL apbll = new JiaJiNewWebBLL.ApplyBLL();
        JiaJiNewWebBLL.MediumBLL mebll = new JiaJiNewWebBLL.MediumBLL();
        JiaJiNewWebBLL.ProjectBLL projectbll = new JiaJiNewWebBLL.ProjectBLL();
        public ActionResult Index()
        {

            List<IndexImage> indeximagelist = new JiaJiNewWebBLL.ImageBLL().IndexImageLsit();  //获取日期倒序显示前三条
            ViewData["indeximagelist"] = indeximagelist;


            //List<JiaJiNewWebModel.Active> activelist= new JiaJiNewWebBLL.ActiveBLL.ActiveLsit(国家最新活动数据显示点击热度最高的前五条
            //List<JiaJiNewWebModel.TeamIndexModel> termList = new JiaJiNewWebBLL.TeamBLL().TeamindexList(); //精英团队信息

           List<JiaJiNewWebModel.CountryDominant> HaiWaiIndexList = new JiaJiNewWebBLL.ApplyBLL().HaiWaiLiuXueIndexList();  //首页加载先显示美国的信息
            List<Information> infolist = infobll.GetInformationTopList();//留学资讯
            List<JiaJiNewWebModel.Active> activelist = activebll.ActiveLsitIndex(); //根据
            ViewBag.infolist = infolist;
            ViewBag.activelist = activelist;
            //ViewBag.teamList = termList;
            ViewBag.solutionList = new JiaJiNewWebBLL.SolutionBLL().SolutionIndexList();//获取解决方案的信息
            ViewBag.SolutionBuZhou = new JiaJiNewWebBLL.SolutionBLL().SolutionBuZhouList(); //获取解决方案步骤
            //ViewBag.LaugList = new JiaJiNewWebBLL.LanguageBLL().GetPeixunList();  //语言培训的内容显示位于页底
            //ViewBag.indexliuxue = new JiaJiNewWebBLL.LunBoImageBLL().IndexLXueList();  //首页留学
            //ViewBag.medium = mebll.GetMedium();     //媒体
            ViewBag.projectitem = projectbll.ProjectShow();

            ViewBag.indexzixun = new JiaJiNewWebBLL.LunBoImageBLL().IndexInforImage();  //首页资讯图片
            

            return View();
        }
        /// <summary>
        /// 精英团队
        /// </summary>
        /// <returns></returns>
        public static List<JiaJiNewWebModel.TeamIndexModel> TeamShow()
        {
            JiaJiNewWebBLL.TeamBLL teambll = new JiaJiNewWebBLL.TeamBLL();

            return teambll.TeamindexList();
        }


        /// <summary>
        /// 海外留学
        /// </summary>
        /// <param name="countryid"></param>
        /// <returns></returns>
        public string HaiWaiLiuXue(int countryid)
        {

            List<JiaJiNewWebModel.CountryDominant> HaiWaiList = new JiaJiNewWebBLL.ApplyBLL().HaiWaiList(countryid);
            JsonConvert.SerializeObject(HaiWaiList);
            return JsonConvert.SerializeObject(HaiWaiList);
        }


        /// <summary>
        /// 获取学生的信息列表
        /// </summary>
        /// <param name="index"></param>
        /// <param name="goIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public string StudentList(int index, int goIndex)
        {
            try
            {
                List<JiaJiNewWebModel.StudentIndexModel> studentList = new JiaJiNewWebBLL.StudentBLL().StudentIndexList(index, goIndex);//获取学生的信息
                return JsonConvert.SerializeObject(studentList);
            }

            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 获取学生信息的数量
        /// </summary>
        /// <returns></returns>
        public int Counts()
        {
            return new JiaJiNewWebBLL.StudentBLL().CountStudentInfo();
        }
        /// <summary>
        /// 获取所有的国家信息
        /// </summary>
        /// <returns>返回国家的JSON字符串</returns>

        public string CountryList()
        {
            List<JiaJiNewWebModel.Country> countrylist = new JiaJiNewWebBLL.CountryBLL().CountryList();
            return JsonConvert.SerializeObject(countrylist);
        }
        /// <summary>
        /// 返回申请攻略的信息
        /// </summary>
        /// <param name="id">国家ID</param>
        /// <returns></returns>
        [HttpGet]
        public string StrategInfoJson(int id)
        {
            string innerjson = JsonConvert.SerializeObject(new JiaJiNewWebBLL.StrategyBLL().StrategeIndexList(id));
            return innerjson;

        }

        /// <summary>
        /// 添加申请
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddApply(Apply a)
        {
            bool bo = apbll.Addapply(a);
            if (bo)
            {
                return Content("<script>alert('申请成功！');location.href='/Home/Index';</script>");
            }
            else
            {
                return Content("<script>alert('申请失败！');location.href='/Home/Index';</script>");
            }
        }

        /// <summary>
        /// 语言培训
        /// </summary>
        /// <returns></returns>
        public static List<JiaJiNewWebModel.Language_PeiXunModel> LanguagePeiXun()
        {
            JiaJiNewWebBLL.LanguageBLL languagepeixun = new JiaJiNewWebBLL.LanguageBLL();

            return languagepeixun.GetPeixunList();
        }

        /// <summary>
        /// 媒体合作
        /// </summary>
        /// <returns></returns>

        public static List<JiaJiNewWebModel.Medium> Mediu()
        {
            JiaJiNewWebBLL.MediumBLL mediu = new JiaJiNewWebBLL.MediumBLL();

            return mediu.GetMedium();
        }

        ///<summary>
        ///获取背景提升项目
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public static List<JiaJiNewWebModel.projectItem> projectshow()
        {
            JiaJiNewWebBLL.ProjectBLL pbll = new JiaJiNewWebBLL.ProjectBLL();
            
            return pbll.ProjectShow();
         }

        ///<summary>
        ///获取移民项目
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        //public string ImmigrantShow()
        //{
        //    return JsonConvert.SerializeObject(projectbll.ImmigrantShow());
        //}
        public static List<JiaJiNewWebModel.Project> ImmigrantShow()
        {
            JiaJiNewWebBLL.ProjectBLL pbll = new JiaJiNewWebBLL.ProjectBLL();

            return pbll.ImmigrantShow();
        }

        /// <summary>
        /// 二维码
        /// </summary>
        /// <returns></returns>
        public string ErWeiMa()
        {
            List<JiaJiNewWebModel.erweima> erweimalist = new JiaJiNewWebBLL.LunBoImageBLL().ErWeiMaList();

            string erweima = "";

            foreach (var item in erweimalist as List<JiaJiNewWebModel.erweima>)
            {
                erweima += " <div style = \"width:135px;height:175px;float:left;margin-left:5px;\" >";

                erweima += "<p style = \"display:block;width:135px;height:40px;font-size:20px;color:#FFFFFF;margin:0px;text-align:center;line-height:40px;\" > " + item.EWMTitle + " </p>";

                erweima += "<p style = \"background:url('" + item.EWMUrl + "') center no-repeat;width:135px;height:125px;margin:0px;\" ></p>";

                erweima += "  </div>";
            }

            return new HtmlString(erweima).ToHtmlString();

        }

        //public IQueryable<JiaJiNewWebModel.erweima> QueryShowErWeiMa()
        //{
        //    return QueryEntities(m => m.IsShowCaiDan == 1).OrderBy(s => s.ShowCaiDanIndex);
        //}

        public ActionResult SouSuo(string selName, int pageIndex = 1, int pageSize = 10)
        {
            JiaJiNewWebModel.Home.selectmodel model = new JiaJiNewWebModel.Home.selectmodel();

            model.Activetable.ActiveTitle = selName;
            model.Activetable.Datails = selName;
            model.Infortable.Title = selName;
            model.Infortable.content = selName;
            model.Strategytable.StrategyTitle = selName;
            model.Strategytable.StrategyContent = selName;
            model.Navtable.NavTitleOne = selName;
            model.Navtable.NavTitleTwo = selName;
            model.Navtable.NavContentOne = selName;

            List<JiaJiNewWebModel.Home.SearchDetails> infolist = new JiaJiNewWebBLL.InformationBLL().Select(model);
            var count = infolist.Count;
            var pageTotal = (int)Math.Ceiling((double)(count) / pageSize);
            if (pageIndex < 1) pageIndex = 1;
            if (pageIndex >= pageTotal) pageIndex = pageTotal;

            infolist = infolist.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new JiaJiNewWebBLL.ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = new JiaJiNewWebBLL.OptionBLL().HotOption();
            ViewBag.selName = selName;

            if (infolist.Count == 0)
            {
                return Content("<script>alert('暂无该搜索结果');location.href='/Home/Index';</script>");
            }
            else
            {
                Models.Pager<JiaJiNewWebModel.Home.SearchDetails> pager = new Models.Pager<JiaJiNewWebModel.Home.SearchDetails>();
                pager.PageIndex = pageIndex;
                pager.PageSize = pageSize;
                pager.PageTotal = pageTotal;
                pager.Model = infolist;
                return View(pager);
            }
        }

        /// <summary>
        /// 获取搜索结果的行数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts(string selName)
        {
            return new JiaJiNewWebBLL.InformationBLL().SelectRowCounts(selName);
        }


    }
}