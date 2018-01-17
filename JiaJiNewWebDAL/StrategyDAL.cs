using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using System.Data;

using MySql.Data.MySqlClient;
using JiaJiNewWeb.Common;
using System.Text.RegularExpressions;

namespace JiaJiNewWebDAL
{
   public class StrategyDAL:JiaJiNewWebIDAL.IStrategyDAL
    {


        /// <summary>
        /// 根据日期显示策略（分页）
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public List<Strategy> GetStrategyList(int pageindex)
        {
            try
            {
                int pagesize = 8;
                string sql = "SELECT SQL_CALC_FOUND_ROWS * FROM strategy left join country on strategy.CountryID=country.CountryID  ORDER BY StrategyDate desc  LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS(); ";
                List<Strategy> list = MySqlDB.GetList<Strategy>(sql, System.Data.CommandType.Text, null);

                //提取汉字
                string pattern = @"^[\u300a\u300b]|[\u4e00-\u9fa5]|[\uFF00-\uFFEF]";
                foreach (var item in list)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(item.StrategyContent, pattern))
                    {
                        //提示的代码在这里写
                        Match m = Regex.Match(item.StrategyContent, pattern);
                        item.StrategyContent = "";
                        while (m.Success)
                        {
                            if (m.Value == ",")
                            {
                                item.StrategyContent += m.Value;
                                continue;
                            }
                            item.StrategyContent += m.Value;
                            m = m.NextMatch();
                        }
                    }
                }

                foreach (var item in list)
                {
                    if (item.StrategyContent.Length > 50)
                    {
                        item.StrategyContent = item.StrategyContent.ToString().Substring(0, 25);
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
        /// 获取行数
        /// </summary>
        /// <returns></returns>
        public int GetStraRowCounts()
        {
            try
            {
                string sql2 = "select count(1) from strategy";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
                return i = i % 8 == 0 ? i / 8 : (i / 8) + 1;

            }
            catch(Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 获取申请攻略的信息
        /// </summary>
        /// <param name="contryid"></param>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Strategy> StrategeIndexList(int contryid)
        {

            string sql = "select  * from Strategy where CountryID="+contryid+"   ORDER BY strategyid  DESC LIMIT 3";

            List<JiaJiNewWebModel.Strategy> list = MySqlDB.GetList<JiaJiNewWebModel.Strategy>(sql, System.Data.CommandType.Text, null);

            //foreach (var item in list)
            //{
            //    if (item.StrategyTitle.Length > 14)
            //    {
            //        item.StrategyTitle = item.StrategyTitle.Substring(0, 14);
            //        item.StrategyProfile = item.StrategyProfile.Substring(0, 28);

            //    }
            //}
            return list;
        }


        ///<summary>
        ///攻略详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Strategy StrategyShow(int Id)
        {
            try
            {
                string sql = "update strategy set StrategyReadCount=StrategyReadCount+1 where StrategyID="+ Id + ";";
                sql += "select * from strategy where StrategyID=" + Id + "";
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                Strategy strategy = new Strategy();
                strategy.StrategyTitle = dt.Rows[0]["StrategyTitle"].ToString();
                strategy.StrategyDate = dt.Rows[0]["StrategyDate"].ToString();
                strategy.StrategyProfile= dt.Rows[0]["StrategyProfile"].ToString();
                strategy.StrategyKeyWord= dt.Rows[0]["StrategyKeyWord"].ToString();
                strategy.StrategyReadCount =Convert.ToInt32(dt.Rows[0]["StrategyReadCount"]);
                strategy.StrategyAuthor = dt.Rows[0]["StrategyAuthor"].ToString();
                strategy.StrategyContent = dt.Rows[0]["StrategyContent"].ToString();
                strategy.Img = dt.Rows[0]["Img"].ToString();
                Log4netHelper.WriteLog("日志报告");
                return strategy;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }


        ///<summary>
        ///上一个攻略
        ///<para>Id:攻略Id</para>
        /// </summary>
        public JiaJiNewWebModel.Strategy StrategyPrev(int Id)
        {
            try
            {
                Strategy model = new Strategy();
                DataTable dt1 = MySqlDB.GetDataTable("select min(StrategyID) from strategy", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.StrategyTitle = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from strategy where StrategyID <@Id order by StrategyID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.StrategyID = (int)dt.Rows[0]["StrategyID"];
                    model.StrategyTitle = dt.Rows[0]["StrategyTitle"].ToString();
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
        public JiaJiNewWebModel.Strategy StrategyNext(int Id)
        {
            try
            {
                Strategy infor = new Strategy();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(StrategyID) from strategy", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.StrategyTitle = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from strategy where StrategyID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.StrategyID= (int)dt.Rows[0]["StrategyID"];
                    infor.StrategyTitle = dt.Rows[0]["StrategyTitle"].ToString();
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
