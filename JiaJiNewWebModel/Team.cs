using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{

    /// <summary>
    /// 团队表（关系地区）
    /// </summary>
   public  class Team
    {
        /// <summary>
        /// 团队主键编号
        /// </summary>
        public int TeamID { get; set; }
        /// <summary>
        /// 团队人员姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 该人员从事职位
        /// </summary>
        public string  Position { get; set; }
        /// <summary>
        /// 团队介绍
        /// </summary>
        public string TeamProduce { get; set; }
        /// <summary>
        /// 该人员从事时间
        /// </summary>
        public string  WorkDate { get; set; }
        /// <summary>
        /// 擅长申请
        /// </summary>
        public string ShenQing { get; set; }
        /// <summary>
        /// 内容介绍
        /// </summary>
        public  string Content { get; set; }
        /// <summary>
        /// 所属地区ID
        /// </summary>
        public int AreaID { get; set; }
        public int Site { get; set; }
        /// <summary>
        /// 所属地区名称
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 首页显示1
        /// </summary>
        public string Image1 { get; set; }
        /// <summary>
        /// 内页显示2
        /// </summary>
        public string Image2 { get; set; }

        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public int EducationID { get; set; }
        public string EducationName { get; set; }

        public int SuceessID { get; set; }
        public string SuccessTitle { get; set; }

        public int StudentID { get; set; }
        public string StudentName { get; set; }

        public string Score { get; set; }

        public int CollegeID { get; set; }
        public string CollegeName { get; set; }
        public string CollegeImg { get; set; }

        public int SRelationID { get; set; }
        /// <summary>
        /// 成功案例个数
        /// </summary>
        public string SuccessCount { get; set; }

        /// <summary>
        /// 成功案例内容
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


    /// <summary>
    /// 团队介绍标题表
    /// </summary>
    public class Team_Title
    {
        /// <summary>
        /// 团队标题主键编号
        /// </summary>
        public int TeamTitleID { get; set; }
        /// <summary>
        /// 团队标题
        /// </summary>
        public string TitleName { get; set; }

    }

    /// <summary>
    /// 团队介绍内容表
    /// </summary>
    public class Team_Content
    {
        /// <summary>
        /// 内容主键编号
        /// </summary>
        public int ContentID { get; set; }
        /// <summary>
        /// 团队介绍内容
        /// </summary>
        public string Content { get; set; }

    }


    /// <summary>
    /// 团队介绍关系表
    /// </summary>
    public class Team_Relation
    {
        /// <summary>
        /// 团队介绍关系主键
        /// </summary>
        public int TeamRelationID { get; set; }
        /// <summary>
        /// 团队主键
        /// </summary>
        public int TeamID { get; set; }
        /// <summary>
        /// 团队标题主键
        /// </summary>
        public int TeamTitleID { get; set; }
        /// <summary>
        /// 内容主键
        /// </summary>
        public int ContentID { get; set; }


    }

    /// <summary>
    /// 区域表
    /// </summary>
    public class Area
    {
        /// <summary>
        /// 区域主键编号
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public String AreaName { get; set; }
    }


    /// <summary>
    /// 团队区域关系表
    /// </summary>
    public class TeamAreaRelation
    {
        /// <summary>
        /// 团队区域关系主键
        /// </summary>
        public int AreaRelaID { get; set; }
        /// <summary>
        /// 团队主键
        /// </summary>
        public int TeamID { get; set; }
        /// <summary>
        /// 区域主键
        /// </summary>
        public int AreaID { get; set; }


    }

    /// <summary>
    /// 团队学生关系表
    /// </summary>
    public class TeamStuRelation
    {
        /// <summary>
        /// 团队学生关系主键
        /// </summary>
        public int TeamStuRelationID { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public int TeamID { get; set; }
        /// <summary>
        /// 学生编号
        /// </summary>
        public int StudentID { get; set; }
    }

    /// <summary>
    /// 团队图片关系表
    /// </summary>
    public class Team_ImageRelation
    {
        /// <summary>
        /// 团队关系主键
        /// </summary>
        public int Team_ImageRelaID { get; set; }
        /// <summary>
        /// 图片编号
        /// </summary>
        public int ImageID { get; set; }
        /// <summary>
        /// 标识列  1显示标题，2具体内容
        /// </summary>
        public int Identity { get; set; }
        /// <summary>
        /// 团队编号
        /// </summary>
        public int TeamID { get; set; }
    }

}
