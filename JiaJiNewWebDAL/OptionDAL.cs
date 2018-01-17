using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using System.Data;
using JiaJiNewWeb.Common;
using MySql.Data.MySqlClient;

namespace JiaJiNewWebDAL
{
    public class OptionDAL:JiaJiNewWebIDAL.IOptionDAL
    {
        ///<summary>
        ///获取热度前六的观点
        /// </summary>
        public List<JiaJiNewWebModel.Option> HotOption()
        {
            try
            {
                string sql = "select * from `optioninfo` ORDER BY Date DESC LIMIT 6";
                List<JiaJiNewWebModel.Option> list = MySqlDB.GetList<JiaJiNewWebModel.Option>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
            
        }

        ///<summary>
        ///获取全部观点
        /// </summary>
        public List<JiaJiNewWebModel.Option> OptionList(int pageindex)
        {
            try
            {
                int pagesize = 5;
                string sql = "SELECT SQL_CALC_FOUND_ROWS * from `optioninfo` ORDER BY OptionHot DESC LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS();";
                List<JiaJiNewWebModel.Option> list = MySqlDB.GetList<JiaJiNewWebModel.Option>(sql, System.Data.CommandType.Text, null);
                foreach (var v in list)
                {
                    v.OptionContent = Help.Chinese(v.OptionContent);
                }
                foreach (var item in list)
                {
                    if (item.OptionContent.Length > 50)
                    {
                        item.OptionContent = item.OptionContent.Substring(0, 50) + "......";
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }

        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        public int GetRowCounts()
        {
            try
            {
                string sql2 = "select count(1) from optioninfo";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
                return i = i % 5 == 0 ? i / 5 : (i / 5) + 1;
            }
            catch(Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                return 0;
            }
        }
        ///<summary>
        ///观点详情
        /// </summary>
        public Option OptionShow(int Id)
        {
            try
            {
                string sql1 = "update `optioninfo` set OptionHot=OptionHot+1 where OptionID='" + Id + "'";
                MySqlDB.nonquery(sql1, CommandType.Text, null);
                string sql = "select * from `optioninfo` where OptionID='" + Id + "' ";
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                Option op = MySqlDB.fanshemodel<Option>(dt);
                //DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                //Option op = new Option();
                //op.OptionTitle = dt.Rows[0]["OptionTitle"].ToString();
                //op.OptionContent = dt.Rows[0]["OptionContent"].ToString();
                //op.Author = dt.Rows[0]["Author"].ToString();
                //op.Source = dt.Rows[0]["Source"].ToString();
                //op.Date = dt.Rows[0]["Date"].ToString();
                //op.OptionHot = (int)dt.Rows[0]["OptionHot"];
               
                return op;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
        }



        ///<summary>
        ///观点图片详情
        /// </summary>
        public List<JiaJiNewWebModel.Option> HotOptionImage()
        {
            try
            {
                string sql = "select OptionUrl from optioninfo  where OptionHot=(select max(OptionHot) from optioninfo) limit 1";
                List<JiaJiNewWebModel.Option> list = MySqlDB.GetList<JiaJiNewWebModel.Option>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }

        }



        ///<summary>
        ///上一个观点
        ///<para>Id:观点Id</para>
        /// </summary>
        public Option OptionPrev(int Id)
        {
            try
            {
                Option model = new Option();
                DataTable dt1 = MySqlDB.GetDataTable("select min(OptionID) from optioninfo", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.OptionTitle = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from optioninfo where OptionID <@Id order by OptionID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.OptionID = (int)dt.Rows[0]["OptionID"];
                    model.OptionTitle = dt.Rows[0]["OptionTitle"].ToString();
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
        ///下一个观点
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public Option OptionNext(int Id)
        {
            try
            {
                Option infor = new Option();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(OptionID) from optioninfo", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.OptionTitle = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from optioninfo  where OptionID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.OptionID = (int)dt.Rows[0]["OptionID"];
                    infor.OptionTitle = dt.Rows[0]["OptionTitle"].ToString();
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
