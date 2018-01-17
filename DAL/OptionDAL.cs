using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiDAL
{
  public  class OptionDAL
    {
        /// <summary>
        /// 添加嘉际观点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddOption(JiaJiModels.OptionModel model)
        {

            string sql = string.Format("insert into optioninfo(OptionTitle,OptionContent,Author,Source,Date,OptionHot,OptionKeyWord,OptionUrl) VALUES('{0}','{1}','{2}','{3}', '{4}',{5},'{6}','{7}')", model.OptionTitle,model.OptionContent,model.Author,model.Source,model.Date,0,model.OptionKeyWord,model.OptionUrl);

            return MySqlDB.nonquery(sql,System.Data.CommandType.Text,null);

        }
        /// <summary>
        /// 嘉际观点显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.OptionModel> ShowOptions()
        {
            try
            {
                string sql = "select OptionID,OptionTitle,Author,Source,Date,OptionHot,OptionContent,OptionKeyWord,OptionUrl from optioninfo order by OptionID desc ";
                List<JiaJiModels.OptionModel> list = MySqlDB.GetList<JiaJiModels.OptionModel>(sql,System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除嘉际观点
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelOptions(string optionid)
        {
            try
            {
                string sql = "delete from optioninfo where OptionID in (" + optionid + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改观点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdOptions(JiaJiModels.OptionModel model)
        {
            try
            {
                string sql = "update optioninfo set OptionTitle='"+model.OptionTitle+ "',OptionKeyWord='"+model.OptionKeyWord+"',OptionContent='" + model.OptionContent+"',Author='"+model.Author+"',Source='"+model.Source+"',`Date`='"+model.Date+ "',OptionUrl='"+model.OptionUrl+"' where OptionID=" + model.OptionID+"";

                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }



    }
}
