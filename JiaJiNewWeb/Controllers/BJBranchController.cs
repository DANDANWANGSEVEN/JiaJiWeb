using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiNewWebModel;
 
using Newtonsoft.Json;
namespace JiaJiNewWeb.Controllers
{
    public class BJBranchController : Controller
    {

        JiaJiNewWebBLL.ActiveBLL activebll = new JiaJiNewWebBLL.ActiveBLL();
        JiaJiNewWebBLL.InformationBLL infobll = new JiaJiNewWebBLL.InformationBLL();
        JiaJiNewWebBLL.ApplyBLL apbll = new JiaJiNewWebBLL.ApplyBLL();
        JiaJiNewWebBLL.MediumBLL mebll = new JiaJiNewWebBLL.MediumBLL();
        JiaJiNewWebBLL.ProjectBLL projectbll = new JiaJiNewWebBLL.ProjectBLL();
        // GET: BJBranch
        public ActionResult BJBranch()
        {
            ViewBag.indexzixun = new JiaJiNewWebBLL.LunBoImageBLL().BeiXiInforImage(1);
            //List<Information> infolist = infobll.GetInformationTopList();//留学资讯
            List<JiaJiNewWebModel.Information> infolist = new JiaJiNewWebBLL.InformationBLL().GetBeiJingInfor();
            List<JiaJiNewWebModel.Active> activelist = new JiaJiNewWebBLL.ActiveBLL().ActiveLsitBeiJing();  //北京最新活动数据
            //List<JiaJiNewWebModel.Team> termList = new JiaJiNewWebBLL.TeamBLL().GetBeiJingTeam(); //精英团队信息  ViewBag.teamList = termList;

            ViewBag.infolist = infolist;
            ViewBag.activelist = activelist;
            ViewBag.solutionList = new JiaJiNewWebBLL.SolutionBLL().SolutionIndexList();//获取解决方案的信息
            ViewBag.LaugList = new JiaJiNewWebBLL.LanguageBLL().GetPeixunList();  //语言培训的内容显示位于页底
            return View();
        }
        /// <summary>
        /// 公司信息
        /// </summary>
        /// <param name="FilialeId"></param>
        /// <returns></returns>
        //public JsonResult GetFilialetext(int FilialeId)
        //{
        //    filialetext text = new JiaJiNewWebBLL.FilialeBll().GetFilialetext(FilialeId);
        //    return Json(text, JsonRequestBehavior.AllowGet);
        //}

        public static JiaJiNewWebModel.filialetext GetFilialetext(int FilialeId)
        {
            JiaJiNewWebBLL.FilialeBll filiale = new JiaJiNewWebBLL.FilialeBll();

            return filiale.GetFilialetext(FilialeId);
        }

        /// <summary>
        /// 精英团队
        /// </summary>
        /// <returns></returns>
        public static List<JiaJiNewWebModel.Team> BeijingTeamShow()
        {
            JiaJiNewWebBLL.TeamBLL teambll = new JiaJiNewWebBLL.TeamBLL();

            return teambll.GetBeiJingTeam();
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

            List<JiaJiNewWebModel.StudentIndexModel> studentList = new JiaJiNewWebBLL.StudentBLL().StudentIndexList(index, goIndex);//获取学生的信息
            return JsonConvert.SerializeObject(studentList);


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
        /// 媒体合作
        /// </summary>
        /// <returns></returns>
        public string Mediu()
        {
            return JsonConvert.SerializeObject(mebll.GetMedium());
        }

        ///<summary>
        ///获取背景提升项目
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string ProjectShow()
        {
            return JsonConvert.SerializeObject(projectbll.ProjectShow());
        }
        ///<summary>
        ///获取移民项目
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string ImmigrantShow()
        {
            return JsonConvert.SerializeObject(projectbll.ImmigrantShow());
        }
    }
}