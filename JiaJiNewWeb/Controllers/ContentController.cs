using System;
using System.Web.Mvc;
using JiaJiNewWebBLL;
using Newtonsoft.Json;
using JiaJiNewWeb.Common;

namespace JiaJiNewWeb.Controllers
{
    public class ContentController : Controller
    {
        InformationBLL bll = new InformationBLL();
        ActiveBLL Activebll = new ActiveBLL();
        SuccessFulBLL Successbll = new SuccessFulBLL();
        StudentProgramBLL Studentbll = new StudentProgramBLL();
        StrategyBLL strategybll = new StrategyBLL();
        OptionBLL optionbll = new OptionBLL();
        ProjectBLL probll = new ProjectBLL();
        // GET: Content

        #region 资讯

        /// <summary>
        /// 资讯详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Content()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        public string ContentShow(int Id)
        {
            try
            {
                Session["Cid"] = Id;
                string list = JsonConvert.SerializeObject(bll.InformationShow(Id));
                Log4netHelper.WriteLog("日至报告");
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                return null;
            }

        }


        ///<summary>
        ///上一个留学资讯     
        /// </summary>
        public string inforPrve()
        {
            int Id = Convert.ToInt32(Session["Cid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.InformationBLL().inforPrev(Id));

        }
        ///<summary>
        ///下一个留学资讯
        /// </summary>
        public string inforNext()
        {
            int Id = Convert.ToInt32(Session["Cid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.InformationBLL().inforNext(Id));
        }
        #endregion

        #region 活动
        /// <summary>
        /// 活动详情
        ///<para>Id:活动ID</para>
        /// </summary>
        /// <returns></returns>
        public ActionResult Active()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        public string ActiveShow(int Id)
        {
            try
            {
                Session["Aid"] = Id;
                //int Id = Convert.ToInt32(Session[""]);
                string list = JsonConvert.SerializeObject(Activebll.ActiveShow(Id));
                Log4netHelper.WriteLog("日志报告");
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                return null;
            }


        }

        ///<summary>
        ///上一个活动    
        /// </summary>
        public string activePrve()
        {
            int Id = Convert.ToInt32(Session["Aid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ActiveBLL().activePrev(Id));

        }
        ///<summary>
        ///下一个活动 
        /// </summary>
        public string activeNext()
        {
            int Id = Convert.ToInt32(Session["Aid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ActiveBLL().activeNext(Id));
        }
        #endregion

        #region 成功案例
        ///<summary>
        ///成功案列详情
        ///<para>Id:案列ID</para>
        /// </summary>
        public ActionResult Success()
        {

            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        public string SuccessShow(int id)
        {
            Session["Sid"] = id;
            return JsonConvert.SerializeObject(Successbll.SuccessfulShow(id));
        }
        ///<summary>
        ///上一个成功案列      
        /// </summary>
        public string SuccessPrve()
        {
            int Id = Convert.ToInt32(Session["Sid"]);
            return JsonConvert.SerializeObject(Successbll.SuccessPrev(Id));
        }
        ///<summary>
        ///下一个成功案列
        /// </summary>
        public string SuccessNext()
        {
            int Id = Convert.ToInt32(Session["Sid"]);
            return JsonConvert.SerializeObject(Successbll.SuccessNext(Id));
        }
        #endregion

        #region 成功案例内容页
        public ActionResult SuccessContent()
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
        public string GetTeamSuccessContent(int Id)
        {
            return JsonConvert.SerializeObject(new JiaJiNewWebDAL.TeamDAL().TeamSuccessContent(Id));
        }






        #endregion




        #region 规划
        ///<summary>
        ///规划详情
        ///<para>Id:规划ID</para>
        /// </summary>
        public ActionResult StudentProgram()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        public string StudentShow(int Id)
        {
            //int Id = Convert.ToInt32(Session["Mid"]);
            Session["Mid"] = Id;
            string StrJson=JsonConvert.SerializeObject(Studentbll.StudentShow(Id));
            return StrJson;
        }
        /// <summary>
        /// 国家留学规划列表
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentProgramList()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        /// <summary>
        /// 获取国家留学规划列表
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string GetStudentProgramList(int pageindex)
        {
            return JsonConvert.SerializeObject(Studentbll.StudentProgramList(pageindex));
        }
        public int GetStuProRowCounts()
        {
            return Studentbll.GetRowCounts();
        }




        ///<summary>
        ///上一个规划
        /// </summary>
        public string StudentPrve()
        {
            int Id = Convert.ToInt32(Session["Mid"]);
            return JsonConvert.SerializeObject(Studentbll.StudentPrev(Id));
        }
        ///<summary>
        ///下一个规划
        /// </summary>
        public string StudentNext()
        {
            int Id = Convert.ToInt32(Session["Mid"]);
            return JsonConvert.SerializeObject(Studentbll.StudentNext(Id));
        }
        #endregion

        #region 攻略
        /// <summary>
        /// 攻略详情
        /// </summary>
        /// <returns></returns>
        public ActionResult StrategyShow()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        [HttpPost]
        public string Strategy(int Id)
        {
            Session["Gid"] = Id;
            //int Id = Convert.ToInt32(Session["Gid"]);
            return JsonConvert.SerializeObject(strategybll.StrategyShow(Id));
        }
        ///<summary>
        ///上一个攻略
        /// </summary>
        public string StrategyPrve()
        {
            int Id = Convert.ToInt32(Session["Gid"]);
            return JsonConvert.SerializeObject(strategybll.StrategyPrev(Id));
        }
        ///<summary>
        ///下一个攻略
        /// </summary>
        public string StrategyNext()
        {
            int Id = Convert.ToInt32(Session["Gid"]);
            return JsonConvert.SerializeObject(strategybll.StrategyNext(Id));
        }
        #endregion

        #region 观点
        /// <summary>
        /// 观点详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult OptionShow()
        {
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        public string Option(int Id)
        {
            Session["Oid"] = Id;
            //int Id = Convert.ToInt32(Session["Oid"]);
            return JsonConvert.SerializeObject(optionbll.OptionShow(Id));
        }
        ///<summary>
        ///上一个观点
        /// </summary>
        public string OptionPrve()
        {
            int Id = Convert.ToInt32(Session["Oid"]);
            return JsonConvert.SerializeObject(optionbll.OptionPrev(Id));
        }
        ///<summary>
        ///下一个观点
        /// </summary>
        public string OptionNext()
        {
            int Id = Convert.ToInt32(Session["Oid"]);
            return JsonConvert.SerializeObject(optionbll.OptionNext(Id));
        }
        public ActionResult GetOptionList()
        {
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        /// <summary>
        /// 获取全部观点
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string OptionList(int pageindex)
        {
            return JsonConvert.SerializeObject(optionbll.OptionList(pageindex));
        }
        public int GetRowCounts()
        {
            return new JiaJiNewWebBLL.OptionBLL().GetRowCounts();
        }
        #endregion

        #region 分享

        /// <summary>
        /// 分享详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ShareShow()
        {
           
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        [HttpPost]
        public string Share(int Id)
        {
            Session["sid"] = Id;
            //int Id = Convert.ToInt32(Session["sid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectItemBLL().GetShareContent(Id));
        }
        ///<summary>
        ///上一个分享
        /// </summary>
        public string SharePrve()
        {
            int Id = Convert.ToInt32(Session["sid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectItemBLL().SharePrev(Id));
        }
        ///<summary>
        ///下一个分享
        /// </summary>
        public string ShareNext()
        {
            int Id = Convert.ToInt32(Session["sid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectItemBLL().ShareNext(Id));
        }

        #endregion

        #region 移民项目
        ///<summary>
        ///项目详情
        /// <param name="Id"></param>
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectShow()
        {
            
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        public string Project(int Id)
        {
            Session["Pid"] = Id;
            //int Id = Convert.ToInt32(Session["Pid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectBLL().ImmigrantShow(Id));
        }
        /// <summary>
        /// 移民列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ImmigrantList()
        {
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        /// <summary>
        /// 获取移民列表
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string GetImmigrantList(int pageindex)
        {
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectBLL().ImmigrantList(pageindex));
        }
        public int GetImmigrantRowCounts()
        {
            return new JiaJiNewWebBLL.ProjectBLL().GetImmigrantRowCounts();
        }

        ///<summary>
        ///上一个移民
        /// </summary>
        public string ImmigrantPrev()
        {
            int Id = Convert.ToInt32(Session["Pid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectBLL().ImmigrantPrev(Id));
        }
        ///<summary>
        ///下一个移民
        /// </summary>
        public string ImmigrantNext()
        {
            int Id = Convert.ToInt32(Session["Pid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectBLL().ImmigrantNext(Id));
        }

        #endregion

        #region 背景提升项目
        ///<summary>
        ///背景提升项目详情
        /// <param name="Id"></param>
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectItemShow()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        public string ProjectItem(int Id)
        {
            Session["proid"] = Id;
            //int Id = Convert.ToInt32(Session["Pid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectBLL().ProjectItemShow(Id));
        }
        /// <summary>
        /// 背景提升项目列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetProjectItemList()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();//加载活动
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        ///<summary>
        ///上一个背景提升项目
        /// </summary>
        public string ProjectItemPrev()
        {
            int Id = Convert.ToInt32(Session["proid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectBLL().ProjectItemPrev(Id));
        }
        ///<summary>
        ///下一个背景提升项目
        /// </summary>
        public string ProjectItemNext()
        {
            int Id = Convert.ToInt32(Session["proid"]);
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectBLL().ProjectItemNext(Id));
        }

        /// <summary>
        /// 获取背景提升项目列表
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public string ProjectItemList(int pageindex)
        {
            return JsonConvert.SerializeObject(new JiaJiNewWebBLL.ProjectBLL().ProjectItemList(pageindex));
        }
        public int GetProjectItemRowCounts()
        {
            return new JiaJiNewWebBLL.ProjectBLL().GetProjectItemRowCounts();
        }

        #endregion

        #region 课程详情
        public ActionResult CourseContent()
        {
            ViewBag.OptionImage = new JiaJiNewWebBLL.OptionBLL().HotOptionImage();
            ViewBag.activelist = new ActiveBLL().ActiveLsitIndex();
            ViewBag.optionlist = optionbll.HotOption();
            return View();
        }
        [HttpPost]
        public JsonResult CourseContentShow(int Id)
        {
            try
            {
                Session["Courseid"] = Id;
                //string list = JsonConvert.SerializeObject();
                Log4netHelper.WriteLog("日志报告");
                return Json(new LanguageBLL().CourseDetail(Id));
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                return null;
            }
        }

        ///<summary>
        ///上一个课程
        /// </summary>
        [HttpPost]
        public string CoursePrve()
        {
            int Id = Convert.ToInt32(Session["Courseid"]);
            return JsonConvert.SerializeObject(new LanguageBLL().CoursePrev(Id));
        }
        ///<summary>
        ///下一个课程
        /// </summary>
        [HttpPost]
        public string CourseNext()
        {
            int Id = Convert.ToInt32(Session["Courseid"]);
            return JsonConvert.SerializeObject(new LanguageBLL().CourseNext(Id));
        }


        #endregion


    }
}
