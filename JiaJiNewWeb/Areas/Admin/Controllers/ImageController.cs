using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JiaJiNewWeb.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }
        #region 二维码管理

        public ActionResult ErWeiMaPage()
        {
            return View();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getErWeiMaPage(int page, int rows,string EWMTitle="")
        {

            var list = new JiaJiBLL.ImageBll().ShowErWeiMa();
            var result = new { total = list.Count, rows = list.Where(e=>e.EWMTitle.Contains(EWMTitle)).OrderBy(e => e.EWMID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addErWeiMaPage(JiaJiModels.ErWeiMaModel model)
        {
            try
            {
                model.EWMUrl = "/image/" + model.EWMUrl;
                var i = new JiaJiBLL.ImageBll().AddErWeiMa(model);
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
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteErWeiMaPage(string ids)
        {
            bool isOK = new JiaJiBLL.ImageBll().DelErWeiMa(ids);
            if (isOK) return 0;
            else return 1;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editErWeiMaPage(JiaJiModels.ErWeiMaModel model)
        {
            try
            {
                int id = model.EWMID;

                var i = new JiaJiBLL.ImageBll().UpdateErWeiMa(model);
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

        #region  首页轮播图
        public ActionResult IndexLunBo()
        {
            return View();
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getIndexLunBo(int page, int rows)
        {

             var list = new JiaJiBLL.ImageBll().ShowIndexLunBo();
            var result = new { total = list.Count, rows = list.OrderBy(e => e.ImageID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>  
        /// 添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addIndexLunBo(JiaJiModels.IndexLunBo model)
        {
            try
            {
                model.ImageUrl = "/image/" + model.ImageUrl;
                var i = new JiaJiBLL.ImageBll().AddIndexLunBo(model);
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
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteIndexLunBo(string ids)
        {
            bool isOK = new JiaJiBLL.ImageBll().DelIndexLunBo(ids);
            if (isOK) return 0;
            else return 1;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editIndexLunBo(JiaJiModels.IndexLunBo model)
        {
            try
            {
                int id = model.ImageID;

                var i = new JiaJiBLL.ImageBll().UpdateIndexLunBo(model);
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

        #region 国家页图片


        public ActionResult CounLunBo()
        {
            return View();
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getCounLunBo(int page, int rows,int? CountryID=null,int? EducationID=null)
        {

            var list = new JiaJiBLL.ImageBll().ShowCounImage();

            var result = new
            {
                total = list.
               Where(e => 
               (CountryID == null ? true : e.CountryID == CountryID)
               && (EducationID == null ? true : e.EducationID == EducationID)
               ).Count(),
                rows = list.
               Where(e => 
              (CountryID == null ? true : e.CountryID == CountryID)
              && (EducationID == null ? true : e.EducationID == EducationID)
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
        public JsonResult addCounLunBo(JiaJiModels.LunBoImage model)
        {
            try
            {
                model.ImageUrl = "/image/" + model.ImageUrl; 
                var i = new JiaJiBLL.ImageBll().AddCounImage(model);
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
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteCounLunBo(string ids)
        {
            bool isOK = new JiaJiBLL.ImageBll().DelCounImage(ids);
            if (isOK) return 0;
            else return 1;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editCounLunBo(JiaJiModels.LunBoImage model)
        {
            try
            {
                int id = model.LunImageID;
               
                var i = new JiaJiBLL.ImageBll().UpdateCounImage(model);
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