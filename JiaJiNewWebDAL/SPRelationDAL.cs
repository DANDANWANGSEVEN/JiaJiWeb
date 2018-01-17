using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebDAL
{
    public class SPRelationDAL : JiaJiNewWebIDAL.ISPRelationDAL
    {
        /// <summary>
        /// 通过国家和学历查找规划
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <returns></returns>
        public List<StudentProgram> GetProgramBy(int countryid, int educationid)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT a.TypeID,a.StudentProgramID,a.StudentProgramTitle,a.StudentProgramContent,a.Imageurl,");
                sql.Append(" a.ReadCount,StudentProfile,StudentKeyWord from (select studentprogramtype.TypeID, studentprogram.ReadCount, studentprogram.StudentProgramID,");
                sql.Append(" studentprogram.StudentProgramTitle, studentprogram.StudentProgramContent, studentprogram.Imageurl,StudentProfile,StudentKeyWord FROM");
                sql.Append(" (select studentprogram.TypeID, studentprogram.ReadCount, studentprogram.StudentProgramID,");
                sql.Append(" studentprogram.StudentProgramTitle, studentprogram.StudentProgramContent, studentprogram.Imageurl,StudentProfile,StudentKeyWord");
                sql.Append(" from studentprogram LEFT JOIN country on studentprogram.CountryID = Country.CountryID");
                sql.Append(" left join educationtype on studentprogram.EducationID = educationtype.EducationID");
                sql.Append(" where studentprogram.CountryID = " + countryid + " AND studentprogram.EducationID = " + educationid + ") studentprogram");
                sql.Append(" RIGHT JOIN studentprogramtype on studentprogram.TypeID = studentprogramtype.TypeID ) a");
                sql.Append(" WHERE 2 >= (");
                sql.Append(" SELECT COUNT(*) from");
                sql.Append(" (select studentprogramtype.TypeID, studentprogram.ReadCount, studentprogram.StudentProgramID,");
                sql.Append(" studentprogram.StudentProgramTitle, studentprogram.StudentProgramContent, studentprogram.Imageurl,StudentProfile,StudentKeyWord FROM");
                sql.Append(" (select studentprogram.TypeID, studentprogram.ReadCount, studentprogram.StudentProgramID,");
                sql.Append(" studentprogram.StudentProgramTitle, studentprogram.StudentProgramContent, studentprogram.Imageurl,StudentProfile,StudentKeyWord");
                sql.Append(" from studentprogram LEFT JOIN country on studentprogram.CountryID = Country.CountryID");
                sql.Append(" left join educationtype on studentprogram.EducationID = educationtype.EducationID");
                sql.Append(" where studentprogram.CountryID = " + countryid + " AND studentprogram.EducationID = " + educationid + ") studentprogram");
                sql.Append(" RIGHT JOIN studentprogramtype on studentprogram.TypeID = studentprogramtype.TypeID) b");
                sql.Append(" WHERE a.TypeID = b.TypeID and a.ReadCount <= b.ReadCount) ORDER BY a.StudentProgramID desc");

                List<StudentProgram> list = MySqlDB.GetList<StudentProgram>(sql.ToString(), System.Data.CommandType.Text, null) ?? new List<StudentProgram>();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
