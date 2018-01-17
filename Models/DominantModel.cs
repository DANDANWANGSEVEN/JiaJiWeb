using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    public class DominantModel
    {
        /// <summary>
        /// 优势名称
        /// </summary>
        public string DominantName { get; set; }
        ///<summary>
        ///国家ID
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// 国家名
        /// </summary>
        public string CountryName { get; set; }
        ///<summary>
        ///优势ID
        /// </summary>
        public int DominantID { get; set; }
        ///<summary>
        ///录取率
        /// </summary>
        public string Chance { get; set; }


        public int CountryDominantID { get; set; }

    }
}
