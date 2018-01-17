using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace JiaJiDAL
{
   public class strategydal
    {
        /// <summary>
        /// 添加攻略信息
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
       public int addstat(JiaJiModels.strategy stat)
        {            
            try
            {
                string sql = "INSERT into strategy(strategyTitle,strategyContent,strategyDate,CountryID,Img,StrategyProfile,StrategyKeyWord,StrategyReadCount,StrategyAuthor)VALUES('" + stat.StrategyTitle + "','" + stat.StrategyContent + "','" + stat.StrategyDate + "'," + stat.CountryID + ",'" + stat.Img + "','"+ stat.StrategyProfile+ "','"+stat.StrategyKeyWord+"',0,'"+stat.StrategyAuthor+"')";                
                int h = MySqlDB.nonquery(sql, CommandType.Text,null);
                return h;                
            }
            catch(Exception ex)
            {
                var s = ex;
                return 0;
            }                   
        }

        /// <summary>
        /// 策略显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.strategy> ShowStrategy()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" select StrategyID,StrategyTitle,StrategyContent,StrategyDate,strategy.CountryID,CountryName,Img,StrategyProfile,StrategyKeyWord,StrategyReadCount,StrategyAuthor from strategy ");
                sql.Append(" left join country on strategy.CountryID=country.CountryID order by StrategyID DESC ");

                List<JiaJiModels.strategy> strategylist = MySqlDB.GetList<JiaJiModels.strategy>(sql.ToString(), CommandType.Text, null);
                return strategylist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除策略信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelStrategy(string StrategyID)
        {
            try
            {
                string sql = "delete from strategy where StrategyID in (" + StrategyID + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 修改攻略信息
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public int Updatestrategy(JiaJiModels.strategy stat)
        {
            try
            {
                string sql = "update strategy set  strategyTitle = '"+stat.StrategyTitle+"',strategyContent = '"+stat.StrategyContent+"',strategyDate = '"+stat.StrategyDate+"',CountryID ="+stat.CountryID+ ",Img = '" + stat.Img+ "',StrategyProfile='"+stat.StrategyProfile+"',StrategyKeyWord='"+stat.StrategyKeyWord+"',StrategyAuthor='"+stat.StrategyAuthor+"' where StrategyID =" + stat.StrategyID+" ";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
