using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWeb.Common
{
    public class Log4netHelper
    {

        //说明：首先在 Common层、View层引用Apache log4net程序包


        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        /// <summary>
        /// 生成正确日志
        /// </summary>
        /// <param name="info"></param>
        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }
        /// <summary>
        /// 生成错误日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public static void WriteLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            }
        }


    }
}
