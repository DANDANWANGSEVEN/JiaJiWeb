using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiModels;
using System.Data;
using MySql.Data.MySqlClient;

namespace JiaJiDAL
{
    public class FilialeDal
    {



        #region 分公司介绍管理

        /// <summary>
        /// 获取分公司信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.filialetext> ShowFenGongsi()
        {
            try
            {
                StringBuilder sqlstring = new StringBuilder();
                sqlstring.Append(" SELECT * from filialetext LEFT JOIN filiale on filialetext.FilialeId=filiale.FilialeId ");
                List<JiaJiModels.filialetext> list = MySqlDB.GetList<JiaJiModels.filialetext>(sqlstring.ToString(), CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 删除分公司信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelFilialeText(string filialeTextID)
        {
            try
            {
                string sql = "delete from filialetext where FilialeTextId in ('" + filialeTextID + "')";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 添加分公司介绍
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addFilialeText(JiaJiModels.filialetext model)
        {
            try
            {

                string sql = "insert into filialetext(FilialeTexts,FilialetextAddr,FilialeTextPhone,FilialeID,FilialeImg)VALUES('" + model.FilialeTexts+"','"+model.FilialeTextAddr+"','"+model.FilialeTextPhone+"',"+model.FilialeId+ ",'" + model.FilialeImg+"')";

                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改分公司介绍
        /// </summary>
        /// <returns></returns>
        public int UpdateFilialeText(JiaJiModels.filialetext model)
        {
            try
            {
                string sql = "update study_abroad.filialetext set FilialeTexts='" + model.FilialeTexts + "',FilialetextAddr='"+model.FilialeTextAddr+"',FilialeTextPhone='"+model.FilialeTextPhone+"',FilialeID="+model.FilialeId+ ",FilialeImg='" + model.FilialeImg + "' where FilialeTextId=" + model.FilialeTextId + "";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }





        #endregion


        #region 分公司管理
        /// <summary>
        /// 分公司
        /// </summary>
        /// <returns></returns>
        public List<filialetext> FilialeShow()
        {
            try
            {
                string sql = "select FilialeId,FilialeName from filiale";
                return MySqlDB.GetList<filialetext>(sql, CommandType.Text, null);
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
        /// <summary>
        /// 删除分公司信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelFiliale(string filialeID)
        {
            try
            {
                string sql = "delete from filialetext where filialeId in (" + filialeID + ");";
                sql += "delete from filiale where filialeId in (" + filialeID + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 添加分公司信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addFiliale(JiaJiModels.filialetext model)
        {
            try
            {

                string sql = "INSERT INTO study_abroad.filiale (FilialeName) VALUES ('"+model.FilialeName+"')";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 修改分公司信息
        /// </summary>
        /// <returns></returns>
        public int UpdateFiliale(JiaJiModels.filialetext model)
        {
            try
            {
                string sql = "update study_abroad.filiale set FilialeName='"+model.FilialeName+"' where FilialeId="+model.FilialeId+"";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion



        ///// <summary>
        ///// 添加用户
        ///// </summary>
        ///// <param name="FilialeName"></param>
        ///// <returns></returns>
        //public int FilialePutin(filialetext model)
        //{
        //    string sql = "insert into filialetext(FilialeTexts,FilialeTextAddr,FilialeTextPhone) values(@FilialeTexts,@FilialeTextAddr,@FilialeTextPhone)";
        //    MySqlParameter[] para =
        //    {
        //        new MySqlParameter("@FilialeTexts",model.FilialeTexts),
        //        new MySqlParameter("@FilialeTextAddr",model.FilialeTextAddr),
        //        new MySqlParameter("@FilialeTextPhone",model.FilialeTextPhone)
        //    };
        //    MySqlDB.nonquery(sql, CommandType.Text, para);

        //    string sql3 = "select @@identity";

        //    int Isid = MySqlDB.scalar(sql3, CommandType.Text, null);

        //    string sql2 = "insert into filiale(FilialeName,FilialeTextId) values(@FilialeName,@Isid)";
        //    MySqlParameter[] para2 = {
        //        new MySqlParameter("@FilialeName",model.FilialeName),
        //        new MySqlParameter("@Isid",Isid)
        //    };

        //    return MySqlDB.nonquery(sql2, CommandType.Text, para2);
        //}

        

        //public filialetext FilialeTextShow(int FilialeId)
        //{
        //    string sql = "select FilialeId,FilialeName,FilialeTexts,FilialeTextAddr,FilialeTextPhone from filiale INNER JOIN filialetext on filiale.FilialeTextId = filialetext.FilialeTextId where FilialeId = @FilialeId";
        //    MySqlParameter[] para = {
        //        new MySqlParameter("@FilialeId",FilialeId)
        //    };

        //    return MySqlDB.fanshemodel<filialetext>(MySqlDB.GetDataTable(sql, CommandType.Text, para));
        //}


        ///// <summary>
        ///// 修改分公司介绍
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public int FilialeUpdate(filialetext model)
        //{
        //    string sUpdateSql = "UPDATE filiale INNER JOIN filialetext on filiale.FilialeTextId = filialetext.FilialeTextId set FilialeTexts=@FilialeTexts,FilialeTextAddr=@FilialeTextAddr,FilialeTextPhone=@FilialeTextPhone where FilialeId=@FilialeId";
        //    MySqlParameter[] para =
        //     {
        //        new MySqlParameter("@FilialeTexts",model.FilialeTexts),
        //        new MySqlParameter("@FilialeTextAddr",model.FilialeTextAddr),
        //        new MySqlParameter("@FilialeTextPhone",model.FilialeTextPhone),
        //        new MySqlParameter("@FilialeId",model.FilialeId)
        //    };

        //    return MySqlDB.nonquery(sUpdateSql, CommandType.Text,para);
        //}


        


    }
}
