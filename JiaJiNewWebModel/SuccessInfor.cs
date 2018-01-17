using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    public class SuccessInfor
    {
        ///<summary>
        ///获取案列ID
        /// </summary>
        public int SuccessID { get; set; }
        /// <summary>
        /// 获取国家名
        /// </summary>
        public string CountryName { get; set; }
        ///<summary>
        ///获取学历
        /// </summary>
        public string EducationName { get; set; }
        ///<summary>
        ///获取学生姓名
        /// </summary>
        public string StudentName { get; set; }
        ///<summary>
        ///获取分数
        /// </summary>
        public string Score { get; set; }
        ///<summary>
        ///获取毕业院校
        /// </summary>
        public string JiuDuXueyuan { get; set; }
        ///<summary>
        ///获取成功案列标题
        /// </summary>
        public string SuccessTitle { get; set; }
        ///<summary>
        ///获取成功案列内容
        /// </summary>
        public string SuccessContent { get; set; }
        ///<summary>
        ///获取录取时间
        /// </summary>
        public string SuccessDate { get; set; }
        ///<summary>
        ///获取录取院校
        /// </summary>
        public string CollegeName { get; set; }
        public int CollegeID { get; set; }

    }
}
