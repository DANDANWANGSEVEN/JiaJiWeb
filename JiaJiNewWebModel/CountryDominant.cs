using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 国家优势表
    /// </summary>
    public class CountryDominant
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int CountryDominantID { get; set; }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        /// <summary>
        /// 优势ID
        /// </summary>
        public int DominantID { get; set; }
        /// <summary>
        /// 概率
        /// </summary>
        public string  Chance { get; set; }
        /// <summary>
        /// 优势名称
        /// </summary>
        public string DominantName { get; set; }

        public string countrydominant { get; set; }

        public string CountryImg { get; set; }

        public string CountryActiveImg1 { get; set; }

        public string CountryActiveImg2 { get; set; }


    }
    public class Dominant
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int DominantID { get; set; }
        /// <summary>
        /// 优势名称
        /// </summary>
        public string DominantName { get; set; }
    }
}
