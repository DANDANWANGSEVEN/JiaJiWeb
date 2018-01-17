using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiDAL
{
    public  class EducationDal
    {

        #region 学历
        /// <summary>
        /// 显示学历
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.educationtype> ShowEducation()
        {
            try
            {
                string sql = "select EducationID,EducationName from educationtype ";
                List<JiaJiModels.educationtype> arealist = MySqlDB.GetList<JiaJiModels.educationtype>(sql, System.Data.CommandType.Text, null);
                return arealist;
            }
            catch (Exception e)
            {
                return null;
            }



        }

        /// <summary>
        /// 学历添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddEducation(JiaJiModels.educationtype model)
        {
            try
            {
                string sql = "insert into educationtype(EducationName) values('" + model.EducationName + "')";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除学历
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelEducation(string ids)
        {
            try
            {
                //string sql = "delete from educationtype where EducationID in (" + ids + ");";

                //sql = "delete from lunboimage where EducationID in (" + ids + ");";
                //sql += "delete from student where EducationID in (" + ids + "); ";


                string sql = "delete from lunboimage where EducationID in (" + ids + ");";
                sql = "delete from student where EducationID in (" + ids + ");";
                sql += "delete from educationtype where EducationID in (" + ids + ");";

                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 地区学历
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdEducation(JiaJiModels.educationtype  model)
        {
            try
            {
                string sql = "Update educationtype set EducationName='" + model.EducationName + "' where EducationID=" + model.EducationID + "";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion




    }
}
