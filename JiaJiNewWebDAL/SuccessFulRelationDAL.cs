using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebDAL
{
    public class SuccessFulRelationDAL:JiaJiNewWebIDAL.ISuccessFulRelationDAL
    {
        /// <summary>
        /// 显示成功案例
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        public List<SuccessfulInfo_Relation> GetAnLi(int countryid, int educationid, int pageindex)
        {
            try
            {
                int pagesize = 5;
                StringBuilder sql = new StringBuilder();
                sql.Append(" select SQL_CALC_FOUND_ROWS * from successful_relation ");
                sql.Append(" left join successful on successful_relation.SuccessID=successful.SuccessID ");
                sql.Append(" left join student on successful_relation.StudentID=student.StudentID ");
                sql.Append(" left join country on student.CountryID=country.CountryID  ");
                sql.Append(" left join college on student.CollegeID=college.CollegeID ");
                sql.Append(" left join educationtype on educationtype.EducationID=student.EducationID WHERE student.CountryID=" + countryid + " and student.EducationID=" + educationid + " LIMIT " + (pageindex - 1) * pagesize + "," + pagesize + "; ");
                sql.Append(" SELECT FOUND_ROWS(); ");

                List<SuccessfulInfo_Relation> list = MySqlDB.GetList<SuccessfulInfo_Relation>(sql.ToString(), System.Data.CommandType.Text, null);
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        /// <summary>
        /// 根据条件获取总行数
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educatio;nid">学历ID</param>
        /// <returns></returns>
        /// sss
        public int GetRowCounts(int countryid, int educationid)
        {
            string sql = "select COUNT(1) from successful_relation a INNER JOIN student b ON a.StudentID = b.StudentID where b.CountryID=" + countryid + " and b.EducationID=" + educationid + "";
            int i = MySqlDB.scalar(sql, System.Data.CommandType.Text, null);
            return i = i % 5 == 0 ? i / 5 : (i / 5) + 1;
        }

        /// <summary>
        /// 获取国家列表
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountry()
        {
            string sql = "select * from country where IsCountry=1";
            List<Country> list = MySqlDB.GetList<Country>(sql, System.Data.CommandType.Text, null);
            return list;
        }
        /// <summary>
        /// 获取语言背景移民
        /// </summary>
        /// <returns></returns>
        public List<Country> GetLBY(int countryid)
        {
            try
            {
                string sql = "select * from country where IsCountry=0 AND CountryID="+ countryid + "";
                List<Country> list = MySqlDB.GetList<Country>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }



        /// <summary>
        /// 获取学历类别
        /// </summary>
        /// <returns></returns>
        public List<EducationType> GetEducationType()
        {
            string sql = "select * from educationtype";
            List<EducationType> list = MySqlDB.GetList<EducationType>(sql, System.Data.CommandType.Text, null);
            return list;
        }
        /// <summary>
        /// 查找国家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Country> GetCountry(int id)
        {
            string sql = "select CountryName,CountryYouShi,CountryImg2 from Country where CountryID=" + id+ "  and IsCountry=1";
            List<Country> list = MySqlDB.GetList<Country>(sql, System.Data.CommandType.Text, null);
            return list;
        }
    }
}
