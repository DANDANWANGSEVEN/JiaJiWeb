using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
   public class Team
    {
        /// <summary>
        /// 团队任务ID
        /// </summary>
        public int TeamID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 团队介绍
        /// </summary>
        public string TeamProduce { get; set; }

        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkDate { get; set; }
        /// <summary>
        /// 申请地点
        /// </summary>
        public string ShenQing { get; set; }

        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID { get; set; }
        /// <summary>
        /// 国家名称
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// 标题ID
        /// </summary>
        public int TeamTitleID { get; set; }
        /// <summary>
        /// 标题名称
        /// </summary>
        public string TitleName { get; set; }

        /// <summary>
        /// 内容ID
        /// </summary>
        public int ContentID { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

       /// <summary>
       /// 团队标题内容关系主键ID
       /// </summary>
        public int TermRealID { get; set; }

        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }
       
        /// <summary>
        /// 标题图片
        /// </summary>
        public string Image1 { get; set; }
        /// <summary>
        /// 内容图片
        /// </summary>
        public string Image2 { get; set; }

        /// <summary>
        /// 团队区域关系主键ID
        /// </summary>
        public int TRelationID { get; set; }

        public int AreaRelaID { get; set; }

        public string SuccessCount { get; set; }
        /// <summary>
        /// 成功案例的内容
        /// </summary>
        public string SuccessContent { get; set; }
        /// <summary>
        /// 成功案例关键字
        /// </summary>
        public string SuccessKeyWord { get; set; }
        /// <summary>
        /// 成功案例简介
        /// </summary>
        public string SuccessProfile { get; set; }
    }
}
