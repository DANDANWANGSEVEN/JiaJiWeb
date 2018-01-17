using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using JiaJiModels;

namespace JiaJiNewWeb.Areas.Admin.Controllers
{
    public class SuccessInfoController : Controller
    {
        JiaJiBLL.CollageBLL collagebll = new JiaJiBLL.CollageBLL();
        // GET: SuccessInfo

       

        #region 嘉际观点
        /// <summary>
        /// 嘉际观点添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OptionAdd()
        {
            return View();
        }
        /// <summary>
        /// 观点显示
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getOptionAdd(int page, int rows,string OptionTitle="")
        {
            var list = new JiaJiBLL.OptionBLL().ShowOptions();
            var result = new { total = list.Count, rows = list.Where(e=>e.OptionTitle.Contains(OptionTitle)).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>  
        /// 观点添加
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addOptionAdd(JiaJiModels.OptionModel model)
        {
            try
            {
                model.OptionUrl = "/image/" + model.OptionUrl;
                var i = new JiaJiBLL.OptionBLL().AddOption(model);
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
        /// 删除观点
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteOptionAdd(string ids)
        {
            bool isOK = new JiaJiBLL.OptionBLL().DelOptions(ids);
            if (isOK) return 0;
            else return 1;

        }

        /// <summary>
        /// 修改观点
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editOptionAdd(JiaJiModels.OptionModel model)
        {
            try
            {
                int id = model.OptionID;

                var i = new JiaJiBLL.OptionBLL().UpdOptions(model);
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
        /// 地区页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Education()
        {
            return View();
        }

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


        /// <summary>
        /// 显示学历
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult getEducation(int page, int rows)
        {
            var list = new JiaJiBLL.EducetionBll().ShowEducation();
            var result = new { total = list.Count, rows = list.Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }


        /// <summary>
        /// 学历添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addEducation(JiaJiModels.educationtype model)
        {
            try
            {
                var i = new JiaJiBLL.EducetionBll().AddEducation(model);
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
        /// 删除学历
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteEducation(string ids)
        {
            bool isOK = new JiaJiBLL.EducetionBll().DelEducation(ids);
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
        public JsonResult editEducation(JiaJiModels.educationtype model)
        {
            try
            {
                int id = model.EducationID;

                var i = new JiaJiBLL.EducetionBll().UpdEducation(model);
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

        #region 学院
        /// <summary>
        /// 添加国家和录取学院页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Collegeshow()
        {
            return Json(new JiaJiBLL.CollageBLL().Collegehow(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getIndex(int page, int rows)
        {
            var list = collagebll.Collegehow();
            var result = new { total = list.Count, rows = list.OrderBy(e => e.CollegeID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }
        /// <summary>
        /// 删除留学院列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteIndex(string ids)
        {
            bool isOK = new JiaJiBLL.CollageBLL().DelCollage(ids);
            if (isOK)
                return 0;
            else return 1;

        }

        /// <summary>
        /// 学历添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addIndex(JiaJiModels.collages model)
        {
            try
            {
                model.CollegeImg = "/image/"+model.CollegeImg;
                var i = new JiaJiBLL.CollageBLL().collageadd(model);
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
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editIndex(JiaJiModels.collages model)
        {
            try
            {
                int id = model.CollegeID;
                var i = new JiaJiBLL.CollageBLL().UpdateCollege(model);
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

        #region 成功案例
        /// <summary>
        /// 添加成功案例
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSuccessinfo()
        {
            return View();
        }
        public JsonResult getAddSuccessinfo(int page, int rows, string SuccessTitle = "", int? StudentID = null)
        {
            var list = new JiaJiBLL.Anlibll().ShowSuccessAnli();
        var result = new
        {
            total = list.
            Where(e => e.SuccessTitle.Contains(SuccessTitle)
            && (StudentID == null ? true : e.StudentID == StudentID)
            ).Count(),
            rows = list.
            Where(e => e.SuccessTitle.Contains(SuccessTitle)
            && (StudentID == null ? true : e.StudentID == StudentID)
            ).Skip((page - 1) * rows).Take(rows)
        };
        //var result = new { total = list.Count, rows = list.Where(e=>e.SuccessTitle.Contains(SuccessTitle)).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 删除成功案例
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteAddSuccessinfo(string ids)
        {
            bool isOK = new JiaJiBLL.Anlibll().DelAnli(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>
        /// 添加成功案例
        /// </summary>
        /// <param name="studentmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addAddSuccessinfo(JiaJiModels.Anli infor,int TeamID)
        {
            try
            {

                var i = new JiaJiBLL.Anlibll().Anliadd(infor, TeamID);
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
        /// 修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editAddSuccessinfo(JiaJiModels.Anli model,int TeamID)
        {
            try
            {
                int id = model.SRelationID;
                var i = new JiaJiBLL.Anlibll().UpdateAnLi(model, TeamID);
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

        #region 学生信息管理
        /// <summary>
        /// 录取学生添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Stushow()
        {
            return Json(new JiaJiBLL.stubll().stushow(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getStudent(int page, int rows,int? CollegeID=null,int? EducationID=null,int? CountryID=null)
        {
            var list = new JiaJiBLL.stubll().stushow();
            var result = new
            {
                total = list.
               Where(e => 
                (CollegeID == null ? true : e.CollegeID == CollegeID)
               && (EducationID == null ? true : e.EducationID == EducationID)
                && (CountryID == null ? true : e.CountryID == CountryID)
               
               ).Count(),
                rows = list.
               Where(e => 
               (CollegeID == null ? true : e.CollegeID == CollegeID)
               && (EducationID == null ? true : e.EducationID == EducationID)
                && (CountryID == null ? true : e.CountryID == CountryID)
               
               ).Skip((page - 1) * rows).Take(rows)
            };
            
            return Json(result);
        }
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteStudent(string ids)
        {
            bool isOK = new JiaJiBLL.stubll().DelStudent(ids);
            if (isOK) return 0;
            else return 1;
        }



        /// <summary>  
        /// 添加学生信息
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addStudent(JiaJiModels.student infor)
        {
            try
            {
                infor.Image = "/image/"+ infor.Image;
                var i = new JiaJiBLL.stubll().addStu(infor);
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
        /// 修改学生信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editStudent(JiaJiModels.student model)
        {
            try
            {
                int id = model.StudentID;

                var i = new JiaJiBLL.stubll().UpdateStu(model);
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

        #region 就读学院信息
        /// <summary>
        /// 获取就读学院
        /// </summary>
        /// <returns></returns>
        public string TeamJson()
        {
            List<JiaJiModels.Team> list = new JiaJiBLL.stubll().Tshow();
            return JsonConvert.SerializeObject(list);
        }
        /// <summary>
        /// 获取就读学院信息
        /// </summary>
        /// <returns></returns>
        public string CollageInfo()
        {
            List<JiaJiModels.Attending> list = collagebll.Ashow();//获取就读学院的信息
            return JsonConvert.SerializeObject(list);

        }
        /// <summary>
        /// 删除就读学
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelCollage(int id)
        {
            return collagebll.DelAttending(id);
        }
        /// <summary>
        /// 添加就读学院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public int AddCollage(string Name)
        {
            return collagebll.Attendadd(Name);
        }
        #endregion

        #region 录取学院


        /// <summary>
        /// 获取录取学院
        /// </summary>
        /// <returns></returns>
        public string Attendshow()
        {
            List<JiaJiModels.collages> list = new JiaJiBLL.CollageBLL().Collegehow();
            return JsonConvert.SerializeObject(list);
        }
        public string Attendshows()
        {
            List<JiaJiModels.Attending> list = new JiaJiBLL.CollageBLL().Ashow();
            return JsonConvert.SerializeObject(list);
        }
        /// <summary>
        /// 添加录取学院
        /// </summary>
        /// <param name="LuquName"></param>
        /// <returns></returns>
        public int AddLuqu(string Name)
        {
            return collagebll.Attendadd(Name);

        }

        /// <summary>
        /// 获取录取学院列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string JaonCollegeLsit()
        {
            List<JiaJiModels.collages> list = new JiaJiBLL.CollageBLL().Collegehow();
            return JsonConvert.SerializeObject(list);
        }
        /// <summary>
        /// 删除录取学院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelteCollage(string ids)
        {

            bool isOK = new JiaJiBLL.CollageBLL().DelCollage(ids);
            if (isOK)
                return 0;
            else return 1;

       
    }

        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult ADDstudent(string sname, HttpPostedFileBase file, string jd, string cj, int lx)
        //{
        //    try
        //    {
        //        string files = Server.MapPath("/image/" + file.FileName);
        //        file.SaveAs(files);
        //        JiaJiModels.student stu = new JiaJiModels.student();
        //        stu.StudentName = sname;
        //        stu.Score = cj;

        //        stu.Image = "/image/" + Path.GetFileName(file.FileName);
        //        stu.JiuDuXueyuan = jd;
        //        stu.EducationID = lx;
        //        int i = new JiaJiBLL.stubll().AddStudentInfo(stu);

        //        if (i > 0)
        //        {
        //            return Content("<script>alert('添加成功');location.href='/SuccessInfo/student'</script>");
        //        }
        //        else
        //        {
        //            return Content("<script>alert('添加失败')location.href='/SuccessInfo/student'</script>");
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion

        


    }
}