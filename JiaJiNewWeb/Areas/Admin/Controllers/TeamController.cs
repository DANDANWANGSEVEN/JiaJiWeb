using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiBLL;
using JiaJiModels;
using Newtonsoft.Json;
using System.IO;

namespace JiaJiNewWeb.Areas.Admin.Controllers
{
    public class TeamController : Controller
    {
        teambll tbll = new teambll();
        // GET: Team

        
        public ActionResult Index()
        {
            return View();
        }

        #region 精英团队
        /// <summary>
        /// 添加团队页面
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertTeam()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Teamshow()
        {
            return Json(new JiaJiBLL.teambll().Team(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getInsertTeam(int page, int rows,int?AreaID=null)
        {

            var list = new JiaJiBLL.teambll().GetTeam();
            var result = new
            {
                total = list.
               Where(e =>
               (AreaID == null ? true : e.AreaID == AreaID)
               
               ).Count(),
                rows = list.
               Where(e =>
               (AreaID == null ? true : e.AreaID == AreaID)
               
               ).Skip((page - 1) * rows).Take(rows)
            };
            //var result = new { total = list.Count, rows = list.Skip((page - 1) * rows).Take(rows) };
            return Json(result);

        }
        /// <summary>
        /// 删除团队信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteInsertTeam(string ids)
        {
            bool isOK = new JiaJiBLL.teambll().DelTeamInfo(ids);
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
        public JsonResult addInsertTeam(JiaJiModels.Team infor)
        {
            try
            {
                infor.Image1 = "/image/" + infor.Image1;
                infor.Image2 = "/image/" + infor.Image2;
                var i = new JiaJiBLL.teambll().addTeam(infor);
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
        /// 修改精英信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editInsertTeam(JiaJiModels.Team model)
        {
            try
            {
                int id = model.TeamID;

                var i = new JiaJiBLL.teambll().UpdateTeam(model);
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
        /// 添加团队
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        //public ActionResult InsertTeamPro(HttpPostedFileBase file1,HttpPostedFileBase file2,Team t)
        //{
        //    try
        //    {
        //        if (file1 == null || file2 == null)
        //        {
        //            return Content("<script>alert('请选择图片！');location.href='/Team/InsertTeam';</script>");
        //        }


        //        string path1 = Server.MapPath("/image/"+file1.FileName);
        //        file1.SaveAs(path1);
        //        string image1 = "/image/" + file1.FileName;
        //        string exis1 = Path.GetExtension(path1).Remove(0, 1);
        //        string image2 = "/image/" + file1.FileName;
        //        string path2 = Server.MapPath(image2);
        //        file2.SaveAs(path2);
        //        string exis2 = Path.GetExtension(path2).Remove(0, 1);
        //        if (exis1.ToLower() == "jpg" || exis1 == "png" || exis1 == "gif" || exis2.ToLower() == "jpg" || exis2 == "png" || exis2 == "gif")
        //        {
        //            string ak = Request["countrys"].ToString();
        //            t.ShenQing = ak.Replace(",", "/");
        //            t.Image1 = image1;
        //            t.Image2 = image2;
        //            tbll.InsertTeam(t);
        //            return Content("<script>alert('添加成功！');location.href='/Team/InsertTeam';</script>");
        //        }
        //        else
        //        {
        //            return Content("<script>alert('请选择正确的图片格式！(jpg,png,gif)');location.href='/Team/InsertTeam';</script>");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return Content("<script>alert('服务器繁忙！');location.href='/Team/InsertTeam';</script>");
        //    }

        //}
        #endregion

        #region 团队标题内容
        /// <summary>
        /// 添加团队标题内容页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Title()
        {
            return View();
        }
        [HttpPost]
        public JsonResult TeamTitleshow()
        {
            return Json(new JiaJiBLL.teambll().showTitle(), JsonRequestBehavior.AllowGet);
        }

   
        public JsonResult getTitle(int page, int rows,string TitleName="",int? TeamID=null)
        {
            var list = new JiaJiBLL.teambll().Titleshow();
            var result = new
            {
                total = list.
            Where(e => e.TitleName.Contains(TitleName)
            && (TeamID == null ? true : e.TeamID == TeamID)
           
            ).Count(),
                rows = list.
            Where(e => e.TitleName.Contains(TitleName)
            && (TeamID == null ? true : e.TeamID == TeamID)
            ).Skip((page - 1) * rows).Take(rows)
            };
            //var result = new { total = list.Count, rows = list.Where(e=>e.TitleName.Contains(TitleName)) .Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 删除团队标题信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteTitle(string ids)
        {
            bool isOK = new JiaJiBLL.teambll().DelTeamTitle(ids);
            if (isOK) return 0;
            else return 1;

        }
        /// <summary>
        /// 添加团队标题内容
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
       
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addTitle(JiaJiModels.Team infor)
        {
            try
            {
                var i = new JiaJiBLL.teambll().InsertTitle(infor);
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
        /// 修改团队标题信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editTitle(JiaJiModels.Team model)
        {
            try
            {
                int id = model.TermRealID;

                var i = new JiaJiBLL.teambll().UpdateTitle(model);
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

    }
}