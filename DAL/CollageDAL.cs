using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace JiaJiDAL
{
   public class CollageDAL
    {


        #region 学院
        /// <summary>
        /// 录取学院添加
        /// </summary>
        /// <param name="cname"></param>
        /// <returns></returns>
        public int collageadd(JiaJiModels.collages model)
        {
            try
            {
                string sql = "INSERT INTO college(CollegeName,CollegeImg) VALUES('" + model.CollegeName + "','"+model.CollegeImg+"')";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                var s = ex;
                return 0;
            }
        }

        /// <summary>
        /// 修改录取学院
        /// </summary>
        /// <returns></returns>
        public int UpdateCollege(JiaJiModels.collages model)
        {
            try
            {
                string sql = "Update study_abroad.college set CollegeName = '" + model.CollegeName + "', CollegeImg = '" + model.CollegeImg + "' where CollegeID =" + model.CollegeID + " ";
                int he = MySqlDB.nonquery(sql, CommandType.Text, null);
                return he;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 删除录取学院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelCollage(string ids)
        {
            try
            {

                string sql = "delete from student where CollegeID in (" + ids + ");";
                sql = "DELETE from college where CollegeID in (" + ids + ")";


                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 获取录取学院列表
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.collages> Collegehow()
        {
            try
            {
                string sql = "select * from college";
                List<JiaJiModels.collages> list = MySqlDB.GetList<JiaJiModels.collages>(sql, CommandType.Text, null);
                return list;
            }
            catch (Exception ex)
            {
                var s = ex;
                return null;
            }
        }
        #endregion


        /// <summary>
        /// 添加就读学院信息
        /// </summary>
        /// <param name="aname"></param>
        /// <returns></returns>
        public int Attendadd(string aname)
        {
            try
            {
                string sql = "INSERT into attending(AtendName) VALUES('"+aname+"')";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;
            }
            catch(Exception ex)
            {
                var s = ex;
                return 0;
            }
        }
        /// <summary>
        /// 获取就读学院列表信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Attending> Ashow()
        {
            try
            {
                string sql = "select * from attending";
                List<JiaJiModels.Attending> list = MySqlDB.GetList<JiaJiModels.Attending>(sql, CommandType.Text, null);
                return list;
            }
            catch(Exception ex)
            {
                var s = ex;
                return null;
            }
        }
        /// <summary>
        /// 删除就读学院
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelAttending(int id)
        {
            string sql = "delete  from  attending    where AtendID=" + id;
            return MySqlDB.nonquery(sql,CommandType.Text,null);

        }


    }
}
