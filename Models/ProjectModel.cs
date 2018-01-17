using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiModels
{
    public class ProjectModel
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>
        public string ProjectTitle { get; set; }
        /// <summary>
        /// 项目内容
        /// </summary>
        public string ProjectContent { get; set; }
        ///<sum>
        ///项目标题（英）
        public string EnglistName { get; set; }
        /// <summary>
        /// 项目时间
        /// </summary>
        public string Date { get; set; }
        ///<summary>
        ///项目图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 移民简介
        /// </summary>
        public string ProjectProfile { get; set; }
        /// <summary>
        /// 移民关键字
        /// </summary>
        public string ProjectKeyWord { get; set; }
        /// <summary>
        /// 移民阅读量
        /// </summary>
        public int ProjectReadCount { get; set; }
        /// <summary>
        /// 移民作者
        /// </summary>
        public string ProjectAuthor { get; set; }
        /// <summary>
        /// 背景来源
        /// </summary>
        public string ProjectSource { get; set; }


    }
}
