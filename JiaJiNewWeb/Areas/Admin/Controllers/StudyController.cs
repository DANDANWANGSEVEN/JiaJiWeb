using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiBLL;
using Newtonsoft.Json;
using System.IO;
using JiaJiModels;
namespace JiaJiNewWeb.Areas.Admin.Controllers
{
    public class StudyController : Controller
    {
       
        teambll tbll = new teambll();
        statrgybll sbll = new statrgybll();
        CollageBLL cbll = new CollageBLL();
        stubll stbll = new stubll();
        LanguageBLL lbll = new LanguageBLL();
        ProjectBLL pbll = new ProjectBLL();
        Anlibll anbll = new Anlibll();
        adloginBll loginBll = new adloginBll();
        // GET: Study   

        #region 列表首页
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 母版页
        public ActionResult Layout()
        {
            return View();
        }
        #endregion

        #region 登陆界面

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult login()
        {
            return View();
        }

        public void validatecode()
        {
            ImageValidate sc = new ImageValidate();
            string SecurityCode = sc.GetSecurityCode(6);
            Session["ValidateCode"] = SecurityCode.ToLower();
        }
        [HttpPost]
        public ActionResult login(string uname, string pwd, string validateCode)
        {

            if (loginBll.AdNameIsExist(uname) != 1)
                return Content("<script>alert('用户名不存在');location.reload();</script>");
            if (loginBll.NamePwdIsExist(uname, pwd) != 1)
                return Content("<script>alert('用户名或密码错误');location.href='/admin/study/login'</script>");

            var cookie = new HttpCookie("Login", "abc");
            cookie.Path = "/";
            //cookie.Domain = "1.119.55.155";
            cookie.Expires = DateTime.Now.AddMinutes(30);
            //cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Set(cookie);
                return Content("<script>location.href='/admin/Study/index'</script>");
        }

        [HttpPost]
        public int validatecode(string code)
        {
            if (Session["ValidateCode"].ToString() == code.ToLower())
            {
                return 0;
            }
            return 1;
        }

        #endregion

        #region 主显示页面
        /// <summary>
        /// 主显示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult main()
        {
            return View();
        }
        #endregion

        #region 热门资讯页面
        /// <summary>
        /// 热门资讯页面
        /// </summary>
        /// <returns></returns>
        public ActionResult information()
        {
            return View();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getinformation(int page, int rows, string Title="", int? CountryID=null, int? Site=null)
        {
            
            var list = new JiaJiBLL.infobll().INshow(Title);
            //var result = new { total = list.Count, rows = list.Skip((page - 1) * rows).Take(rows)};
            var result = new {
                total = list.
                Where(e => e.Title.Contains(Title)
                && (CountryID == null ? true : e.CountryID == CountryID)
                && (Site == null ? true : e.Site == Site)
                ).Count(),
                rows = list.
                Where(e=>e.Title.Contains(Title)
                &&(CountryID==null?true:e.CountryID==CountryID)
                && (Site == null ? true : e.Site == Site)
                ).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        } 
        
        /// <summary>
        /// 删除资讯
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteinformation(string ids)
        {
            bool isOK = new JiaJiBLL.infobll().infoDel(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addinformation(JiaJiModels.Information infor)
        {
            try
            {
                infor.InformationImgUrl = "/image/" + infor.InformationImgUrl;
                var i = new JiaJiBLL.infobll().infoadd(infor);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editinformation(JiaJiModels.Information model)
        {
            try
            {
                int id = model.InformationID; 

                var i = new JiaJiBLL.infobll().UpdateInformation(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }


        #endregion

        #region 最新活动页面
        /// <summary>
        /// 最新活动页面
        /// </summary>
        /// <returns></returns>
        public ActionResult LatestActivity()
        {
            return View();
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getLatestActivity(int page, int rows, string ActiveTitle="",int? CountryID = null, int? Site = null)
        {
            var list = new JiaJiBLL.activebll().Activeshow();

            var result = new {
                total = list.
                Where(e => e.ActiveTitle.Contains(ActiveTitle)
                && (CountryID == null ? true : e.CountryID == CountryID)
                && (Site == null ? true : e.Site == Site)
                ).Count(),
                rows = list.
                Where(e => e.ActiveTitle.Contains(ActiveTitle) 
                && (CountryID == null ? true : e.CountryID == CountryID)
                && (Site == null ? true : e.Site == Site)
                ).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addLatestActivity(JiaJiModels.Active model)
        {
            try
            {
                var i = new JiaJiBLL.activebll().Actionadd(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteLatestActivity(string ids)
        {
            bool isOK = new JiaJiBLL.activebll().actionDel(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editLatestActivity(JiaJiModels.Active model)
        {
            try
            {
                int ActiveID = model.ActiveID;

                var i = new JiaJiBLL.activebll().ActiveUpd(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }



        #endregion

        #region 攻略
        /// <summary>
        /// 攻略界面
        /// </summary>
        public ActionResult strategy()
        {
            return View();
        }
        public JsonResult getstrategy(int page, int rows,string StrategyTitle="", int? CountryID = null)
        {
            var list = new JiaJiBLL.statrgybll().ShowStrategy();

            var result = new
            {
                total = list.
               Where(e => e.StrategyTitle.Contains(StrategyTitle)
               && (CountryID == null ? true : e.CountryID == CountryID)
               
               ).Count(),
                rows = list.
               Where(e => e.StrategyTitle.Contains(StrategyTitle)
               && (CountryID == null ? true : e.CountryID == CountryID)
              
               ).Skip((page - 1) * rows).Take(rows)
            };

            return Json(result);
        }
        /// <summary>
        /// 删除攻略
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deletestrategy(string ids)
        {
            bool isOK = new JiaJiBLL.statrgybll().DelStrategy(ids);
            if (isOK) return 0;
            return 1;

        }

    
        /// <summary>  
        /// 添加攻略
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addstrategy(JiaJiModels.strategy model)
        {
            try
            {
                model.Img = "/image/" + model.Img;

                var i = new JiaJiBLL.statrgybll().addstat(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editstrategy(JiaJiModels.strategy model)
        {
            try
            {
                int id = model.StrategyID;

                var i = new JiaJiBLL.statrgybll().Updatestrategy(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }



        #endregion

        #region 解决方案

        /// <summary>
        /// 解决方案页面
        /// </summary>
        /// <returns></returns>
        public ActionResult solution()
        {
            return View();
        }
        public JsonResult getsolution(int page, int rows,string SolutionTitle="")
        {
            var list = new JiaJiBLL.Solutionbll().ShowSolution();
            var result = new { total = list.Count, rows = list.Where(e=>e.SolutionTitle.Contains(SolutionTitle)).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 解决方案添加
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addsolution(JiaJiModels.solution model)
        {
            try
            {
                var i = new JiaJiBLL.Solutionbll().soladd(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }
        /// <summary>
        /// 删除解决方案
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deletesolution(string ids)
        {
            bool isOK = new JiaJiBLL.Solutionbll().DelSolution(ids);
            if (isOK) return 0;
            else return 1;

        }
        /// <summary>
        /// 修改解决方案
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editsolution(JiaJiModels.solution model)
        {
            try
            {
                int id = model.SolutionID;

                var i = new JiaJiBLL.Solutionbll().UpdSolu(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }



        #endregion

        #region 媒体合作管理
      
        /// <summary>
        /// 媒体合作界面
        /// </summary>
        /// <returns></returns>
        public ActionResult medium()
        {
            return View();
        }

        public JsonResult getMedium(int page, int rows,string MediumTitle="")
        {
            var list = new JiaJiBLL.mediumbll().ShowMedium();
            var result = new { total = list.Count, rows = list.Where(e => e.MediumTitle.Contains(MediumTitle)).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 媒体添加
        /// </summary>
        /// <param name="ming"></param>
        /// <param name="title"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addmedium(JiaJiModels.medium model)
        {
            try
            {
                model.MediumImg = "/image/" + model.MediumImg;
                var i = new JiaJiBLL.mediumbll().mediumadd(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }
        /// <summary>
        /// 删除媒体
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteMedium(string ids)
        {
            bool isOK = new JiaJiBLL.mediumbll().DelMedium(ids);
            if (isOK) return 0;
            else return 1;

        }
        /// <summary>
        /// 修改媒体
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editMedium(JiaJiModels.medium model)
        {
            try
            {
                int id = model.MediumID;

                var i = new JiaJiBLL.mediumbll().UpdMedium(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }

        #endregion

        #region 留学规划文章
        /// <summary>
        /// 留学规划
        /// </summary>
        /// <returns></returns>
        public ActionResult Sprelation()
        {
            return View();
        }
        public JsonResult getSprelation(int page, int rows,string StudentProgramTitle="", int? CountryID = null, int? EducationID = null, int? TypeID = null)
        {
            var list = new JiaJiBLL.SprelationBll().ShowLiuXueGuiHua();

            var result = new
            {
                total = list.
             Where(e => e.StudentProgramTitle.Contains(StudentProgramTitle)
             && (CountryID == null ? true : e.CountryID == CountryID)
             && (EducationID == null ? true : e.EducationID == EducationID)
             && (TypeID == null ? true : e.TypeID == TypeID)
             ).Count(),
                rows = list.
             Where(e => e.StudentProgramTitle.Contains(StudentProgramTitle)
             && (CountryID == null ? true : e.CountryID == CountryID)
             && (EducationID == null ? true : e.EducationID == EducationID)
             && (TypeID == null ? true : e.TypeID == TypeID)
             ).Skip((page - 1) * rows).Take(rows)
            };

            return Json(result);


        }
        /// <summary>
        /// 删除留学规划
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteSprelation(string ids)
        {
            bool isOK = new JiaJiBLL.SprelationBll().DelLiuXueGuiHua(ids);
            if (isOK)
                return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addSprelation(JiaJiModels.StudentProgram model)
        {
            try
            {
                model.ImageUrl = "/image/"+ model.ImageUrl;
                var i = new JiaJiBLL.SprelationBll().StudentprogramAdd(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editSprelation(JiaJiModels.StudentProgram model)
        {
            try
            {
                int id = model.StudentProgramID;

                var i = new JiaJiBLL.SprelationBll().UpdStudentprogram(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }

        #endregion

        #region 国家

        public ActionResult CountryInfo()
        {
            return View();
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getCountryInfo(int page, int rows)
        {

            var list = new JiaJiBLL.SprelationBll().Countryshow();
            var result = new { total = list.Count, rows = list.OrderBy(e => e.CountryID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteCountryInfo(string ids)
        {
            bool isOK = new JiaJiBLL.SprelationBll().DelCountry(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addCountryInfo(JiaJiModels.country model)
        {
            try
            {
                model.CountryImg = "/image/"+ model.CountryImg;
                model.CountryImg2 = "/image/" + model.CountryImg2;
                model.CountryActiveImg1 = "/image/" + model.CountryActiveImg1;
                model.CountryActiveImg2 = "/image/" + model.CountryActiveImg2;
              

                var i = new JiaJiBLL.SprelationBll().AddCountry(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改国家信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editCountryInfo(JiaJiModels.country model)
        {
            try
            {
               
                int id = model.CountryID;

                var i = new JiaJiBLL.SprelationBll().UpdCountry(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }



        /// <summary>
        /// 显示国家
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Countryshow()
        {
            return Json(new JiaJiBLL.SprelationBll().Countryshow(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 语言背景移民国家
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult allshow()
        {
            return Json(new JiaJiBLL.SprelationBll().allshow(), JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region 语言背景移民

        public ActionResult LanBgYi()
        {
            return View();
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getLanBgYi(int page, int rows)
        {

            var list = new JiaJiBLL.SprelationBll().LBYshow();
            var result = new { total = list.Count, rows = list.OrderBy(e => e.CountryID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteLanBgYi(string ids)
        {
            bool isOK = new JiaJiBLL.SprelationBll().DelCountry(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addLanBgYi(JiaJiModels.country model)
        {
            try
            {
                model.CountryImg = "/image/" + model.CountryImg;
                model.CountryImg2 = "/image/" + model.CountryImg2;
                model.CountryActiveImg1 = "/image/" + model.CountryActiveImg1;
                model.CountryActiveImg2 = "/image/" + model.CountryActiveImg2;

                var i = new JiaJiBLL.SprelationBll().AddLBY(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editLanBgYi(JiaJiModels.country model)
        {
            try
            {
              
                int id = model.CountryID;

                var i = new JiaJiBLL.SprelationBll().UpdCountry(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }



        #endregion

        #region 学历
        /// <summary>
        /// 学历
        /// </summary>
        /// <returns></returns>
        ///
        [HttpPost]
        public JsonResult Edushow()
        {
            return Json(new JiaJiBLL.SprelationBll().Edushow(), JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region 语言培训

        /// <summary>
        /// 语言培训
        /// </summary>
        /// <returns></returns>
        public ActionResult LanguagePeiXun()
        {
            return View();
        }
        /// <summary>
        /// 显示语言培训
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getLanguagePeiXun(int page, int rows)
        {

            var list = new JiaJiBLL.LanguageBLL().ShowLanguagePeiXun();
            var result = new { total = list.Count, rows = list.OrderBy(e => e.LanguagePx_ID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 删除语言培训
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteLanguagePeiXun(string ids)
        {
            bool isOK = new JiaJiBLL.LanguageBLL().DelLanguagePeiXun(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加语言培训
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addLanguagePeiXun(JiaJiModels.Language_PeiXun infor)
        {
            try
            {
                var i = new JiaJiBLL.LanguageBLL().addLanguagePeiXun(infor);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改语言培训
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editLanguagePeiXun(JiaJiModels.Language_PeiXun model)
        {
            try
            {
                int id = model.LanguagePx_ID;

                var i = new JiaJiBLL.LanguageBLL().UpdateLanguagePeiXun(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }





        #endregion

        #region 背景提升
        /// <summary>
        /// 背景提升
        /// </summary>
        /// <returns></returns>
        public ActionResult projectitem()
        {
            return View();
        }
        [HttpPost]
        public JsonResult projectitemshow()
        {
            return Json(new JiaJiBLL.projectitembll().ShowProjectitem(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getprojectitem(int page, int rows)
        {
            var list = new JiaJiBLL.projectitembll().ShowProjectitem();
            var result = new { total = list.Count, rows = list.Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteprojectitem(string ids)
        {
            bool isOK = new JiaJiBLL.projectitembll().DelProjectitem(ids);
            if (isOK) return 0;
            else return 1;

        }

        /// <summary>
        /// 背景添加
        /// </summary>
        /// <param name="ming"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addprojectitem(JiaJiModels.projectitem model)
        {
            try
            {
                model.Pro_Img = "/image/"+ model.Pro_Img;
                model.ProactiveImg1 = "/image/" + model.ProactiveImg1;
                model.ProactiveImg2 = "/image/" + model.ProactiveImg2;
                var i = new JiaJiBLL.projectitembll().proadd(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editprojectitem(JiaJiModels.projectitem model)
        {
            try
            {
              
                int id = model.Pro_ID;

                var i = new JiaJiBLL.projectitembll().Updpro(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }




        #endregion

        #region 分公司管理


        public ActionResult Filiale()
        {
            return View();
        }

        /// <summary>
        /// 显示分公司名称
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult FilialeShow()
        {
            return Json(new JiaJiBLL.FilialeBll().FilialeShow(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getFiliale(int page, int rows)
        {
            var list = new JiaJiBLL.FilialeBll().FilialeShow();
            var result = new { total = list.Count, rows = list.OrderBy(e => e.FilialeId).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }
        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addFiliale(JiaJiModels.filialetext infor)
        {
            try
            {
                var i = new JiaJiBLL.FilialeBll().addFiliale(infor);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editFiliale(JiaJiModels.filialetext model)
        {
            try
            {
                int id = model.FilialeId;

                var i = new JiaJiBLL.FilialeBll().UpdateFiliale(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }

        /// <summary>
        /// 删除资讯
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteFiliale(string ids)
        {
            bool isOK = new JiaJiBLL.FilialeBll().DelFiliale(ids);
            if (isOK) return 0;
            else return 1;
        }

        #endregion

        #region 分公司管理介绍

        /// <summary>
        /// 分公司管理介绍页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Filialeadd()
        {
            return View();
        }
        public JsonResult getFilialeadd(int page, int rows,int? FilialeId=null)
        {
            var list = new JiaJiBLL.FilialeBll().ShowFenGongsi();
            var result = new
            {
                total = list.
               Where(e=>
               (FilialeId == null ? true : e.FilialeId == FilialeId)
               
               ).Count(),
                rows = list.
               Where(e =>
               (FilialeId == null ? true : e.FilialeId == FilialeId)
               
               ).Skip((page - 1) * rows).Take(rows)
            };
            
            return Json(result);
        }

        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addFilialeadd(JiaJiModels.filialetext infor)
        {
            try
            {
              
                infor.FilialeImg = "/image/" + infor.FilialeImg;
                var i = new JiaJiBLL.FilialeBll().addFilialeText(infor);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }

        /// <summary>
        /// 修改资讯信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editFilialeadd(JiaJiModels.filialetext model)
        {
            try
            {
                int id = model.FilialeTextId;

                var i = new JiaJiBLL.FilialeBll().UpdateFilialeText(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }

        /// <summary>
        /// 删除资讯
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteFilialeadd(string ids)
        {
            bool isOK = new JiaJiBLL.FilialeBll().DelFilialeText(ids);
            if (isOK) return 0;
            else return 1;
        }


        #endregion

        #region 地区
        /// <summary>
        /// 地区页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AreasesAdd()
        {
            return View();
        }

        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Areashow()
        {
            return Json(new JiaJiBLL.AreaesBll().ShowArea(), JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult getAreasesAdd(int page, int rows)
        {
            var list = new JiaJiBLL.AreaesBll().ShowArea();
            var result = new { total = list.Count, rows = list.Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }


        /// <summary>
        /// 地区添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addAreasesAdd(JiaJiModels.areases model)
        {
            try
            {
                var i = new JiaJiBLL.AreaesBll().AreasesAdd(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "添加成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "添加失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "添加失败" });
            }
        }
        /// <summary>
        /// 删除地区
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteAreasesAdd(string ids)
        {
            bool isOK = new JiaJiBLL.AreaesBll().DelAreas(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>
        /// 修改媒体
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editAreasesAdd(JiaJiModels.areases model)
        {
            try
            {
                int id = model.AreaID;

                var i = new JiaJiBLL.AreaesBll().UpdAreases(model);
                if (i > 0)
                {
                    return Json(new { Success = true, Message = "修改成功" });
                }
                else
                {
                    return Json(new { Success = false, Message = "修改失败" });
                }
            }
            catch
            {
                return Json(new { Success = false, Message = "修改失败" });
            }
        }

        #endregion

        #region 提交信息列表
        /// <summary>
        /// 热门资讯页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Apply()
        {
            return View();
        }
        /// <summary>
        /// 显示提交信息列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getApply(int page, int rows)
        {

            var list = new JiaJiBLL.ApplyBLL().StuApplyList();
            var result = new { total = list.Count, rows = list.Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }
        /// <summary>
        /// 删除提交信息列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteApply(string ids)
        {
            bool isOK = new JiaJiBLL.ApplyBLL().DelApply(ids);
            if (isOK) return 0;
            else return 1;
        }


        #endregion





    }
}
