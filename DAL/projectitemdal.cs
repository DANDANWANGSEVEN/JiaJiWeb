using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace JiaJiDAL
{
   public class projectitemdal
    {
        /// <summary>
        /// 背景添加
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int proadd(JiaJiModels.projectitem pro)
        {
            try
            {
                string sql = "insert into projectitem(Pro_Name,Pro_Content,Pro_Img,ProactiveImg1,ProactiveImg2,Pro_Profile,Pro_KeyWord,Pro_Author,Pro_ReadCount,Pro_Date,Pro_Source)VALUES('" + pro.Pro_Name+"','"+pro.Pro_Content+"','"+pro.Pro_Img+"','"+pro.ProactiveImg1+"','"+pro.ProactiveImg2+"','"+pro.Pro_Profile+"','"+pro.Pro_KeyWord+"','"+pro.Pro_Author+"',0,'"+pro.Pro_Date+"','"+pro.Pro_Source+"')";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// 获取背景提升信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.projectitem> ShowProjectitem()
        {
            try
            {
                string sql = "SELECT * from projectitem";
                List<JiaJiModels.projectitem> list = MySqlDB.GetList<JiaJiModels.projectitem>(sql, CommandType.Text, null);



                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 删除背景提升信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelProjectitem(string ProjectitemID)
        {
            try
            {
                string sql = "delete from projectitem where Pro_ID in (" + ProjectitemID + ")";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 背景修改
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public int Updpro(JiaJiModels.projectitem pro)
        {
            try
            {
                string sql = "update projectitem set Pro_Name='"+pro.Pro_Name+"',Pro_Content='"+pro.Pro_Content+ "',Pro_Img='" + pro.Pro_Img+ "',ProactiveImg1='" + pro.ProactiveImg1+ "',ProactiveImg2='" + pro.ProactiveImg2+ "',Pro_Profile='"+pro.Pro_Profile+"',Pro_KeyWord='"+pro.Pro_KeyWord+"',Pro_Author='"+pro.Pro_Author+"',Pro_Date='"+pro.Pro_Date+"',Pro_Source='"+pro.Pro_Source+"' where Pro_ID=" + pro.Pro_ID+"";
                int h = MySqlDB.nonquery(sql, CommandType.Text, null);
                return h;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
