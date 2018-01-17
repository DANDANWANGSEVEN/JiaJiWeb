using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebIDAL;
using JiaJiNewWebModel;
using JiaJiNewWeb.DALFactory;

namespace JiaJiNewWebBLL
{
    public class FilialeBll
    {
        IFiliale dal = Factory<IFiliale>.Create("FilialeDal");

        /// <summary>
        /// 分公司信息
        /// </summary>
        /// <param name="FilialeId">公司id</param>
        /// <returns></returns>
        public filialetext GetFilialetext(int FilialeId)
        {
            return dal.GetFilialetext(FilialeId);
        }
    }
}
