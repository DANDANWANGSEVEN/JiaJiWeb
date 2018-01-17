using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebIDAL
{
    public interface IStudentDAL
    {
        /// <summary>
        /// 首页显示学生的信息
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.StudentIndexModel> StudentIndexList(int Index, int GoIndex);

        /// <summary>
        /// 获取学生信息的
        /// </summary>
        /// <returns></returns>
        int CountStudentInfo();


        /// <summary>
        /// 获取每个国家的学生
        /// </summary>
        /// <param name="Index">开始条数</param>
        /// <param name="GoIndex">结束条数</param>
        /// <returns>学生信息的List集合</returns>
        List<JiaJiNewWebModel.StudentIndexModel> CountryStuList(int countryid, int Index, int GoIndex);



    }
}
