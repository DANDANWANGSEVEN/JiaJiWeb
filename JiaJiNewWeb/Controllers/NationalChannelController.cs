using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JiaJiNewWebBLL;
using JiaJiNewWebModel;
using Newtonsoft.Json;
namespace JiaJiNewWeb.Controllers
{
    public class NationalChannelController : Controller
    {
        // GET: NationalChannel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">国家ID</param>
        /// <returns></returns>

        public ActionResult NationalChannel(int id)
        {
            ViewBag.id = id;
            //ViewBag.countryname = new SuccessFulRelationBLL().GetCountry(id);
            List<Country> countryyoushi = new SuccessFulRelationBLL().GetCountry(id);
            ViewBag.countryyoushilist = countryyoushi;
            List<EducationType> list = new SuccessFulRelationBLL().GetEducationType();
            string a = string.Empty;

            //留学规划右侧
            var list1= new SPRelationBLL().GetProgramBy(id, 1);
            list1.ForEach(e=> {
                e.StudentProgramContent = HtmlRemove.RemoveHTMLTags(e.StudentProgramContent);
            });
            ViewBag.list1 = list1;
            ViewBag.list2 = new SPRelationBLL().GetProgramBy(id, 2);   


            ViewBag.zixun = new InformationBLL().GetInformationTopList(id);  //获取资讯信息
            ViewBag.countryzixun = new JiaJiNewWebBLL.LunBoImageBLL().CountryZiXunImage(id); //获取国家页面资讯图片


            ViewBag.huodong = new ActiveBLL().ActiveLsitIndex(id); //获取活动信息

            ViewBag.dominant = new DominantBLL().GetDominant(id);//获取优势

            //国家轮播图
            ViewBag.LunBoyanjiu = new LunBoImageBLL().LunBoList(id,1);
            string image = "";
            if ((ViewBag.LunBoyanjiu as List<LunBoImageModel>).Count != 0)
                foreach (var item in ViewBag.LunBoyanjiu)
                    image += item.ImageUrl + ",";
            if (image != "") image = image.Substring(0, image.Length - 1);
            ViewBag.image = image;

            ViewBag.LunBoBenke = new LunBoImageBLL().LunBoList(id,2);
            string image1 = "";
            if ((ViewBag.LunBoBenke as List<LunBoImageModel>).Count != 0)
                foreach (var item in ViewBag.LunBoBenke)
                    image1 += item.ImageUrl + ",";
            if (image1 != "") image1 = image1.Substring(0, image1.Length - 1);
            ViewBag.image1 = image1;

            ViewBag.LunBoGaozhong = new LunBoImageBLL().LunBoList(id,3);
            string image2 = "";
            if ((ViewBag.LunBoGaozhong as List<LunBoImageModel>).Count != 0)
                foreach (var item in ViewBag.LunBoGaozhong)
                    image2 += item.ImageUrl + ",";
            if (image2 != "") image2 = image2.Substring(0, image2.Length - 1);
            ViewBag.image2 = image2;

            //非轮播图显示
            ViewBag.NoLunBoYanJiu = new LunBoImageBLL().NoLunBoList(id,1);
            ViewBag.NoLunBoBenke = new LunBoImageBLL().NoLunBoList(id, 2);
            ViewBag.NoLunBoGaozhong = new LunBoImageBLL().NoLunBoList(id, 3);


            //时间规划
            ViewBag.ArrangeYanJiu = new StudentProgramBLL().ArrangeShow(id,1);  //研究生
            ViewBag.ArrangeBenKe = new StudentProgramBLL().ArrangeShow(id, 2); //本科
            ViewBag.ArrangeGaoZhong = new StudentProgramBLL().ArrangeShow(id, 3);  //高中

            //申请条件
            ViewBag.ApplyYanjiu = new StudentProgramBLL().ApplyShow(id, 1);  //研究生
            ViewBag.ApplyBenKe = new StudentProgramBLL().ApplyShow(id, 2);   //本科
            ViewBag.ApplyGaoZhong = new StudentProgramBLL().ApplyShow(id, 3); //高中


            //留学规划
            ViewBag.TypeShow = new StudentProgramBLL().TypeShow();
         

            string countryname = "";
            switch (id)
            {
                case 1:
                    countryname = "美国";
                    break;
                case 2:
                    countryname = "加拿大";
                    break;
                case 3:
                    countryname = "英国";
                    break;
                case 4:
                    countryname = "澳洲";
                    break;
            }

            List<JiaJiNewWebModel.TeamIndexModel> termList = new JiaJiNewWebBLL.TeamBLL().CountryTeamList(countryname); //精英团队信息
            ViewBag.teamList = termList;
            return View();
        }

        public static List<JiaJiNewWebModel.LunBoImageModel> LunBoImgShow(int id,int educationid)
        {
            JiaJiNewWebBLL.LunBoImageBLL lunbo = new JiaJiNewWebBLL.LunBoImageBLL();

            return lunbo.LunBoList(id, educationid);
        }


        /// <summary>
        /// 获取学生的信息列表
        /// </summary>
        /// <param name="index"></param>
        /// <param name="goIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public string StudentList(int id, int index, int goIndex)
        {
            
            List<JiaJiNewWebModel.StudentIndexModel> studentList = new JiaJiNewWebBLL.StudentBLL().CountryStuList(id, index, goIndex); //获取学生的信息
            return JsonConvert.SerializeObject(studentList);


        }



    }
}