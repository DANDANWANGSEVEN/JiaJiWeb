using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebIDAL;
using JiaJiNewWebModel;
using System.Data;
using MySql.Data.MySqlClient;
using JiaJiNewWeb.Common;

namespace JiaJiNewWebDAL
{
    public class NavInfoDAL : INavInfo
    {
        public bool AddByModel(NavInfoModel model)
        {
            bool res = false;
            try
            {
                string sql = "insert into NavInfo (NavTitleOne,NavContentOne,NavParentID,NavTypeID,NavIsLevel,NavDate,NavCreateBy,NavHeat ,NavTitleTwo,NavContentTwo,GuoJia,BuWei,PaiXu,depth,LinkFor,KeyWord) Values (@NavTitleOne,@NavContentOne,@NavParentID,@NavTypeID,@NavIsLevel,@NavDate,@NavCreateBy,@NavHeat,@NavTitleTwo,@NavContentTwo,@GuoJia,@BuWei,@PaiXu,@depth,@LinkFor,@KeyWord)";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavTitleOne",model.NavTitleOne),
                    new MySqlParameter("@NavContentOne",model.NavContentOne),
                    new MySqlParameter("@NavParentID",model.NavParentId),
                    new MySqlParameter("@NavTypeID",model.NavType),
                    new MySqlParameter("@NavIsLevel",model.NavIsLevel),
                    new MySqlParameter("@NavDate",model.NavDate),
                    new MySqlParameter("@NavCreateBy",model.NavCreateBy),
                    new MySqlParameter("@NavHeat",model.NavHeat),
                    new MySqlParameter("@NavTitleTwo",model.NavTitleTwo),
                    new MySqlParameter("@NavContentTwo",model.NavContentTwo),
                    new MySqlParameter("@GuoJia",model.GuoJia),
                    new MySqlParameter("@BuWei",model.BuWei),
                    new MySqlParameter("@PaiXu",model.PaiXu),
                    new MySqlParameter("@depth",model.Depth),
                    new MySqlParameter("@LinkFor",model.LinkFor),
                    new MySqlParameter("@KeyWord",model.KeyWord)
                };
                int n = MySqlDB.nonquery(sql, CommandType.Text, para);
                if (n > 0)
                    res = true;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
            return res;
        }

        public bool DeleteByModel(NavInfoModel model)
        {
            bool res = false;
            try
            {
                string sql = "delete from NavInfo where NavID=@NavID";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavID",model.NavId)
                };
                int n = MySqlDB.nonquery(sql, CommandType.Text, para);
                if (n > 0)
                    res = true;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
            return res;
        }

        public bool EditByModel(NavInfoModel model)
        {
            bool res = false;
            try
            {
                string sql = "update NavInfo set NavTitleOne=@NavTitleOne,NavContentOne=@NavContentOne,NavParentID=@NavParentID,NavTypeID=@NavTypeID,NavIsLevel=@NavIsLevel,NavDate=@NavDate,NavCreateBy=@NavCreateBy,NavHeat=@NavHeat,NavTitleTwo=@NavTitleTwo,NavContentTwo=@NavContentTwo,GuoJia=@GuoJia,BuWei=@BuWei,PaiXu=@PaiXu,depth=@depth,LinkFor=@LinkFor,KeyWord=@KeyWord   where NavID=@NavID";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavID",model.NavId),
                    new MySqlParameter("@NavTitleOne",model.NavTitleOne),
                    new MySqlParameter("@NavContentOne",model.NavContentOne),
                    new MySqlParameter("@NavParentID",model.NavParentId),
                    new MySqlParameter("@NavTypeID",model.NavType),
                    new MySqlParameter("@NavIsLevel",model.NavIsLevel),
                    new MySqlParameter("@NavDate",model.NavDate),
                    new MySqlParameter("@NavCreateBy",model.NavCreateBy),
                    new MySqlParameter("@NavHeat",model.NavHeat),
                    new MySqlParameter("@NavTitleTwo",model.NavTitleTwo),
                    new MySqlParameter("@NavContentTwo",model.NavContentTwo),
                    new MySqlParameter("@GuoJia",model.GuoJia),
                    new MySqlParameter("@BuWei",model.BuWei),
                    new MySqlParameter("@PaiXu",model.PaiXu),
                    new MySqlParameter("@depth",model.Depth),
                    new MySqlParameter("@LinkFor",model.LinkFor),
                    new MySqlParameter("@KeyWord",model.KeyWord)
                };
                int n = MySqlDB.nonquery(sql, CommandType.Text, para);
                if (n > 0)
                    res = true;
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
            return res;
        }

        public List<NavInfoModel> GetAllNavInfoByGuoJia(string GuoJia)
        {
            List<NavInfoModel> list = new List<NavInfoModel>();
            DataTable dt = new DataTable();
            NavInfoModel NavModel = null;
            try
            {
                string sql = "select * from NavInfo where GuoJia=@GuoJia";
                MySqlParameter[] para = {
                    new MySqlParameter("@GuoJia",GuoJia)
                };
                dt = MySqlDB.GetDataTable(sql, System.Data.CommandType.Text, para);
                foreach (DataRow dr in dt.Rows)
                {
                    NavModel = new NavInfoModel();
                    NavModel.NavId = Convert.ToInt32(dr["NavID"]);//NavID NavTitleOne  NavContentOne   NavParentID  NavTypeID  NavIsLevel    NavDate    NavCreateBy   NavHeat   NavTitleTwo   NavContentTwo  GuoJia  BuWei   PaiXu  depth   LinkFor
                    NavModel.NavTitleOne = dr["NavTitleOne"].ToString();
                    NavModel.NavContentOne = dr["NavContentOne"].ToString();
                    NavModel.NavParentId = Convert.ToInt32(dr["NavParentID"]);
                    NavModel.NavType = dr["NavTypeID"].ToString();
                    NavModel.NavIsLevel = Convert.ToInt32(dr["NavIsLevel"]);
                    NavModel.NavDate = Convert.ToDateTime(dr["NavDate"]);
                    NavModel.NavCreateBy = dr["NavCreateBy"].ToString();
                    NavModel.NavHeat = Convert.ToInt32(dr["NavHeat"]);
                    NavModel.NavTitleTwo = dr["NavTitleTwo"].ToString();
                    NavModel.NavContentTwo = dr["NavContentTwo"].ToString();
                    NavModel.GuoJia = dr["GuoJia"].ToString();
                    NavModel.BuWei = dr["BuWei"].ToString();
                    NavModel.PaiXu = Convert.ToInt32(dr["PaiXu"]);
                    NavModel.Depth = Convert.ToInt32(dr["depth"]);
                    NavModel.LinkFor = dr["LinkFor"].ToString();
                    NavModel.KeyWord = dr["KeyWord"].ToString();
                    list.Add(NavModel);
                }
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
            return list;
        }
        /// <summary>
        /// 根据nav编号获取该行数据
        /// </summary>
        /// <param name="NavID"></param>
        /// <returns></returns>
        public NavInfoModel GetModelById(int NavID)
        {
            //NavID NavTitleOne  NavContentOne   NavParentID  NavTypeID  NavIsLevel    NavDate    NavCreateBy   NavHeat   NavTitleTwo   NavContentTwo  GuoJia  BuWei   PaiXu  depth   LinkFor
            NavInfoModel model = new NavInfoModel();
            try
            {
                string sql = "update navinfo set navinfo.NavHeat=navinfo.NavHeat+1 where NavID=@NavID;";
                sql += "select * from NavInfo where NavID=@NavID";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavID",NavID)
                };
                //int n = MySqlDB.nonquery(sql, CommandType.Text, para);
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                model.NavId = NavID;
                model.NavTitleOne = dt.Rows[0]["NavTitleOne"].ToString();
                model.NavContentOne = dt.Rows[0]["NavContentOne"].ToString();
                model.NavParentId = Convert.ToInt32(dt.Rows[0]["NavParentID"]);
                model.NavType = dt.Rows[0]["NavTypeID"].ToString();
                model.NavIsLevel = Convert.ToInt32(dt.Rows[0]["NavIsLevel"]);
                model.NavDate = Convert.ToDateTime(dt.Rows[0]["NavDate"]);
                model.NavCreateBy = dt.Rows[0]["NavCreateBy"].ToString();
                model.NavHeat =Convert.ToInt32(dt.Rows[0]["NavHeat"]);
                model.NavTitleTwo = dt.Rows[0]["NavTitleTwo"].ToString();
                model.NavContentTwo = dt.Rows[0]["NavContentTwo"].ToString();
                model.GuoJia = dt.Rows[0]["GuoJia"].ToString();
                model.BuWei = dt.Rows[0]["BuWei"].ToString();
                model.PaiXu = Convert.ToInt32(dt.Rows[0]["PaiXu"].ToString());
                model.Depth = Convert.ToInt32(dt.Rows[0]["depth"]);
                model.LinkFor = dt.Rows[0]["LinkFor"].ToString();
                model.KeyWord = dt.Rows[0]["KeyWord"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }


        ///<summary>
        ///上一个导航标题
        ///<para>Id:导航标题Id</para>
        /// </summary>
        public NavInfoModel GetModelByIdPrev(int Id)
        {
            try
            {
                NavInfoModel model = new NavInfoModel();
                DataTable dt1 = MySqlDB.GetDataTable("select min(NavId) from navinfo where NavTitleTwo!=''", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];

                if (Id == Sid)
                {
                    model.NavTitleTwo = "已是第一章了";
                    return model;
                }
                else
                {
                    string sql = "select *  from navinfo where NavId <@Id and NavTitleTwo!='' order by NavId desc limit 1";
                    MySqlParameter[] para = {
                new MySqlParameter("@Id",Id)
            };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    model.NavId = (int)dt.Rows[0]["NavId"];
                    model.NavTitleTwo = dt.Rows[0]["NavTitleTwo"].ToString();
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
        ///下一个导航标题
        ///<para>Id:导航标题Id</para>
        /// </summary>
        public NavInfoModel GetModelByIdNext(int Id)
        {
            try
            {
                NavInfoModel infor = new NavInfoModel();
                DataTable dt1 = MySqlDB.GetDataTable("select MAX(NavId) from navinfo where NavTitleTwo!=''", CommandType.Text, null);
                int Sid = (int)dt1.Rows[0][0];
                if (Id >= Sid)
                {
                    infor.NavTitleTwo = "已经是最后一章了";
                    return infor;
                }
                else
                {
                    string sql = "select *  from navinfo  where NavId >@Id and NavTitleTwo!='' LIMIT 1";
                    MySqlParameter[] para = {
                          new MySqlParameter("@Id",Id)
                       };
                    DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                    infor.NavId = (int)dt.Rows[0]["NavId"];
                    infor.NavTitleTwo = dt.Rows[0]["NavTitleTwo"].ToString();
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




        public List<NavInfoModel> GetNavInfoByGuoJiaAndParentId(string GuoJia,int ParentId)
        {
            List<NavInfoModel> list = new List<NavInfoModel>();
            DataTable dt = new DataTable();
            NavInfoModel NavModel = null;
            try
            {
                string sql = "select * from NavInfo where GuoJia=@GuoJia and NavParentID=@NavParentID order by PaiXu";
                MySqlParameter[] para = {
                    new MySqlParameter("@GuoJia",GuoJia),
                    new MySqlParameter("@NavParentID",ParentId)
                };
                dt = MySqlDB.GetDataTable(sql, System.Data.CommandType.Text, para);
                foreach (DataRow dr in dt.Rows)
                {
                    NavModel = new NavInfoModel();
                    NavModel.NavId = Convert.ToInt32(dr["NavID"]);//NavID NavTitleOne  NavContentOne   NavParentID  NavTypeID  NavIsLevel    NavDate    NavCreateBy   NavHeat   NavTitleTwo   NavContentTwo  GuoJia  BuWei   PaiXu  depth   LinkFor
                    NavModel.NavTitleOne = dr["NavTitleOne"].ToString();
                    NavModel.NavContentOne = dr["NavContentOne"].ToString();
                    NavModel.NavParentId = Convert.ToInt32(dr["NavParentID"]);
                    NavModel.NavType = dr["NavTypeID"].ToString();
                    NavModel.NavIsLevel = Convert.ToInt32(dr["NavIsLevel"]);
                    NavModel.NavDate = Convert.ToDateTime(dr["NavDate"]);
                    NavModel.NavCreateBy = dr["NavCreateBy"].ToString();
                    NavModel.NavHeat = Convert.ToInt32(dr["NavHeat"]);
                    NavModel.NavTitleTwo = dr["NavTitleTwo"].ToString();
                    NavModel.NavContentTwo = dr["NavContentTwo"].ToString();
                    NavModel.GuoJia = dr["GuoJia"].ToString();
                    NavModel.BuWei = dr["BuWei"].ToString();
                    NavModel.PaiXu = Convert.ToInt32(dr["PaiXu"]);
                    NavModel.Depth = Convert.ToInt32(dr["depth"]);
                    NavModel.LinkFor = dr["LinkFor"].ToString();
                    NavModel.KeyWord = dr["KeyWord"].ToString();
                    list.Add(NavModel);
                }
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
            return list;
        }

        public List<NavInfoModel> GetNavInfo(string GuoJia, int ParentId,string BuWei)
        {
            List<NavInfoModel> list = new List<NavInfoModel>();
            DataTable dt = new DataTable();
            NavInfoModel NavModel = null;
            try
            {
                string sql = "select * from NavInfo where GuoJia=@GuoJia and NavParentID=@NavParentID and BuWei=@BuWei order by PaiXu";
                MySqlParameter[] para = {
                    new MySqlParameter("@GuoJia",GuoJia),
                    new MySqlParameter("@NavParentID",ParentId),
                    new MySqlParameter("@BuWei",BuWei)
                };
                dt = MySqlDB.GetDataTable(sql, System.Data.CommandType.Text, para);
                foreach (DataRow dr in dt.Rows)
                {
                    NavModel = new NavInfoModel();
                    NavModel.NavId = Convert.ToInt32(dr["NavID"]);//NavID NavTitleOne  NavContentOne   NavParentID  NavTypeID  NavIsLevel    NavDate    NavCreateBy   NavHeat   NavTitleTwo   NavContentTwo  GuoJia  BuWei   PaiXu  depth   LinkFor
                    NavModel.NavTitleOne = dr["NavTitleOne"].ToString();
                    NavModel.NavContentOne = dr["NavContentOne"].ToString();
                    NavModel.NavParentId = Convert.ToInt32(dr["NavParentID"]);
                    NavModel.NavType = dr["NavTypeID"].ToString();
                    NavModel.NavIsLevel = Convert.ToInt32(dr["NavIsLevel"]);
                    if (!string.IsNullOrEmpty(dr["NavDate"].ToString()))
                    {
                        NavModel.NavDate = Convert.ToDateTime(dr["NavDate"]);
                    }
                    NavModel.NavCreateBy = dr["NavCreateBy"].ToString();
                    if (!string.IsNullOrEmpty(dr["NavHeat"].ToString()))
                    {
                        NavModel.NavHeat = Convert.ToInt32(dr["NavHeat"]);
                    }
                    NavModel.NavTitleTwo = dr["NavTitleTwo"].ToString();
                    NavModel.NavContentTwo = dr["NavContentTwo"].ToString();
                    NavModel.GuoJia = dr["GuoJia"].ToString();
                    NavModel.BuWei = dr["BuWei"].ToString();
                    NavModel.PaiXu = Convert.ToInt32(dr["PaiXu"]);
                    NavModel.Depth = Convert.ToInt32(dr["depth"]);
                    NavModel.LinkFor = dr["LinkFor"].ToString();
                    NavModel.KeyWord = dr["KeyWord"].ToString();
                    list.Add(NavModel);
                }
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteLog("错误报告", ex);
                throw ex;
            }
            return list;
        }
    }
}
