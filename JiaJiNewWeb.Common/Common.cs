//using JiaJiNewWeb.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace JiaJiNewWeb.Common
{
    public class Common
    {
        //public static Model.UserTable NowUser = null;
        public static bool IsRunning = false;
        static int _FistPageReDianCount = 0;
        //public static Model.UserSubmit userSubmit = null;        /// <summary>
                                                                 /// 图片根目录
                                                                 /// </summary>
        //public static string ArticlePicGenMuLu
        //{
        //    get
        //    {
        //        string path = System.Windows.Forms.Application.StartupPath + "//imange";
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        return path;
        //    }
        //}
        /// 配置文件根目录
        /// </summary>
        public static string PeiZhi
        {
            get
            {
                string path = "";//System.Windows.Forms.Application.StartupPath + "//PeiZhi";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }
        /// <summary>
        /// 首页文章热点数
        /// </summary>
        public static int FistPageReDianCount
        {
            get
            {

                if (_FistPageReDianCount == 0)
                {
                    _FistPageReDianCount = int.Parse(ReaderINIBySection("连接条数", "首页"));
                }
                return _FistPageReDianCount;
            }
        }
        static int _ArticlePageReDianCount = 0;
        /// <summary>
        /// 文章连接热点数
        /// </summary>
        public static int ArticlePageReDianCount
        {
            get
            {

                if (_ArticlePageReDianCount == 0)
                {
                    _ArticlePageReDianCount = int.Parse(ReaderINIBySection("连接条数", "文章页"));
                }
                return _ArticlePageReDianCount;
            }
        }
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string ReaderINIBySection(string sectionName, string keyName)
        {
            string filePath = string.Empty;
            try
            {
                filePath = System.Web.HttpContext.Current.Request.MapPath("/");
            }
            catch (Exception)
            {
                filePath = "";//System.Windows.Forms.Application.StartupPath + "//";
            }

            filePath += "PeiZhi\\peizhi.ini";
            return PeaceDream.OperationINIFiles.ReadIniData(sectionName, keyName, "", filePath, 102400);
        }
        public static void WriteINIBySection(string sectionName, string keyName, string value)
        {
            string filePath = string.Empty;
            try
            {
                filePath = System.Web.HttpContext.Current.Request.MapPath("/");
            }
            catch (Exception)
            {
                filePath = "";//System.Windows.Forms.Application.StartupPath + "//";
            }
            filePath += "PeiZhi\\peizhi.ini";
            PeaceDream.OperationINIFiles.WriteIniData(sectionName, keyName, value, filePath);
        }
        /// <summary>
        /// 读取INI文件,传入文件名称
        /// </summary>
        /// <param name="FileName">配置文件名称</param>
        /// <param name="sectionName"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string ReaderINIBySection(string FileName, string sectionName, string keyName)
        {
            string filePath = System.Web.HttpContext.Current.Request.MapPath("/");
            string extension = Path.GetExtension(FileName);
            if (extension.ToLower() == ".ini")
            {
                filePath += "PeiZhi\\" + FileName;
            }
            else
            {
                filePath += "PeiZhi\\" + FileName + ".ini";
            }
            return PeaceDream.OperationINIFiles.ReadIniData(sectionName, keyName, "", filePath, 102400);
        }
        /// <summary>   
        /// 得到字符串的长度，一个汉字算2个字符   
        /// </summary>   
        /// <param name="str">字符串</param>   
        /// <returns>返回字符串长度</returns>   
        public static int GetLength(string str)
        {
            if (str.Length == 0) return 0;

            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
            }

            return tempLen;
        }
        /// <summary>
        /// 原字符串截取 截取之后补充
        /// </summary>
        /// <param name="str"></param>
        /// <param name="leght"></param>
        /// <param name="buStr"></param>
        /// <returns></returns>
        public static string GetStringByLeght(string str, int leght, string buStr)
        {
            StringBuilder result = new StringBuilder();
            int sumCount = 0;
            foreach (char item in str)
            {
                bool isChina = CheckChinese(item);
                int itemCount = isChina ? 2 : 1;
                if ((sumCount + itemCount) < leght)
                {
                    sumCount += itemCount;
                    result.Append(item);
                }
                else
                {
                    sumCount += item;
                    break;
                }

            }
            if (sumCount > leght)
            {
                result.Append(buStr);
            }
            return result.ToString();


        }
        public static string GetDataTimeNianYueRi(DateTime dt)
        {

            return dt.Year + "-" + dt.Month + "-" + dt.Day;
        }
        /// <summary>
        /// 判断是否为中文
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool CheckChinese(char word)
        {
            if ((word >= 0x4e00) && (word <= 0x9fbb)) return true;
            else return false;
        }
        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="errorStr"></param>
        /// <param name="ct"></param>
        /// <param name="balloonTip1"></param>
        //public static void ShowToolTipStr(string errorStr, System.Windows.Forms.Control ct, DevComponents.DotNetBar.BalloonTip balloonTip1)
        //{
        //    balloonTip1.BalloonFocus = false;
        //    balloonTip1.AutoCloseTimeOut = 2;
        //    balloonTip1.SetBalloonCaption(ct, "提示信息");
        //    balloonTip1.SetBalloonText(ct, errorStr);
        //    balloonTip1.ShowBalloon(ct);
        //}
        //public static string RtfToText(string rtfCode)
        //{
        //    string tmp = "";
        //    PeaceDream.RichtextBoxTable rtfObj = new PeaceDream.RichtextBoxTable();
        //    rtfObj.Rtf = rtfCode;
        //    tmp = rtfObj.Text;
        //    rtfObj.Dispose();
        //    return tmp;
        //}

    }
    public enum LiuXueZiXun
    {
        ZhuanJiaShiJiao = 1,
        LiuXueShengHuo,
        ReMenZiXun,
        ChengGongAnli,
        YingGuoLiuXue,
        AoZouLiuXue,
        JiaNaDaLiuXue,
        TouZhiYiMing,
        QuYuZhongXin,
        MuBiaoJiaoYe
    }

   

}
