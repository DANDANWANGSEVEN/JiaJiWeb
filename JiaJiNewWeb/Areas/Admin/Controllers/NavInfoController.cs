using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiBLL;
using JiaJiModels;

namespace JiaJiNewWeb.Areas.Admin.Controllers
{
    public class NavInfoController : Controller
    {
        // GET: NavInfo
        public ActionResult NavInfo()
        {
            return View();
        }
        public ActionResult AddNav(int id)
        {
            return View();
        }
        public ActionResult EditNavInfo(int id)
        {
            NavInfo model = new JiaJiModels.NavInfo();
            if (id != 0)
            {
                model = new JiaJiBLL.NavInfoBll().GetModelByNavID(id);
            }
            ViewData["edit"] = model;
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public string EditGetModel()
        {
            this.ValidateRequest = false;
            NavInfo model = new JiaJiModels.NavInfo();
            model.NavID = Convert.ToInt32(Request["Navid"]);
            model.GuoJia = Request["guojia"];
            model.BuWei = Request["buwei"];
            model.LinkFor = Request["lianjie"];
            model.NavTitleOne = Request["daohangbiaoti"];
            model.NavTitleTwo = Request["wenzhangbiaoti"];
            model.depth = Convert.ToInt32(Request["shendu"]);
            model.PaiXu = Convert.ToInt32(Request["paixu"]);
            model.NavContentTwo = Request["content"];
            model.KeyWord= Request["KeyWord"];
            bool res = new JiaJiBLL.NavInfoBll().EditByModelContent(model);
            new JavaScriptResult().Script = @"<script>alert('添加成功');window.location.href='\Admin\NavInfo\AddNav\0';</script>";
            //return Content(@"<script>alert('添加成功');window.location.href='\NavInfo\AddNav\0';</script>");
            //Response.Write("<script>alert('添加成功！');</script>");
            //Page.RegisterStartupScript("msg<script>alert('添加成功！');</script>");
            string r = "";
            if (res)
                r = "ok";
            else
                r = "no";
            return r;
        }
        public JsonResult NavShow()
        {
            return Json(new JiaJiBLL.NavInfoBll().GetNavList(),JsonRequestBehavior.AllowGet);
        }

        public JsonResult CountryList()
        {
            return Json(Country.Dictionary.ToList(),JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTypeByCountryId(int countryId)
        {
            return Json(new JiaJiBLL.NavInfoBll().GetTypeByCountryId(countryId), JsonRequestBehavior.AllowGet);
        }
        //ActionResult
        [ValidateInput(false)]
        [HttpPost]
        public string GetModel()
        {
            //{ "guojia": guojia.text(), "buwei": buwei.text(), "lianjie": lianjie.val(), "parentsid": parentsid.val(), "daohangbiaoti": daohangbiaoti.val(), "wenzhangbiaoti": wenzhangbiaoti.val(), "shendu": shendu.val(), "content": content .val()})
            this.ValidateRequest = false;
            NavInfo model = new JiaJiModels.NavInfo();
            model.GuoJia = Request["guojia"];
            model.BuWei = Request["buwei"];
            model.LinkFor = Request["lianjie"];
            model.NavIsLevel = Convert.ToInt32(Request["jiedian"]);
            model.NavParentID = Convert.ToInt32(Request["parentsid"]);
            model.NavTitleOne= Request["daohangbiaoti"];
            model.NavTitleTwo = Request["wenzhangbiaoti"];
            model.depth =Convert.ToInt32(Request["shendu"]);
            model.PaiXu = Convert.ToInt32(Request["paixu"]);
            model.NavContentTwo = Request["content"];

            bool res = new JiaJiBLL.NavInfoBll().AddByModel(model);
            new JavaScriptResult().Script = @"<script>alert('添加成功');window.location.href='\Admin\NavInfo\AddNav\0';</script>";
            //return Content(@"<script>alert('添加成功');window.location.href='\NavInfo\AddNav\0';</script>");
            //Response.Write("<script>alert('添加成功！');</script>");
            //Page.RegisterStartupScript("msg<script>alert('添加成功！');</script>");
            string r = "";
            if (res)
                r = "ok";
            else
                r = "no";
            return r;
        }
    }
}