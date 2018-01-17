using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
namespace JiaJiNewWeb.DALFactory
{
    /// <summary>
    /// 工厂层
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Factory<T>
    {
        private static readonly string AssemblyName = ConfigurationManager.AppSettings["Assembly"];
        /// <summary>
        /// 反射工厂类
        /// </summary>
        /// <param name="classname">类名</param>
        /// <returns></returns>
        public static T Create(string classname)
        {
            
            string className = AssemblyName + "."+classname;
            return (T)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
