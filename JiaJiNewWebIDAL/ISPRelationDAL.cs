using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
    public interface ISPRelationDAL
    {
        /// <summary>
        /// 通过国家和学历查找规划
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <returns></returns>
        List<StudentProgram> GetProgramBy(int countryid, int educationid);
    }
}
