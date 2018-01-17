using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JiaJiNewWebDAL
{
    public class Help
    {
        /// <summary>
        /// 提取汉字
        /// </summary>
        /// <returns></returns>
        public static string Chinese(string content)
        {
            string v = string.Empty;
            string pattern = @"^[\u300a\u300b]|[\u4e00-\u9fa5]|[\uFF00-\uFFEF]";

            if (System.Text.RegularExpressions.Regex.IsMatch(content, pattern))
            {
                //提示的代码在这里写
                Match m = Regex.Match(content, pattern);
                v = "";
                while (m.Success)
                {
                    if (m.Value == ",")
                    {
                        v += m.Value;
                        continue;
                    }
                    v += m.Value;
                    m = m.NextMatch();
                }
            }
            return v;

        }
    }
}
