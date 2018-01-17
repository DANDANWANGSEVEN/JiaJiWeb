using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
    public class SPRelationBLL
    {
        JiaJiNewWebIDAL.ISPRelationDAL spdal = JiaJiNewWeb.DALFactory.Factory<JiaJiNewWebIDAL.ISPRelationDAL>.Create("SPRelationDAL");
        /// <summary>
        /// 通过国家和学历查找规划
        /// </summary>
        /// <param name="countryid">国家ID</param>
        /// <param name="educationid">学历ID</param>
        /// <returns></returns>
        public List<JiaJiNewWebModel.StudentProgram> GetProgramBy(int countryid, int educationid)
        {
            return spdal.GetProgramBy(countryid, educationid);
        }
    }
}
