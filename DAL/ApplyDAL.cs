using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JiaJiDAL
{
    public class ApplyDAL
    {
        #region 获取免费留学方案
        /// <summary>
        /// 获取免费留学方案
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Apply> StuApplyList()
        {
            try
            {

                string sql = "select CountryName,UserName,Phone,GoTime from apply order by ApplyID desc";
                List<JiaJiModels.Apply> list = MySqlDB.GetList<JiaJiModels.Apply>(sql, System.Data.CommandType.Text, null);
                return list;

            }
            catch(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 删除资讯信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelApply(string applyid)
        {
            try
            {
                string sql = "delete from apply where ApplyID in (" + applyid + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion





        #region 留学时间规划
        /// <summary>
        /// 获取留学规时间规划
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ApplyModel.ArrangeTime> ShowArrangTime()
        {
            try
            {
                string sql = " select ArrangeID,ArrangeMonth,ArrangeContent,arrangetime.CountryID,arrangetime.EducationID,CountryName,EducationName,ShowID from arrangetime left join country on arrangetime.CountryID=country.CountryID left join educationtype on arrangetime.EducationID=educationtype.EducationID ";
                List<JiaJiModels.ApplyModel.ArrangeTime> list = MySqlDB.GetList<JiaJiModels.ApplyModel.ArrangeTime>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加留学规时间规划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addArrangeTime(JiaJiModels.ApplyModel.ArrangeTime model)
        {
            try
            {
                string sql = "insert into arrangetime(ArrangeMonth,ArrangeContent,CountryID,EducationID,ShowID) Values('" + model.ArrangeMonth + "','" + model.ArrangeContent + "',"+model.CountryID+","+model.EducationID+","+model.ShowID+")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除留学规时间规划
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelArrangetime(string ids)
        {
            try
            {
                string sql = "DELETE from arrangetime where ArrangeID in (" + ids + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改留学规时间规划
        /// </summary>
        /// <returns></returns>
        public int UpdArrangeTime(JiaJiModels.ApplyModel.ArrangeTime model)
        {
            try
            {
                string sql = "update arrangetime set ArrangeMonth = '" + model.ArrangeMonth + "', ArrangeContent = '" + model.ArrangeContent + "',CountryID="+model.CountryID+",EducationID="+model.EducationID+",ShowID="+model.ShowID+" where ArrangeID="+model.ArrangeID+" ";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        #endregion


        #region 留学申请条件
        /// <summary>
        /// 获取留学申请条件
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ApplyModel.ApplyCondition> ShowApplyCondition()
        {
            try
            {
                string sql = "select * from applycondition ";
                List<JiaJiModels.ApplyModel.ApplyCondition> list = MySqlDB.GetList<JiaJiModels.ApplyModel.ApplyCondition>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加留学申请条件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addApplyCondition(JiaJiModels.ApplyModel.ApplyCondition model)
        {
            try
            {

                string sql = "insert into applycondition(ApplyTitle) Values('" + model.ApplyTitle + "')";

                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除留学申请条件
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelApplyCondition(string ids)
        {
            try
            {
                string sql = "DELETE from applycontentinfo where ApplyID in (" + ids + "); ";
                sql = "DELETE from applycondition where ApplyID in (" + ids + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改留学申请条件
        /// </summary>
        /// <returns></returns>
        public int UpdApplyCondition(JiaJiModels.ApplyModel.ApplyCondition model)
        {
            try
            {
                string sql = "update applycondition set ApplyTitle = '" + model.ApplyTitle + "' where ApplyID=" + model.ApplyID + " ";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 获取留学申请内容
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.ApplyModel.ApplyContentInfo> ShowApplyContent()
        {
            try
            {
                string sql = "select * from applycontentinfo order by ApplyContentID desc ";
                List<JiaJiModels.ApplyModel.ApplyContentInfo> list = MySqlDB.GetList<JiaJiModels.ApplyModel.ApplyContentInfo>(sql, System.Data.CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加留学申请内容
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addApplyContent(JiaJiModels.ApplyModel.ApplyContentInfo model)
        {
            try
            {

                string sql = "insert into ApplyContentInfo(ApplyContent,CountryID,EducationID,ApplyConditionID) values('"+model.ApplyContent+"',"+model.CountryID+","+model.EducationID+","+model.ApplyConditionID+")";

                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除留学申请内容
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelApplyContent(string ids)
        {
            try
            {
                string sql = "DELETE from ApplyContentInfo where ApplyContentID in (" + ids + ")";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改留学申请内容
        /// </summary>
        /// <returns></returns>
        public int UpdApplyContent(JiaJiModels.ApplyModel.ApplyContentInfo model)
        {
            try
            {
                string sql = "UPDATE applycontentinfo SET ApplyContent='"+model.ApplyContent+"',CountryID="+model.CountryID+",EducationID="+model.EducationID+",ApplyConditionID="+model.ApplyConditionID+" WHERE ApplyContentID="+model.ApplyContentID+" ";
                int h = MySqlDB.nonquery(sql, System.Data.CommandType.Text, null);
                return h;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        #endregion


        /// <summary>
        /// 留学材料
        /// </summary>
        /// <param name="Con"></param>
        /// <returns></returns>
        public int ArrangeCondition(JiaJiModels.ApplyModel.ApplyCondition Con)
        {
            string sql = "insert into applycondition(ApplyTitle,ApplyContent)values(@Title,@Content)";
            MySqlParameter[] para = {
                new MySqlParameter("@Title",Con.ApplyTitle),
                new MySqlParameter("@Content",Con.ApplyContent)
            };
            return MySqlDB.nonquery(sql, System.Data.CommandType.Text, para);
        }
        /// <summary>
        /// 留学规划类别
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ProgramType(JiaJiModels.ApplyModel.StudentProgramType type)
        {
            string sql = "insert into StudentProgramType(TypeName)values(@Name)";
            MySqlParameter[] para = {
                new MySqlParameter("@Name",type.TypeName)
            };
            return MySqlDB.nonquery(sql, System.Data.CommandType.Text, para);
        }
    }
}
