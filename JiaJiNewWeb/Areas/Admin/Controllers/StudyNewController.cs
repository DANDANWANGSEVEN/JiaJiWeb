 using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiModels;
using JiaJiBLL;
namespace JiaJiNewWeb.Areas.Admin.Controllers
{
    public class StudyNewController : Controller
    {
        ApplyBLL applybll = new ApplyBLL();
        DoBLL dobll = new DoBLL();
        ProjectBLL probll = new ProjectBLL();


        #region 移民项目
        ///<summary>
        ///移民项目
        /// </summary>
        public ActionResult Project()
        {
            return View();
        }

        public JsonResult getProject(int page, int rows,string ProjectTitle="")
        {
            var list = new JiaJiBLL.ProjectBLL().ShowProject();
            var result = new { total = list.Count, rows = list.Where(e => e.ProjectTitle.Contains(ProjectTitle)).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }
        /// <summary>
        /// 删除移民项目
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteProject(string ids)
        {
            bool isOK = new JiaJiBLL.ProjectBLL().DelProject(ids);
            if (isOK) return 0;
            else return 1;

        }

        /// <summary>
        /// 添加移民项目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addProject(JiaJiModels.ProjectModel model)
        {
            try
            {
                model.Image = "/image/"+ model.Image;
                var i = new JiaJiBLL.ProjectBLL().AddPro(model);
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
        /// 修改移民项目
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editProject(JiaJiModels.ProjectModel model)
        {
            try
            {
                int id = model.ProjectID;

                var i = new JiaJiBLL.ProjectBLL().UpdPro(model);
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

        #region 优势
        /// <summary>
        /// 优势
        /// </summary>
        /// <returns></returns>
        public ActionResult Dominant()
        {
            return View();
        }
        public JsonResult getDominant(int page, int rows,int?CountryID=null)
        {
            var list = new JiaJiBLL.DoBLL().ShowDominant();
            var result = new
            {
                total = list.
                 Where(e => 
                 (CountryID == null ? true : e.CountryID == CountryID)
                
                 ).Count(),
                rows = list.
                 Where(e => 
                 (CountryID == null ? true : e.CountryID == CountryID)
                
                 ).Skip((page - 1) * rows).Take(rows)
            };
            return Json(result);
        }

        /// <summary>
        /// 删除优势
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteDominant(string ids)
        {
            bool isOK = new JiaJiBLL.DoBLL().DelDominant(ids);
            if (isOK)
                return 0;
            else return 1;

        }

        /// <summary>  
        /// 添加优势
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addDominant(JiaJiModels.DominantModel infor)
        {
            try
            {
                var i = new JiaJiBLL.DoBLL().addDominant(infor);
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
        /// 修改优势
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editDominant(JiaJiModels.DominantModel model)
        {
            try
            {
                int id = model.CountryDominantID;

                var i = new JiaJiBLL.DoBLL().UpdateDominant(model);
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


        #region 学员列表

        public ActionResult LearnerList()
        {
            return View();
        }

        public JsonResult getLearnerList(int page, int rows,int?CountryID=null)
        {
            var list = new JiaJiBLL.LearnerBll().showLearner();
            var result = new
            {
                total = list.
               Where(e =>
              (CountryID == null ? true : e.CountryID == CountryID)
               
               ).Count(),
                rows = list.
               Where(e =>
              (CountryID == null ? true : e.CountryID == CountryID)
              
               ).Skip((page - 1) * rows).Take(rows)
            };
            return Json(result);
        }

        /// <summary>
        /// 删除学员列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteLearnerList(string ids)
        {
            bool isOK = new JiaJiBLL.LearnerBll().DelLearner(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加学员列表
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addLearnerList(JiaJiModels.LearnerModel infor)
        {
            try
            {
                infor.LearnImage = "/image/"+ infor.LearnImage;
                var i = new JiaJiBLL.LearnerBll().addLearner(infor);
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
        /// 修改学员列表
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editLearnerList(JiaJiModels.LearnerModel model)
        {
            try
            {
                int id = model.LearnerID;

                var i = new JiaJiBLL.LearnerBll().UpdateLearner(model);
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

        #region 学员分享
        /// <summary>
        /// 语言，课程，学员分享添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getIndex(int page, int rows, string ShareTitle = "", int? LearnerID = null,int? Pro_ID=null)
        {
            var list = new JiaJiBLL.LanguageBLL().ShowShare();
            var result = new
            {
                total = list.
            Where(e => e.ShareTitle.Contains(ShareTitle)
            && (LearnerID == null ? true : e.LearnerID == LearnerID)
            && (Pro_ID == null ? true : e.Pro_ID == Pro_ID)
           
            ).Count(),
                rows = list.
            Where(e => e.ShareTitle.Contains(ShareTitle)
            && (LearnerID == null ? true : e.LearnerID == LearnerID)
            && (Pro_ID == null ? true : e.Pro_ID == Pro_ID)
            
            ).Skip((page - 1) * rows).Take(rows)
            };
            //var result = new { total = list.Count, rows = list.Where(e=>e.ShareTitle.Contains(ShareTitle)).OrderBy(e => e.ShareID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }
        /// <summary>
        /// 删除学员分享
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteIndex(string ids)
        {
            bool isOK = new JiaJiBLL.LanguageBLL().DeleteShare(ids);
            if (isOK) return 0;
            else return 1;

        }

        /// <summary>
        /// 学员分享添加
        /// </summary>
        /// <param name="ming"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addIndex(JiaJiModels.ShareModel model)
        {
            try
            {
                model.ShareImg = "/image/"+ model.ShareImg;
                var i = new JiaJiBLL.LanguageBLL().AddShare(model);
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
        /// 修改学员分享
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editIndex(JiaJiModels.ShareModel model)
        {
            try
            {
                int id = model.ShareID;

                var i = new JiaJiBLL.LanguageBLL().UpdateShare(model);
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

        #region 课程管理
        /// <summary>
        /// 课程管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Course()
        {
            return View();
        }
        /// <summary>
        /// 显示课程管理
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getCourse(int page, int rows,int? LanguageID=null)
        {

            var list = new JiaJiBLL.LanguageBLL().ShowLangCour();
            var result = new
            {
                total = list.
           Where(e => (LanguageID == null ? true : e.LanguageID == LanguageID)
          
           ).Count(),
                rows = list.
           Where(e => (LanguageID == null ? true : e.LanguageID == LanguageID)
           ).Skip((page - 1) * rows).Take(rows)
            };
            return Json(result);
        }

        /// <summary>
        /// 删除课程管理
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteCourse(string ids)
        {
            bool isOK = new JiaJiBLL.LanguageBLL().DelCourse(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加课程管理
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addCourse(JiaJiModels.CourseModel infor)
        {
            try
            {
                var i = new JiaJiBLL.LanguageBLL().addCourse(infor);
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
        /// 修改课程管理
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editCourse(JiaJiModels.languagerelation model)
        {
            try
            {
                int id = model.LRelationID;

                var i = new JiaJiBLL.LanguageBLL().UpdateCourse(model);
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

        #region 语言管理
        /// <summary>
        /// 语言管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Language()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Languageshow()
        {
            return Json(new JiaJiBLL.LanguageBLL().ShowLanguage(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取语言
        /// </summary>
        /// <returns></returns>
        public string showLanguage()
        {
            return JsonConvert.SerializeObject(new JiaJiBLL.LanguageBLL().ShowLanguage());
        }

        /// <summary>
        /// 显示语言管理
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult getLanguage(int page, int rows,string LanguageTitle="")
        {

            var list = new JiaJiBLL.LanguageBLL().ShowLanguage();
            var result = new { total = list.Count, rows = list.Where(e=>e.LanguageTitle.Contains(LanguageTitle)).OrderBy(e => e.LanguageID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 删除语言管理
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteLanguage(string ids)
        {
            bool isOK = new JiaJiBLL.LanguageBLL().DelLanguage(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加语言管理
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addLanguage(JiaJiModels.Languages infor)
        {
            try
            {
                var i = new JiaJiBLL.LanguageBLL().addLanguage(infor);
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
        /// 修改课程管理
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editLanguage(JiaJiModels.Languages model)
        {
            try
            {
                int id = model.LanguageID;

                var i = new JiaJiBLL.LanguageBLL().UpdateLanguage(model);
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

        #region 高分学员

        public ActionResult MaxScoStu()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LearnerShow()
        {
            return Json(new JiaJiBLL.LearnerBll().showLearner(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getMaxScoStu(int page, int rows, int? LearnerID = null,int? LanguageID=null)
        {
            var list = new JiaJiBLL.LearnerBll().showMaxScoStu();
            var result = new
            {
                total = list.
              Where(e => 
              (LearnerID == null ? true : e.LearnerID == LearnerID)
              && (LanguageID == null ? true : e.LanguageID == LanguageID)
              ).Count(),
                rows = list.
              Where(e => 
              (LearnerID == null ? true : e.CountryID == LearnerID)
              && (LanguageID == null ? true : e.LanguageID == LanguageID)
              ).Skip((page - 1) * rows).Take(rows)
            };

            return Json(result);
        }

        /// <summary>
        /// 删除学员列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteMaxScoStu(string ids)
        {
            bool isOK = new JiaJiBLL.LearnerBll().DelMaxScoStu(ids);
            if (isOK) return 0;
            else return 1;
        }

        /// <summary>  
        /// 添加学员列表
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult addMaxScoStu(JiaJiModels.LearnerModel infor)
        {
            try
            {
                infor.LearnImage = "/image/" + infor.LearnImage;
                var i = new JiaJiBLL.LearnerBll().addMaxScoStu(infor);
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
        /// 修改学员列表
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editMaxScoStu(JiaJiModels.LearnerModel model)
        {
            try
            {
                int id = model.LearnSorceID;

                var i = new JiaJiBLL.LearnerBll().UpdateMaxScoStu(model);
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



        /// <summary>
        /// 获取背景提升项目
        /// </summary>
        /// <returns></returns>
        public string ProjectItem()
        {
            return JsonConvert.SerializeObject( new JiaJiBLL.LanguageBLL().Project());
        }
        

        #region 时间规划
        /// <summary>
        /// 留学材料
        /// </summary>
        /// <returns></returns>
        public ActionResult Apply()
        {
            return View();
        }
        public JsonResult getApply(int page, int rows,int?CountryID=null, int? EducationID = null)
        {
            var list = new JiaJiBLL.ApplyBLL().ShowArrangTime();

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

            //var result = new { total = list.Count, rows = list.OrderBy(e => e.ArrangeID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        /// <summary>
        /// 删除留学规划
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteApply(string ids)
        {
            bool isOK = new JiaJiBLL.ApplyBLL().DelArrangetime(ids);
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
        public JsonResult addApply(JiaJiModels.ApplyModel.ArrangeTime infor)
        {
            try
            {
                var i = new JiaJiBLL.ApplyBLL().addArrangeTime(infor);
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
        public JsonResult editApply(JiaJiModels.ApplyModel.ArrangeTime model)
        {
            try
            {
                int id = model.ArrangeID;

                var i = new JiaJiBLL.ApplyBLL().UpdArrangeTime(model);
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

        #region 留学规划
        ///<summary>
        ///留学规划
        /// </summary>
        public ActionResult CountryGuiHua()
        {
            return View();
        }

        public JsonResult getCountryGuiHua(int page, int rows)
        {
            var list = new JiaJiBLL.stubll().showcounguihua();
            var result = new { total = list.Count, rows = list.OrderBy(e => e.TypeID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }
        [HttpPost]
        public JsonResult CountryGuiHuashow()
        {
            return Json(new JiaJiBLL.stubll().showcounguihua(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除留学规划
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteCountryGuiHua(string ids)
        {
            bool isOK = new JiaJiBLL.stubll().Delcounguihua(ids);
            if (isOK) return 0;
            else return 1;

        }

        /// <summary>
        /// 添加留学规划
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addCountryGuiHua(JiaJiModels.studentprogramtype model)
        {
            try
            {
                var i = new JiaJiBLL.stubll().addcounguihua(model);
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
        /// 修改留学规划
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editCountryGuiHua(JiaJiModels.studentprogramtype model)
        {
            try
            {
                int id = model.TypeID;

                var i = new JiaJiBLL.stubll().Updatecounguihua(model);
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

        #region 国家申请条件
        ///<summary>
        ///国家申请条件
        /// </summary>
        public ActionResult applycondition()
        {
            return View();
        }

        public JsonResult getapplycondition(int page, int rows)
        {
            var list = new JiaJiBLL.ApplyBLL().ShowApplyCondition();
            var result = new { total = list.Count, rows = list.OrderBy(e => e.ApplyID).Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }

        public JsonResult applyconditionshow()
        {
            return Json(new JiaJiBLL.ApplyBLL().ShowApplyCondition(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除国家申请条件
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteapplycondition(string ids)
        {
            bool isOK = new JiaJiBLL.ApplyBLL().DelApplyCondition(ids);

            if (isOK) return 0;
            else return 1;

        }

        /// <summary>
        /// 添加国家申请条件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addapplycondition(JiaJiModels.ApplyModel.ApplyCondition model)
        {
            try
            {
                var i = new JiaJiBLL.ApplyBLL().addApplyCondition(model);
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
        /// 修改国家申请条件
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editapplycondition(JiaJiModels.ApplyModel.ApplyCondition model)
        {
            try
            {
                int id = model.ApplyID;

                var i = new JiaJiBLL.ApplyBLL().UpdApplyCondition(model);
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



        ///<summary>
        ///国家申请内容
        /// </summary>
        public ActionResult ApplyContent()
        {
            return View();
        }

        public JsonResult getApplyContent(int page, int rows,int?CountryID=null, int? ApplyConditionID = null, int? EducationID = null)
        {
            var list = new JiaJiBLL.ApplyBLL().ShowApplyContent();
            var result = new
            {
                total = list.
             Where(e=>
              (CountryID == null ? true : e.CountryID == CountryID)
             && (EducationID == null ? true : e.EducationID == EducationID)
             && (ApplyConditionID == null ? true : e.ApplyConditionID == ApplyConditionID)
             ).Count(),
                rows = list.
             Where(e =>
             (CountryID == null ? true : e.CountryID == CountryID)
             && (EducationID == null ? true : e.EducationID == EducationID)
             && (ApplyConditionID == null ? true : e.ApplyConditionID == ApplyConditionID)
             ).Skip((page - 1) * rows).Take(rows)
            };


            //var result = new { total = list.Count, rows = list.Skip((page - 1) * rows).Take(rows) };
            return Json(result);
        }
        /// <summary>
        /// 删除国家申请内容
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int deleteApplyContent(string ids)
        {
            bool isOK = new JiaJiBLL.ApplyBLL().DelApplyContent(ids);

            if (isOK) return 0;
            else return 1;

        }

        /// <summary>
        /// 添加国家申请内容
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addApplyContent(JiaJiModels.ApplyModel.ApplyContentInfo model)
        {
            try
            {
                var i = new JiaJiBLL.ApplyBLL().addApplyContent(model);
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
        /// 修改国家申请内容
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult editApplyContent(JiaJiModels.ApplyModel.ApplyContentInfo model)
        {
            try
            {
                int id = model.ApplyID;

                var i = new JiaJiBLL.ApplyBLL().UpdApplyContent(model);
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