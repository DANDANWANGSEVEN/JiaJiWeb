using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiaJiModels;
using System.Data;
using MySql.Data.MySqlClient;

namespace JiaJiDAL
{
    public class NavInfoDal
    {

        public List<NavInfo> GetNavList()
        {
            try
            {
                string sql = "select * from navinfo";
                List<NavInfo> list = MySqlDB.GetList<NavInfo>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<string> GetAllCountry()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select GuoJia from navinfo group by GuoJia order by GuoJia ASC";
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                foreach (DataRow dr in dt.Rows)
                {
                   list.Add(dr["GuoJia"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public List<NavInfo> GetNavInfo(string GuoJia, int ParentId, string BuWei)
        {
            List<NavInfo> list = new List<NavInfo>();
            DataTable dt = new DataTable();
            NavInfo NavModel = null;
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
                    NavModel = new NavInfo();
                    NavModel.NavID = Convert.ToInt32(dr["NavID"]);//NavID NavTitleOne  NavContentOne   NavParentID  NavTypeID  NavIsLevel    NavDate    NavCreateBy   NavHeat   NavTitleTwo   NavContentTwo  GuoJia  BuWei   PaiXu  depth   LinkFor
                    NavModel.NavTitleOne = dr["NavTitleOne"].ToString();
                    NavModel.NavContentOne = dr["NavContentOne"].ToString();
                    NavModel.NavParentID = Convert.ToInt32(dr["NavParentID"]);
                    NavModel.NavTypeID = dr["NavTypeID"].ToString();
                    if (!string.IsNullOrEmpty(dr["NavIsLevel"].ToString()))
                    {
                        NavModel.NavIsLevel = Convert.ToInt32(dr["NavIsLevel"]);
                    }
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
                    if (!string.IsNullOrEmpty(dr["PaiXu"].ToString()))
                    {
                        NavModel.PaiXu = Convert.ToInt32(dr["PaiXu"]);
                    }
                    if (!string.IsNullOrEmpty(dr["depth"].ToString()))
                    {
                        NavModel.depth = Convert.ToInt32(dr["depth"]);
                    }
                    NavModel.LinkFor = dr["LinkFor"].ToString();
                    NavModel.KeyWord = dr["KeyWord"].ToString();
                    list.Add(NavModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public List<NavInfo> GetTypeByCountry(string country)
        {
            try
            {
                string sql = "";
                if (country.ToLower().Equals("all"))
                {
                    sql = "SELECT BuWei FROM navinfo group by BuWei";
                }
                else
                {
                    sql = "SELECT * FROM navinfo where guojia='" + country + "' and NavParentID=0";
                }
                List<NavInfo> list = MySqlDB.GetList<NavInfo>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<NavInfo> GetTypeByCountryId(int countryId)
        {
            try
            {
                string sql = "SELECT NavID,NavTitleOne FROM navinfo where guojia="+ countryId + " and NavParentID=0";
                List<NavInfo> list = MySqlDB.GetList<NavInfo>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
        public NavInfo GetModelById(int NavID)
        {
            NavInfo model = new NavInfo();
            try
            {
                string sql = "select * from NavInfo where NavID=@NavID";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavID",NavID)
                };
                DataTable dt = MySqlDB.GetDataTable(sql, CommandType.Text, para);
                model.NavID = NavID;
                model.NavTitleOne = dt.Rows[0]["NavTitleOne"].ToString();
                model.NavContentOne = dt.Rows[0]["NavContentOne"].ToString();
                model.NavParentID = Convert.ToInt32(dt.Rows[0]["NavParentID"]);
                model.NavTypeID = dt.Rows[0]["NavTypeID"].ToString();
                model.NavIsLevel = Convert.ToInt32(dt.Rows[0]["NavIsLevel"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["NavDate"].ToString()))
                {
                    model.NavDate = Convert.ToDateTime(dt.Rows[0]["NavDate"]);
                }
                model.NavCreateBy = dt.Rows[0]["NavCreateBy"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["NavHeat"].ToString()))
                {
                    model.NavHeat = Convert.ToInt32(dt.Rows[0]["NavHeat"]);
                }
                model.NavTitleTwo = dt.Rows[0]["NavTitleTwo"].ToString();
                model.NavContentTwo = dt.Rows[0]["NavContentTwo"].ToString();
                model.GuoJia = dt.Rows[0]["GuoJia"].ToString();
                model.BuWei = dt.Rows[0]["BuWei"].ToString();
                model.PaiXu = Convert.ToInt32(dt.Rows[0]["PaiXu"].ToString());
                model.depth = Convert.ToInt32(dt.Rows[0]["depth"]);
                model.LinkFor = dt.Rows[0]["LinkFor"].ToString();
                model.KeyWord = dt.Rows[0]["KeyWord"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddByModel(NavInfo model)
        {
            bool res = false;
            try
            {
                string sql = "insert into NavInfo (NavTitleOne,NavContentOne,NavParentID,NavTypeID,NavIsLevel,NavDate,NavCreateBy,NavHeat ,NavTitleTwo,NavContentTwo,GuoJia,BuWei,PaiXu,depth,LinkFor,KeyWord) Values (@NavTitleOne,@NavContentOne,@NavParentID,@NavTypeID,@NavIsLevel,@NavDate,@NavCreateBy,@NavHeat,@NavTitleTwo,@NavContentTwo,@GuoJia,@BuWei,@PaiXu,@depth,@LinkFor,@KeyWord)";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavTitleOne",model.NavTitleOne),
                    new MySqlParameter("@NavContentOne",model.NavContentOne),
                    new MySqlParameter("@NavParentID",model.NavParentID),
                    new MySqlParameter("@NavTypeID",model.NavTypeID),
                    new MySqlParameter("@NavIsLevel",model.NavIsLevel),
                    new MySqlParameter("@NavDate",model.NavDate),
                    new MySqlParameter("@NavCreateBy",model.NavCreateBy),
                    new MySqlParameter("@NavHeat",model.NavHeat),
                    new MySqlParameter("@NavTitleTwo",model.NavTitleTwo),
                    new MySqlParameter("@NavContentTwo",model.NavContentTwo),
                    new MySqlParameter("@GuoJia",model.GuoJia),
                    new MySqlParameter("@BuWei",model.BuWei),
                    new MySqlParameter("@PaiXu",model.PaiXu),
                    new MySqlParameter("@depth",model.depth),
                    new MySqlParameter("@LinkFor",model.LinkFor),
                    new MySqlParameter("@KeyWord",model.KeyWord)
                };
                int n = MySqlDB.nonquery(sql, CommandType.Text, para);
                if (n > 0)
                    res = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteByModel(NavInfo model)
        {
            bool res = false;
            try
            {
                string sql = "delete from NavInfo where NavID=@NavID";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavID",model.NavID)
                };
                int n = MySqlDB.nonquery(sql, CommandType.Text, para);
                if (n > 0)
                    res = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditByModelContent(NavInfo model)
        {
            bool res = false;
            try
            {
                string sql = "update NavInfo set NavTitleOne=@NavTitleOne,NavCreateBy=@NavCreateBy,NavTitleTwo=@NavTitleTwo,NavContentTwo=@NavContentTwo,GuoJia=@GuoJia,BuWei=@BuWei,PaiXu=@PaiXu,depth=@depth,LinkFor=@LinkFor,KeyWord=@KeyWord   where NavID=@NavID";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavID",model.NavID),
                    new MySqlParameter("@NavTitleOne",model.NavTitleOne),
                    new MySqlParameter("@NavCreateBy",model.NavCreateBy),
                    new MySqlParameter("@NavTitleTwo",model.NavTitleTwo),
                    new MySqlParameter("@NavContentTwo",model.NavContentTwo),
                    new MySqlParameter("@GuoJia",model.GuoJia),
                    new MySqlParameter("@BuWei",model.BuWei),
                    new MySqlParameter("@PaiXu",model.PaiXu),
                    new MySqlParameter("@depth",model.depth),
                    new MySqlParameter("@LinkFor",model.LinkFor),
                    new MySqlParameter("@KeyWord",model.KeyWord)
                };
                int n = MySqlDB.nonquery(sql, CommandType.Text, para);
                if (n > 0)
                    res = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditByModel(NavInfo model)
        {
            bool res = false;
            try
            {
                string sql = "update NavInfo set NavTitleOne=@NavTitleOne,NavContentOne=@NavContentOne,NavParentID=@NavParentID,NavTypeID=@NavTypeID,NavIsLevel=@NavIsLevel,NavDate=@NavDate,NavCreateBy=@NavCreateBy,NavHeat=@NavHeat,NavTitleTwo=@NavTitleTwo,NavContentTwo=@NavContentTwo,GuoJia=@GuoJia,BuWei=@BuWei,PaiXu=@PaiXu,depth=@depth,LinkFor=@LinkFor,KeyWord=@KeyWord   where NavID=@NavID";
                MySqlParameter[] para = {
                    new MySqlParameter("@NavID",model.NavID),
                    new MySqlParameter("@NavTitleOne",model.NavTitleOne),
                    new MySqlParameter("@NavContentOne",model.NavContentOne),
                    new MySqlParameter("@NavParentID",model.NavParentID),
                    new MySqlParameter("@NavTypeID",model.NavTypeID),
                    new MySqlParameter("@NavIsLevel",model.NavIsLevel),
                    new MySqlParameter("@NavDate",model.NavDate),
                    new MySqlParameter("@NavCreateBy",model.NavCreateBy),
                    new MySqlParameter("@NavHeat",model.NavHeat),
                    new MySqlParameter("@NavTitleTwo",model.NavTitleTwo),
                    new MySqlParameter("@NavContentTwo",model.NavContentTwo),
                    new MySqlParameter("@GuoJia",model.GuoJia),
                    new MySqlParameter("@BuWei",model.BuWei),
                    new MySqlParameter("@PaiXu",model.PaiXu),
                    new MySqlParameter("@depth",model.depth),
                    new MySqlParameter("@LinkFor",model.LinkFor),
                    new MySqlParameter("@KeyWord",model.KeyWord)
                };
                int n = MySqlDB.nonquery(sql, CommandType.Text, para);
                if (n > 0)
                    res = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// 根据根节点删除所有子节点
        /// </summary>
        /// <param name="RootID"></param>
        /// <returns></returns>
        public bool DeleteByRootID(int RootID)
        {
            bool res = false;
            try
            {
                string Navid = RootID.ToString()+",";
                List<NavInfo> list = GetAllChild(RootID);
                for (int i = 0; i < list.Count; i++)
                {
                    Navid += list[i].NavID + ",";
                }
                Navid = Navid.Substring(0, Navid.Length - 1);
                string sql = "delete from navinfo where NavID in ("+Navid+")";
                int n = MySqlDB.nonquery(sql, CommandType.Text, null);
                if (n > 0)
                    res = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        private List<NavInfo> GetAllChild(int RootID)
        {
            List<NavInfo> list = new List<NavInfo>();
            List<NavInfo> listChild = GetListByRootID(RootID);
            if (listChild.Count > 0)
            {
                list.AddRange(listChild);
                for (int i = 0; i < listChild.Count; i++)
                {
                    list.AddRange(GetListByRootID(listChild[i].NavID));
                }
            }
            return list;
        }
        private List<NavInfo> GetListByRootID(int RootID)
        {
            List<NavInfo> list = new List<NavInfo>();
            try
            {
                string sqlChilds = "select * from navinfo where NavParentID =" + RootID;
                List<NavInfo> ListChild = MySqlDB.GetList<NavInfo>(sqlChilds, CommandType.Text, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}
