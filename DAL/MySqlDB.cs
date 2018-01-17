using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace JiaJiDAL
{
    public class MySqlDB
    {
        private static string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        /// <summary>
        /// 获取list集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(string sql, CommandType type, MySqlParameter[] pars)
        {
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                cmd.CommandType = type;
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                List<T> list =GetTableByList<T>(dt).ToList();
                return list;
            }
        }
        /// <summary>
        /// 获取datatable数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, CommandType type, MySqlParameter[] pars)
        {
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandType = type;
               
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// 将datatable中首行数据放入T中
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T fanshemodel<T>(DataTable dt)where T:new()
        {
            T model = new T();
            Type t = model.GetType();
            foreach (var item in t.GetProperties())
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (item.Name.Equals(dt.Columns[i].ColumnName))
                    {
                        if (dt.Rows[0][i]!=DBNull.Value)
                        {
                            item.SetValue(model, dt.Rows[0][i], null);
                        }
                        else
                        {
                            item.SetValue(model, null, null);
                        }
                    }
                }
            }
            
            return (T)model;
        }
        /// <summary>
        /// 升级版
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        private static  IList<T> GetTableByList<T>(DataTable dt)
        {
            //反射
            IList<T> result = new List<T>();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                T t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo item in propertys)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        //属性与字段名称一致的进行赋值
                        if (item.Name.Equals(dt.Columns[i].ColumnName))
                        {
                            //数据库NULL值单独处理
                            if (dt.Rows[j][i] != DBNull.Value)
                            {
                                item.SetValue(t, dt.Rows[j][i], null);
                            }
                            else
                            {
                                item.SetValue(t, null, null);
                            }
                        }
                    }
                }
                result.Add(t);
            }
            return result;
        }
        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {
            try
            {
                if (entitys == null)
                {
                    return null;
                }

                //检查实体集合不能为空
                if (entitys == null || entitys.Count < 1)
                {
                    throw new Exception("需转换的集合为空");
                }
                //取出第一个实体的所有Propertie
                Type entityType = entitys[0].GetType();
                PropertyInfo[] entityProperties = entityType.GetProperties();

                //生成DataTable的structure
                //生产代码中，应将生成的DataTable结构Cache起来，此处略
                DataTable dt = new DataTable();
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                    dt.Columns.Add(entityProperties[i].Name);
                }
                //将所有entity添加到DataTable中
                foreach (object entity in entitys)
                {
                    //检查所有的的实体都为同一类型
                    if (entity.GetType() != entityType)
                    {
                        throw new Exception("要转换的集合元素类型不一致");
                    }
                    object[] entityValues = new object[entityProperties.Length];
                    for (int i = 0; i < entityProperties.Length; i++)
                    {
                        entityValues[i] = entityProperties[i].GetValue(entity, null);
                    }
                    dt.Rows.Add(entityValues);
                }
                return dt;
            }
            catch (Exception)
            {

                return null;
            }

        }
        /// <summary>
        /// 正常增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static int nonquery(string sql, CommandType type, MySqlParameter[] pars)
        {
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandType = type;
                
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }
                int i = cmd.ExecuteNonQuery();
                return i;
            }
        }
        /// <summary>
        /// 返回首行首列的数字
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static int scalar(string sql, CommandType type, MySqlParameter[] pars)
        {
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                cmd.CommandType = type;
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }

                int i = Convert.ToInt32(cmd.ExecuteScalar());
                return i;
            }
        }
        /// <summary>
        /// 返回首行首列的字符串
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static string scalars(string sql, CommandType type, MySqlParameter[] pars)
        {
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandType = type;
                if (pars != null)
                {
                    cmd.Parameters.AddRange(pars);
                }

                string i = cmd.ExecuteScalar().ToString();
                return i;
            }
        }

        ///// <summary>
        ///// 给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        ///// </summary>
        ///// <param name="connectionString">一个有效的连接字符串</param>
        ///// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        ///// <param name="cmdText">存储过程名称或者sql命令语句</param>
        ///// <param name="commandParameters">执行命令所用参数的集合</param>
        ///// <returns>执行命令所影响的行数</returns>
        //public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        //{
        //    MySqlCommand cmd = new MySqlCommand();
        //    using (MySqlConnection conn = new MySqlConnection(constring))
        //    {
        //        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
        //        int val = cmd.ExecuteNonQuery();
        //        cmd.Parameters.Clear();
        //        return val;
        //    }
        //}

        //public static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        //{
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    cmd.Connection = conn;
        //    cmd.CommandText = cmdText;
        //    if (trans != null)
        //        cmd.Transaction = trans;
        //    cmd.CommandType = cmdType;
        //    if (cmdParms != null)
        //    {
        //        foreach (MySqlParameter parm in cmdParms)
        //            cmd.Parameters.Add(parm.Value);
        //    }
        //}



    }
}
