using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using MySql.Data.MySqlClient;
namespace JiaJiNewWebDAL
{
    public class ApplyDAL:JiaJiNewWebIDAL.IApplyDAL
    {
        /// <summary>
        /// 添加申请
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Addapply(Apply a)
        {
            string sql = "insert into apply (CountryName,UserName,Phone,GoTime) values(?countryname,?username,?phone,?gotime)";
            MySqlParameter[] pars =
            {
                new MySqlParameter("?countryname",a.CountryName),
                new MySqlParameter("?username",a.UserName),
                new MySqlParameter("?phone",a.Phone),
                new MySqlParameter("?gotime",a.GoTime)
            };
            int i = MySqlDB.nonquery(sql, System.Data.CommandType.Text, pars);
            if (i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 首加载显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.CountryDominant> HaiWaiLiuXueIndexList()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                //sql.Append("  select country.CountryID,country.CountryName,country.CountryImg,HaiWaiLiuXueTitle,BaiFengBi,CountryActiveImg1,CountryActiveImg2 from haiwai_country ");
                //sql.Append(" left join country on haiwai_country.CountryID=country.CountryID ");
                //sql.Append(" left join haiwailiuxue on haiwai_country.HaiWaiLiuXueID=haiwailiuxue.HaiWaiLiuXueID where CountryName='美国'");

                sql.Append(" select CountryDominantID,countrydominant.DominantID,countrydominant.CountryID,country.CountryName,DominantName,Chance,CountryActiveImg1,country.CountryImg,CountryActiveImg2 from countrydominant ");
                sql.Append(" left join dominant on countrydominant.DominantID=dominant.DominantID ");
                sql.Append(" left join country on countrydominant.CountryID=country.CountryID where CountryName='美国' limit 3 ");

                List<CountryDominant> HaiWaiList= MySqlDB.GetList<CountryDominant>(sql.ToString(), System.Data.CommandType.Text, null);

                return HaiWaiList;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 根据国家显示海外留学
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.CountryDominant> HaiWaiList(int countryid)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                //sql.Append("  select country.CountryID,country.CountryName,country.CountryImg,HaiWaiLiuXueTitle,BaiFengBi,CountryActiveImg1,CountryActiveImg2 from haiwai_country ");
                //sql.Append(" left join country on haiwai_country.CountryID=country.CountryID ");
                //sql.Append(" left join haiwailiuxue on haiwai_country.HaiWaiLiuXueID=haiwailiuxue.HaiWaiLiuXueID where country.CountryID=" + countryid + "");

                sql.Append(" select CountryDominantID,countrydominant.DominantID,countrydominant.CountryID,country.CountryName,DominantName,Chance,CountryActiveImg1,country.CountryImg,CountryActiveImg2 from countrydominant ");
                sql.Append(" left join dominant on countrydominant.DominantID=dominant.DominantID ");
                sql.Append(" left join country on countrydominant.CountryID=country.CountryID where country.CountryID=" + countryid + " limit 3 ");
                List<JiaJiNewWebModel.CountryDominant> HaiWaiList = MySqlDB.GetList<JiaJiNewWebModel.CountryDominant>(sql.ToString(), System.Data.CommandType.Text, null);

                return HaiWaiList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }





    }
}
