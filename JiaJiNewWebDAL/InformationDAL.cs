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
    public class InformationDAL:JiaJiNewWebIDAL.IInformationDAL
    {
        /// <summary>
        /// 根据热度显示资讯列表（分页）
        /// </summary>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        public List<Information> GetInformationList(int pageindex)
         {
            try
            {
                int pagesize = 8;
                string sql = "SELECT SQL_CALC_FOUND_ROWS * FROM information ORDER BY InfoDate DESC LIMIT " + (pageindex - 1) * pagesize + ", " + pagesize + ";SELECT FOUND_ROWS(); ";
                List<Information> list = MySqlDB.GetList<Information>(sql, System.Data.CommandType.Text, null);
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
        public int GetRowCounts()
        {
            try
            {
                string sql2 = "select count(1) from information";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
                return i = i % 8 == 0 ? i / 8 : (i / 8) + 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取搜索结果的行数
        /// </summary>
        /// <param name="selcontent"></param>
        /// <returns></returns>
        public int SelectRowCounts(string selcontent)
        {
            try
            {
                string sql2 = "select count(1) from information where Title like '%"+selcontent+"%' or Content like '%"+ selcontent + "%' order by ReadCount DESC ";
                int i = MySqlDB.scalar(sql2, System.Data.CommandType.Text, null);
                return i = i % 8 == 0 ? i / 8 : (i / 8) + 1;
            }

            catch(Exception ex)
            {
                return 0;
            }

        }


        /// <summary>
        /// 根据国家ID分配热门资讯显示前6条
        /// </summary>
        /// <param name="countryid"></param>
        /// <returns></returns>
        public List<Information> GetInformationTopList(int countryid)
        {
            string sql = "select InformationID,Title,InfoDate from information where CountryID = "+countryid+ " ORDER BY InfoDate DESC LIMIT 6";
            List<Information> list = MySqlDB.GetList<Information>(sql, System.Data.CommandType.Text, null);

            if(list.Count!=0)
            {
                foreach (var item in list)
                {
                    if (item.Title.Length > 20)
                    {
                        item.Title = item.Title.Substring(0, 20);
                    }
                }
            }
            return list;
        }



        /// <summary>
        /// 热门资讯显示前6条
        /// </summary>
        /// <returns></returns>

        public List<Information> GetInformationTopList()
        {
            try
            {
                string sql = "select InformationID,Title,InfoDate from information order by InfoDate DESC LIMIT 6 ";
                List<Information> list = MySqlDB.GetList<Information>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        ///<summary>
        ///获取资讯详情
        ///informationID:资讯ID
        /// </summary>      
        public Information InformationShow(int InformationID)
        {
            try
            {
                string sql1 = "UPDATE information set ReadCount=ReadCount+1 where InformationID=@Id";
                string sql = "select * from information where InformationID=@Id";
                MySqlParameter[] para = {
                new MySqlParameter("@Id",InformationID)
            };
                MySqlDB.nonquery(sql1, CommandType.Text, para);
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                Information info = new Information();
                info.InformationID = (int)dt.Rows[0]["InformationID"];
                info.Title = dt.Rows[0]["Title"].ToString();
                info.content = dt.Rows[0]["Content"].ToString();
                info.InfoDate = dt.Rows[0]["InfoDate"].ToString();
                info.Source = dt.Rows[0]["Source"].ToString();
                info.Author = dt.Rows[0]["Author"].ToString();
                info.ReadCount = (int)dt.Rows[0]["ReadCount"];
                info.InfoKeyWord = dt.Rows[0]["InfoKeyWord"].ToString();
                info.InformationImgUrl= dt.Rows[0]["InformationImgUrl"].ToString();

                Log4netHelper.WriteLog("日志报告");
                return info;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                return null;
            }

        }

        /// <summary>
        /// 北京资讯
        /// </summary>
        /// <returns></returns>
        public List<Information> GetBeiJingInfor()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select InformationID,Title,InfoDate,areases.AreaName from information ");
                sql.Append(" left join areases on information.site=areases.AreaID ");
                sql.Append(" where areases.AreaName='北京' order by InfoDate DESC LIMIT 6 ");
                List<Information> list = MySqlDB.GetList<Information>(sql.ToString(), System.Data.CommandType.Text, null);
                //foreach (var item in list)
                //{
                //    if (item.Title.Length > 14)
                //    {
                //        item.Title = item.Title.Substring(0, 14);
                //    }
                //}
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// xian资讯
        /// </summary>
        /// <returns></returns>
        public List<Information> GetXiAnInfor()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select InformationID,Title,InfoDate,areases.AreaName from information ");
                sql.Append(" left join areases on information.site=areases.AreaID ");
                sql.Append(" where areases.AreaName='西安' order by InfoDate DESC LIMIT 6 ");

                List<Information> list = MySqlDB.GetList<Information>(sql.ToString(), System.Data.CommandType.Text, null);
                foreach (var item in list)
                {
                    if (item.Title.Length > 14)
                    {
                        item.Title = item.Title.Substring(0, 14);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// 搜索关键字
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.Home.SearchDetails> Select(JiaJiNewWebModel.Home.selectmodel model)
        {
            try
            {
                StringBuilder sqlstring = new StringBuilder();

                sqlstring.Append(" select ActiveID,ActiveTitle,Datails,'active' as activetable  from  active  where  ActiveTitle like '%"+ model.Activetable.ActiveTitle + "%'  or Datails like '%"+ model.Activetable.Datails + "%' ");
                sqlstring.Append(" union ALL ");
                sqlstring.Append(" select InformationID,Title,Content,'information' as infortable  from  information  where  Title like '%"+ model.Infortable.Title + "%'  or Content like '%"+ model.Infortable.content + "%' ");
                sqlstring.Append(" union ALL ");
                sqlstring.Append(" select StrategyID,StrategyTitle,StrategyProfile,'strategy' as strategytable  from  strategy   where  StrategyTitle like '%" + model.Strategytable.StrategyTitle + "%'  or StrategyContent like '%"+ model.Strategytable.StrategyProfile + "%' ");
                sqlstring.Append(" union ALL ");
                sqlstring.Append(" select NavID,NavTitleTwo,NavContentOne,'nav' as navtable from navinfo where NavTitleTwo='%"+model.Navtable.NavTitleTwo+"%' or NavContentOne='%"+model.Navtable.NavContentOne+"%' ");

                List<JiaJiNewWebModel.Home.SearchDetails> list = MySqlDB.GetList<JiaJiNewWebModel.Home.SearchDetails>(sqlstring.ToString(), System.Data.CommandType.Text, null);
               
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        
        }

        ///<summary>
        ///上一个留学资讯
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public Information InforPrev(int Id)
        {
            try
            {
                Information model = new Information();
                DataTable dt1 = MySqlDB.GetDataTable("select min(InformationID) from information", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.Title = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from information where InformationID <@Id order by InformationID desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.InformationID = (int)dt.Rows[0]["InformationID"];
                    model.Title = dt.Rows[0]["Title"].ToString();
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
        ///下一个留学资讯
        ///<para>Id:成功案列Id</para>
        /// </summary>
        public Information InforNext(int Id)
        {
            try
            {
                Information infor = new Information();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(InformationID) from information", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.Title = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from information  where InformationID >@Id LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.InformationID = (int)dt.Rows[0]["InformationID"];
                    infor.Title = dt.Rows[0]["Title"].ToString();
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
