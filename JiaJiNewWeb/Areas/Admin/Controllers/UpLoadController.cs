using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;
using System.Text;

namespace JiaJiNewWeb.Areas.Admin.Controllers
{
    public class UpLoadController : Controller
    {
        // GET: UpLoad

        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost]
        public JsonResult Index()
        {
            try
            {
                var file = Request.Files;
                var referrer = Request.UrlReferrer;
                var savePath = ConfigurationManager.AppSettings["ImgUploadPath"].ToString();
                savePath = savePath.EndsWith("\\") ? savePath : (savePath + "\\");
                savePath = Server.MapPath(savePath);
                for (int i = 0; i < file.Count; i++)
                {
                    file[i].SaveAs(savePath + file[i].FileName);
                }
            }
            catch (Exception)
            {
                return Json(new { Success = false });
            }

            return Json(new { Success = true });
        }

        [ActionName("uploadimage")]
        public ActionResult UploadImage()
        {
            var action = Request["action"];
            var json = "";
            if (action == "config")
            {
                json = @"{""imageActionName"":""UploadImage"",""imageFieldName"": ""upfile"",""imageCompressEnable"":""true"",""imageCompressBorder"": 1600,""imageInsertAlign"": ""none"",""imageUrlPrefix"": """",""imageAllowFiles"": ["".png"", "".jpg"", "".jpeg"", "".gif"", "".bmp""]}";
            }
            else
            {
                var file = Request.Files["upfile"];
                var savePath = ConfigurationManager.AppSettings["ImgUploadPath"].ToString();
                savePath = savePath.EndsWith("\\") ? savePath : (savePath + "\\");

                //var newFileName = string.Concat(DateTime.Now.ToString("yy-MM-dd"), Path.GetExtension(file.FileName));
                //var savePath = Server.MapPath(relativePath);


                // 合成目标文件路径
                var srcFileName = savePath + file.FileName;

                // 保存图片
                file.SaveAs(srcFileName);

                var tvcMallImageUrl = "";

                // 上传图片到外网服务器
                tvcMallImageUrl = "";
                json = json + "{\"url\":\"" + tvcMallImageUrl + "\",";
                json = json + "\"state\":\"SUCCESS\"}";
            }

            return new ContentResult { ContentEncoding = Encoding.UTF8, ContentType = "application/json", Content = json };
        }
    }

}

