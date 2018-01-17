using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;

namespace JiaJiNewWebIDAL
{
    public interface IFiliale
    {
        /// <summary>
        /// 分公司信息
        /// </summary>
        /// <returns></returns>
        filialetext GetFilialetext(int FilialeId);
    }
}
