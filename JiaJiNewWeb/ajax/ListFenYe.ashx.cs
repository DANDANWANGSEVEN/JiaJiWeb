using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaJiNewWeb.ajax
{
    /// <summary>
    /// ListFenYe 的摘要说明
    /// </summary>
    public class ListFenYe : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ListName = context.Request["ListName"].ToString();
            int PageCount = Convert.ToInt32(context.Request["PageCount"]);
            int PageNum= Convert.ToInt32(context.Request["PageNum"]);
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}