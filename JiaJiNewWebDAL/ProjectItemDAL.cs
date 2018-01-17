using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWeb.Common;

using System.Text.RegularExpressions;
using System.Data;
using MySql.Data.MySqlClient;

namespace JiaJiNewWebDAL
{
   public class ProjectItemDAL:JiaJiNewWebIDAL.IProjectItemDAL
    {
        /// <summary>
        /// 获取项目列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.projectItem> GetProductList()
        {
            
            try
            {
                string sql = "select  * from projectItem ";

                List<JiaJiNewWebModel.projectItem> list = MySqlDB.GetList<JiaJiNewWebModel.projectItem>(sql, System.Data.CommandType.Text, null);
                Log4netHelper.WriteLog("系统日志，请求了ProjectItemDAL类下的GetProductList方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ProjectItemDAL类下的GetProductList方法", ex);
                return null;

            }
        }


        /// <summary>
        /// 获取项目对应的图片
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.projectItem> GetProImgList(int proid)
        {

            try
            {
                
               string sql = "select  * from projectItem where Pro_ID="+proid+" ";

                List<JiaJiNewWebModel.projectItem> list = MySqlDB.GetList<JiaJiNewWebModel.projectItem>(sql, System.Data.CommandType.Text, null);
                Log4netHelper.WriteLog("系统日志，请求了ProjectItemDAL类下的GetProductList方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ProjectItemDAL类下的GetProductList方法", ex);
                return null;

            }
        }


        /// <summary>
        /// 获取项目对应学员分享的内容列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Share> GetShareList(int id)
        {

            try
            {
                string sql = "select ShareID,ShareTitle,ShareContent,ShareImg,ShareDate,Pro_Img,ProactiveImg1,ProactiveImg2,ShareKeyword,ShareProfile from Shares LEFT JOIN projectitem on shares.Pro_ID=projectitem.Pro_ID where Shares.pro_ID=" + id+" limit 3 ";

                List<JiaJiNewWebModel.Share> list = MySqlDB.GetList<JiaJiNewWebModel.Share>(sql, System.Data.CommandType.Text, null);

                //foreach (var item in list)
                //{
                //    if (item.ShareTitle.Length > 14)
                //    {
                //        item.ShareTitle = item.ShareTitle.Substring(0, 14);
                //    }
                //    if(item.ShareContent.Length>36)
                //    {
                //        item.ShareContent = item.ShareContent.Substring(0, 34);
                //    }
                //}
                Log4netHelper.WriteLog("系统日志，请求了ProjectItemDAL类下的GetShareList方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ProjectItemDAL类下的GetShareList方法", ex);
                return null;

            }


        }

        /// <summary>
        /// 获取分享详情
        /// </summary>
        /// <returns></returns>
        public JiaJiNewWebModel.Share GetShareContent(int shareid)
        {

            try
            {

                string sql1 = "update Shares set ShareReadCount=ShareReadCount+1 where ShareID=@Id ";
                string sql = "select ShareID,ShareTitle,ShareContent,ShareImg,ShareDate,Pro_Img,ProactiveImg1,ProactiveImg2,Shares.LearnerID,LearnName,Pro_Name,shares.Pro_ID,ShareProfile,ShareKeyword,ShareReadCount from Shares LEFT JOIN projectitem on shares.Pro_ID=projectitem.Pro_ID left join learner on learner.LearnerID=Shares.LearnerID where Shares.ShareID=@Id ";
                MySqlParameter[] para = {
                new MySqlParameter("@Id",shareid)
            };
                MySqlDB.nonquery(sql1, CommandType.Text, para);
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                JiaJiNewWebModel.Share model = new JiaJiNewWebModel.Share();
                model.ShareID = (int)dt.Rows[0]["ShareID"];
                model.ShareTitle = dt.Rows[0]["ShareTitle"].ToString();
                model.ShareContent = dt.Rows[0]["ShareContent"].ToString();
                model.ShareImg = dt.Rows[0]["ShareImg"].ToString();
                model.ShareDate =dt.Rows[0]["ShareDate"].ToString();
                model.Pro_Img = dt.Rows[0]["Pro_Img"].ToString();
                model.ProactiveImg1 = dt.Rows[0]["ProactiveImg1"].ToString();
                model.ProactiveImg2 = dt.Rows[0]["ProactiveImg2"].ToString();
                model.LearnerID =Convert.ToInt32(dt.Rows[0]["LearnerID"]);
                model.LearnName = dt.Rows[0]["LearnName"].ToString();
                model.Pro_Name = dt.Rows[0]["Pro_Name"].ToString();
                model.Pro_ID = (int)dt.Rows[0]["Pro_ID"];
                model.LearnerID =Convert.ToInt32( dt.Rows[0]["LearnerID"]);
                model.ShareProfile = dt.Rows[0]["ShareProfile"].ToString(); 
                model.ShareKeyword = dt.Rows[0]["ShareKeyword"].ToString();
                model.ShareReadCount = Convert.ToInt32(dt.Rows[0]["ShareReadCount"]);

                Log4netHelper.WriteLog("系统日志，请求了ProjectItemDAL类下的GetShareList方法");
                return model;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ProjectItemDAL类下的GetShareList方法", ex);
                return null;

            }


        }
        ///<summary>
        ///上一个分享
        ///<para>Id:分享Id</para>
        /// </summary>
        public JiaJiNewWebModel.Share SharePrev(int Id)
        {
            try
            {
                JiaJiNewWebModel.Share model = new JiaJiNewWebModel.Share();
                DataTable dt1 = MySqlDB.GetDataTable("select min(ShareID) from shares", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.ShareTitle = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from shares where ShareID <@Id order by ShareID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.ShareID = (int)dt.Rows[0]["ShareID"];
                    model.ShareTitle = dt.Rows[0]["ShareTitle"].ToString();
                    Log4netHelper.WriteLog("日志报告");
                    return model;
                }

            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }

        ///<summary>
        ///下一个分享
        ///<para>Id:分享Id</para>
        /// </summary>
        public JiaJiNewWebModel.Share ShareNext(int Id)
        {
            try
            {
                JiaJiNewWebModel.Share infor = new JiaJiNewWebModel.Share();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(ShareID) from shares", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.ShareTitle = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from shares where ShareID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.ShareID = (int)dt.Rows[0]["ShareID"];
                    infor.ShareTitle = dt.Rows[0]["ShareTitle"].ToString();
                    Log4netHelper.WriteLog("日志报告");
                    return infor;

                }
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }


        /// <summary>
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public int GetShareRowCounts()
        {
            try
            {
                string sql2 = "select count(1) from shares";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
                return i = i % 8 == 0 ? i / 8 : (i / 8) + 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取所有的学员分享
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Share> GetAllShareList(int pageindex)
        {

            try
            {
                int pagesize = 8;
                string sql = "SELECT SQL_CALC_FOUND_ROWS * FROM shares ORDER BY ShareID DESC LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS(); ";
                List<JiaJiNewWebModel.Share> list = MySqlDB.GetList<JiaJiNewWebModel.Share>(sql, System.Data.CommandType.Text, null);
                //Regex reg = new Regex("[\u4e00-\u9fa5]+");
                //foreach (var item in list)
                //{
                //    foreach (Math v in reg.Matches(item.Content))
                //    {
                //        item.Content = v.ToString();
                //    }
                //}
                //提取汉字
                string pattern = @"^[\u300a\u300b]|[\u4e00-\u9fa5]|[\uFF00-\uFFEF]";
                foreach (var item in list)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(item.ShareContent, pattern))
                    {
                        //提示的代码在这里写
                        Match m = Regex.Match(item.ShareContent, pattern);
                        item.ShareContent = "";
                        while (m.Success)
                        {
                            if (m.Value == ",")
                            {
                                item.ShareContent += m.Value;
                                continue;
                            }
                            item.ShareContent += m.Value;
                            m = m.NextMatch();
                        }
                    }
                }

                foreach (var item in list)
                {
                    if (item.ShareContent.Length > 50)
                    {
                        item.ShareContent = item.ShareContent.ToString().Substring(0, 25);
                    }
                }

                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ProjectItemDAL类下的GetShareList方法", ex);
                return null;

            }


        }


        /// <summary>
        /// 获取首加载时
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Share> GetFirstList()
        {

            try
            {
                string sql = "select  * from Shares where pro_ID=1";

                List<JiaJiNewWebModel.Share> list = MySqlDB.GetList<JiaJiNewWebModel.Share>(sql, System.Data.CommandType.Text, null);

                foreach (var item in list)
                {
                    if (item.ShareTitle.Length > 14)
                    {
                        item.ShareTitle = item.ShareTitle.Substring(0, 14);
                    }
                    if (item.ShareContent.Length > 36)
                    {
                        item.ShareContent = item.ShareContent.Substring(0, 34);
                    }
                }
                Log4netHelper.WriteLog("系统日志，请求了ProjectItemDAL类下的GetShareList方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ProjectItemDAL类下的GetShareList方法", ex);
                return null;

            }


        }



    }
}
