using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    public class ApplyModel
    {
        public class StudentProgramType
        {
            /// <summary>
            /// 规划ID
            /// </summary>
            public int TypeID { get; set; }
            /// <summary>
            /// 规划类别
            /// </summary>
            public string TypeName { get; set; }
        }
        /// <summary>
        /// 国家申请条件
        /// </summary>
        public class ApplyCondition
        {
            /// <summary>
            /// 申请条件ID
            /// </summary>
            public int ApplyID { get; set; }
            ///<summary>
            ///申请条件
            /// </summary>
            public string ApplyTitle { get; set; }
            ///<summary>
            ///申请条件内容
            /// </summary>
            public string ApplyContent { get; set; }
        }

        /// <summary>
        /// 国家申请条件内容表
        /// </summary>
        public class ApplyContentInfo
        {
            public int ApplyContentID { get; set; }

            public string ApplyContent { get; set; }

            public int CountryID { get; set; }

            public int EducationID { get; set; }

            public int ApplyConditionID { get; set; }
            /// <summary>
            /// 申请条件ID
            /// </summary>
            public int ApplyID { get; set; }
            ///<summary>
            ///申请条件
            /// </summary>
            public string ApplyTitle { get; set; }
        }



        /// <summary>
        /// 留学时间规划
        /// </summary>
        public class ArrangeTime
        {
            /// <summary>
            /// 规划时间ID
            /// </summary>
            public int ArrangeID { get; set; }
            ///<summary>
            ///规划月份
            /// </summary>
            public string ArrangeMonth { get; set; }
            ///<summary>
            ///规划内容
            /// </summary>
            public string ArrangeContent { get; set; }

            public int CountryID { get; set; }
            public string CountryName { get; set; }
            public int EducationID { get; set; }
            public string EducationName { get; set; }

            public int ShowID { get; set; }

        }

        public int ArrangeID { get; set; }

        ///<summary>
        ///规划月份
        /// </summary>
        public string ArrangeMonth { get; set; }
        ///<summary>
        ///规划内容
        /// </summary>
        public string ArrangeContent { get; set; }
        public int CountryID { get; set; }

        public string CountryName { get; set; }


        public int EducationID { get; set; }
        public string EducationName { get; set; }

        public int ShowID { get; set; }
    }

    public class Apply
    {
        public int ApplyID { get; set; }
        public string CountryName { get; set; }
        public string UserName { get; set; }
        public string GoTime { get; set; }
        public string Phone { get; set; }
    }



}
