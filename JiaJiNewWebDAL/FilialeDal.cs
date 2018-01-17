using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebIDAL;
using JiaJiNewWebModel;
using System.Data;

namespace JiaJiNewWebDAL
{
    public class FilialeDal : IFiliale
    {
        /// <summary>
        /// 分公司信息
        /// </summary>
        /// <param name="FilialeId">公司id</param>
        /// <returns></returns>
        public filialetext GetFilialetext(int FilialeId)
        {
            try
            {
                //string sql = "select  FilialeId,FilialeName,FilialeTexts,FilialeTextAddr,FilialeTextPhone from filiale INNER JOIN filialetext on filiale.FilialeTextId = filialetext.FilialeTextId where FilialeId = "+FilialeId;
                string sql = "SELECT * from filialetext LEFT JOIN filiale on filialetext.FilialeId=filiale.FilialeId where filialetext.FilialeId =" + FilialeId + " LIMIT 1";
                DataTable model = MySqlDB.GetDataTable(sql, CommandType.Text, null);
                return MySqlDB.fanshemodel<filialetext>(model);
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
    }
}
