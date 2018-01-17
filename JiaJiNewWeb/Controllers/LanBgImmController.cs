using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiNewWebBLL;
using Newtonsoft.Json;
using JiaJiNewWeb.Common;

using JiaJiNewWebModel;

namespace JiaJiNewWeb.Controllers
{
    public class LanBgImmController : Controller
    {
        LanguageBLL bll = new LanguageBLL();


        public ActionResult NewLanBgImm()
        {
            return View();
        }



        // GET: LanBgImm
        public ActionResult LanBgImm(int id)
        {
            ViewBag.id = id;
            List<Country> LBY = new SuccessFulRelationBLL().GetLBY(id);
            ViewBag.countryyoushilist = LBY;
          
            ViewBag.youshi = new DominantBLL().GetDominant(id);  //获取不是国家的优势

            ViewBag.firstlist = new JiaJiNewWebBLL.ProjectItemBLL().GetFirstList();  //首加载学员分享

            //ViewBag.indexliuxue = new JiaJiNewWebBLL.LunBoImageBLL().IndexLXueList();  //首页留学图片

            ViewBag.Project =new JiaJiNewWebBLL.ProjectBLL().ImmigrantShow();    //移民项目


            ViewBag.Projectitem= new JiaJiNewWebBLL.ProjectItemBLL().GetProductList(); //背景提升项目
            //ViewBag.indexzixun = new JiaJiNewWebBLL.LunBoImageBLL().IndexZiXunImage();  //首页资讯图片


            return View();
        }

        /// <summary>
        /// 学员分享
        /// </summary>
        /// <param name="countryid"></param>
        /// <returns></returns>
        public string ShareList(int shareid)
        {

            List<JiaJiNewWebModel.Share> shareindexlist = new JiaJiNewWebBLL.ProjectItemBLL().GetShareList(shareid); ; 
            JsonConvert.SerializeObject(shareindexlist);
            return JsonConvert.SerializeObject(shareindexlist);
        }


        /// <summary>
        /// 语言类别
        /// </summary>
        /// <returns></returns>
        public string Language()
        {
            return JsonConvert.SerializeObject(bll.Language());
        }
        ///<summary>
        ///语言内容显示
        ///<para>Id:语言Id</para>
        /// </summary>
        /// <returns></returns>       

        public string LanguageShow(int Id)
        {
            return JsonConvert.SerializeObject(bll.LanguageShow(Id));
        }

        /// <summary>
        /// 语言课程
        /// </summary>
        /// <param name="Id">语言类别ID</param>
        /// <returns></returns>
        public string CourseShow(int Id)
        {
            return JsonConvert.SerializeObject(bll.CourseShow(Id));
        }

        ///<summary>
        ///语言学员列表
        /// <para>ID:语言ID</para>
        /// </summary>
        public string LearnShow(int Id)
        {
            return JsonConvert.SerializeObject(bll.LearnShow(Id));
        }
        /// <summary>
        /// 获取留学项目的列表字符串JSON
        /// </summary>
        /// <returns></returns>
        public string ProductItemJsonStr()
         {
            List<JiaJiNewWebModel.projectItem> list = new JiaJiNewWebBLL.ProjectItemBLL().GetProductList();
            return JsonConvert.SerializeObject(list);
        }
       /// <summary>
       /// 获取学员分享内容的JSON字符串
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public string ShareJsonStr(int id)
        {
            List<JiaJiNewWebModel.Share> list = new JiaJiNewWebBLL.ProjectItemBLL().GetShareList(id);
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 项目对应的图片
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public string proimglist(int id)
        {

            List<JiaJiNewWebModel.projectItem> proimglist = new JiaJiNewWebBLL.ProjectItemBLL().GetProImgList(id);
            JsonConvert.SerializeObject(proimglist);
            return JsonConvert.SerializeObject(proimglist);
        }

    }
}