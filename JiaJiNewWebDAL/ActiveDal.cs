using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using JiaJiNewWeb.Common;
using System.Data;
using MySql.Data.MySqlClient;

namespace JiaJiNewWebDAL
{
    /// <summary>
    /// 活动表
    /// </summary>
  public  class ActiveDal:JiaJiNewWebIDAL.IActiveDal
    {
        
        /// <summary>
        /// 获取活动列表
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveLsit()
        {
            string sql = "select * from active ORDER BY ActiveDate DESC";
            //string sql = "select * from active left join areases on active.Site=areases.AreaID ORDER BY HeatID DESC ";
            List<Active> list = MySqlDB.GetList<Active>(sql,System.Data.CommandType.Text,null);
            return list;
        }
        /// <summary>
        /// 获取活动列表,显示点击热度最高的前五条
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public List<Active> ActiveLsitIndex(int countryid)
        {
            //string sql = "select ActiveID,ActiveTitle,ActiveDate,Site from active WHERE CountryID="+countryid+" ORDER BY HeatID DESC LIMIT 5";
           
            string sql = "select ActiveID,ActiveTitle,ActiveDate,AreaName from active left join areases on active.Site=areases.AreaID  WHERE CountryID=" + countryid + " ORDER BY ActiveDate DESC LIMIT 5";
            List<Active> list = MySqlDB.GetList<Active>(sql,System.Data.CommandType.Text, null);

            if(list.Count!=0)
            {
                foreach (var item in list)
                {
                    if (item.ActiveTitle.Length > 14)
                    {
                        item.ActiveTitle = item.ActiveTitle.Substring(0, 14);
                    }
                }
            }
            return list;
        }

        /// 获取具体活动列表
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveList(int pageindex)
        {
            try
            {
                int pagesize = 5;
                string sql = "SELECT SQL_CALC_FOUND_ROWS * FROM active left join areases on active.Site=areases.AreaID  ORDER BY HeatID DESC LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS(); ";

                List<Active> list = MySqlDB.GetList<Active>(sql, System.Data.CommandType.Text, null);

                if(list.Count!=0)
                {
                    foreach (var v in list)
                    {
                        v.Datails = Help.Chinese(v.Datails);
                    }
                    foreach (var item in list)
                    {
                        if (item.Datails.Length > 65)
                        {
                            item.Datails = item.Datails.Substring(0, 65) + "......";
                        }
                    }
                }
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts()
        {
            string sql2 = "select count(1) from active";
            int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
            return i = i % 5 == 0 ? i / 5 : (i / 5) + 1;
        }


        /// <summary>
        /// 获取活动列表,显示点击热度最高的前五条
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveLsitIndex()
        {
            try
            {
                string sql = "select ActiveID,ActiveTitle,ActiveDate,areases.AreaName from active left join areases on active.Site=areases.AreaID ORDER BY ActiveDate DESC LIMIT 6";

                List<Active> list = MySqlDB.GetList<Active>(sql, System.Data.CommandType.Text, null);

                foreach (var item in list)
                {
                    if (item.ActiveTitle.Length > 14)
                    {
                        item.ActiveTitle = item.ActiveTitle.Substring(0, 14);
                    }

                }
                Log4netHelper.WriteLog("系统日志，请求了ActiveDal类下的ActiveLsitIndex方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;

            }

        }


        /// <summary>
        /// 根据日期获取嘉际北京最新活动
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveLsitBeiJing()
        {
            try
            {
                string sql = "select ActiveID,ActiveTitle,ActiveDate,areases.AreaName from active left join areases on active.Site=areases.AreaID where AreaName='北京' ORDER BY ActiveDate DESC LIMIT 6";

                List<Active> list = MySqlDB.GetList<Active>(sql, System.Data.CommandType.Text, null);

                foreach (var item in list)
                {
                    if (item.ActiveTitle.Length > 14)
                    {
                        item.ActiveTitle = item.ActiveTitle.Substring(0, 14);
                    }

                }
                Log4netHelper.WriteLog("系统日志，请求了ActiveDal类下的ActiveLsitIndex方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;

            }

        }


        /// <summary>
        /// 根据日期获取嘉际xian最新活动
        /// </summary>
        /// <returns></returns>
        public List<Active> ActiveLsitXiAn()
        {
            try
            {
                string sql = "select ActiveID,ActiveTitle,ActiveDate,areases.AreaName from active left join areases on active.Site=areases.AreaID where AreaName='西安' ORDER BY ActiveDate DESC LIMIT 6";

                List<Active> list = MySqlDB.GetList<Active>(sql, System.Data.CommandType.Text, null);

                foreach (var item in list)
                {
                    if (item.ActiveTitle.Length > 14)
                    {
                        item.ActiveTitle = item.ActiveTitle.Substring(0, 14);
                    }

                }
                Log4netHelper.WriteLog("系统日志，请求了ActiveDal类下的ActiveLsitIndex方法");
                return list;
            }
            catch (System.Exception ex)
            {
                Log4netHelper.WriteLog("错误信息：请求了ActiveDal类下的ActiveLsitIndex方法", ex);
                return null;

            }

        }


        ///// <summary>
        ///// 根据热度显示资讯列表（分页）
        ///// </summary>
        ///// <param name="pageindex"></param>
        ///// <returns></returns>
        //public List<Information> GetInformationList(int pageindex, int pagesize, out int rowcounts)
        //{
        //    string sql = "SELECT SQL_CALC_FOUND_ROWS * FROM information ORDER BY ReadCount DESC LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS(); ";
        //    List<Information> list = MySqlDB.GetList<Information>(sql, System.Data.CommandType.Text, null);
        //    foreach (var item in list)
        //    {
        //        if (item.Content.Length > 50)
        //        {
        //            item.Content = item.Content.ToString().Substring(0, 25);
        //        }
        //    }
        //    string sql2 = "select count(1) from information";
        //    rowcounts = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
        //    return list;
        //}


        /// <summary>
        /// 活动详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Active ActiveShow(int Id)
        {
            try
            {
                string sql1 = "update active set HeatID=HeatID+1 where ActiveID=@Id ";
                string sql = "select * from active left join areases on active.Site=areases.AreaID where ActiveID=@Id";
                MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                MySqlDB.nonquery(sql1, CommandType.Text, para);
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                Active active = new Active();
                active.ActiveID = (int)dt.Rows[0]["ActiveID"];
                active.ActiveTitle = dt.Rows[0]["ActiveTitle"].ToString();
                active.ActiveDate =dt.Rows[0]["ActiveDate"].ToString();
                active.Site =Convert.ToInt32(dt.Rows[0]["Site"]);
                active.Datails = dt.Rows[0]["Datails"].ToString();
                active.ActivePhone = dt.Rows[0]["ActivePhone"].ToString();
                active.HeatID = (int)dt.Rows[0]["HeatID"];
                active.AreaID= (int)dt.Rows[0]["AreaID"];
                active.AreaName = dt.Rows[0]["AreaName"].ToString();
                active.ActiveKeyWord = dt.Rows[0]["ActiveKeyWord"].ToString();

                Log4netHelper.WriteLog("日至报告");
                return active;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误日志", ex);
                return null;
            }

        }

        
        /// <summary>
        /// 根据国家学历查询申请条件
        /// </summary>
        /// <returns></returns>
        public List<AppCounRela> ACEList(int countryid,int educationid)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select ApplyTitle,ApplyContent,CountryName,EducationName from appcounrela ");
                sql.Append(" left join applycondition on applycondition.ApplyID=appcounrela.ApplyID ");
                sql.Append(" left join country on appcounrela.CountryID=country.CountryID ");
                sql.Append(" left join educationtype on appcounrela.EducationID=educationtype.EducationID ");
                sql.Append(" where country.CountryID=1 and educationtype.EducationID=3 LIMIT 4 ");

                List<AppCounRela> list = MySqlDB.GetList<AppCounRela>(sql.ToString(), System.Data.CommandType.Text, null);

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        ///<summary>
        ///上一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        public JiaJiNewWebModel.Active activePrev(int Id)
        {
            try
            {
                Active model = new Active();
                DataTable dt1 = MySqlDB.GetDataTable("select min(ActiveID) from active", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.ActiveTitle = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from active left join areases on active.Site=areases.AreaID where ActiveID <@Id order by ActiveID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.ActiveID = (int)dt.Rows[0]["ActiveID"];
                    model.ActiveTitle = dt.Rows[0]["ActiveTitle"].ToString();
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
        ///下一个活动
        ///<para>Id:活动Id</para>
        /// </summary>
        public JiaJiNewWebModel.Active activeNext(int Id)
        {
            try
            {
                Active infor = new Active();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(ActiveID) from active", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.ActiveTitle = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from active left join areases on active.Site=areases.AreaID where ActiveID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.ActiveID = (int)dt.Rows[0]["ActiveID"];
                    infor.ActiveTitle = dt.Rows[0]["ActiveTitle"].ToString();
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


    }
}
