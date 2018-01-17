using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    /// <summary>
    /// 国家图片
    /// </summary>
    public class LunBoImageModel
    {
       
            /// <summary>
            /// 编号
            /// </summary>
            public int LunBoImageID { get; set; }
            /// <summary>
            /// 路径
            /// </summary>
            public string ImageUrl { get; set; }
            /// <summary>
            /// 是否轮播
            /// </summary>
            public int IsLunBo { get; set; }
            /// <summary>
            /// 国家编号
            /// </summary>
            public int CountryID { get; set; }
            public string CountryName { get; set; }
            /// <summary>
            /// 学历编号
            /// </summary>
            public int EducationID { get; set; }
            public string EducationName { get; set; }

    




    }

    /// <summary>
    /// 二维码
    /// </summary>
    public class erweima
    {
        public int EWMID { get; set; }

        public string EWMTitle { get; set; }

        public string EWMUrl { get; set; }

        public DateTime  EWMUpDate { get; set; }
    }




}
