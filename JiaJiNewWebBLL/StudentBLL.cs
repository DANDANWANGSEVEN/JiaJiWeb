using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
using JiaJiNewWeb.DALFactory;
namespace JiaJiNewWebBLL
{
  public  class StudentBLL
    {

        JiaJiNewWebIDAL.IStudentDAL udal = Factory<JiaJiNewWebIDAL.IStudentDAL>.Create("StudentDAL");

        /// <summary>
        /// 获取学生的轮播信息
        /// </summary>
        /// <param name="Index">开始条数</param>
        /// <param name="GoIndex">结束条数</param>
        /// <returns>学生信息的List集合</returns>
        public List<JiaJiNewWebModel.StudentIndexModel> StudentIndexList(int Index, int GoIndex)
        {
            try
            {
                return udal.StudentIndexList(Index, GoIndex);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }


        /// <summary>
        /// 获取学生信息的
        /// </summary>
        /// <returns></returns>
        public int CountStudentInfo()
        {
            try
            {
                return udal.CountStudentInfo();
            }
            catch(Exception ex)
            {
                return 0;
            }
            

        }


        /// <summary>
        /// 获取每个国家的学生
        /// </summary>
        /// <param name="Index">开始条数</param>
        /// <param name="GoIndex">结束条数</param>
        /// <returns>学生信息的List集合</returns>
        public List<JiaJiNewWebModel.StudentIndexModel> CountryStuList(int countryid, int Index, int GoIndex)
        {
            try
            {
                return udal.CountryStuList(countryid,Index,GoIndex);
            }
            catch (System.Exception ex)
            {
                return null;

            }


        }


    }
}
