using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebIDAL
{
    public interface ITeamDAL
    {
        /// <summary>
        /// 团队列表
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        List<Team> GetTeam(int areaid,int pageindex);

        /// <summary>
        /// 团队显示成功案例文章
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Team TeamSuccessContent(int Id);


        /// <summary>
        /// js获取团队行数
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        int GetRowCounts(int areaid);
        /// <summary>
        /// 通过团队ID查找其成功案例
        /// </summary>
        /// <param name="teamid">团队ID</param>
        /// <returns></returns>
        List<SuccessfulAnLi> GetAnliByTeam(int teamid);
        List<Team> SuccessCountList(int pageindex, int teamid);
        //List<Team> TeamXiangQing(int teamid);
        int GetSuccessCount(int Id);
        /// <summary>
        /// 获取地区
        /// </summary>
        /// <returns></returns>
        List<Area> GetArea();

        /// <summary>
        /// 团队首页介绍信息
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.TeamIndexModel> TeamindexList();


        /// <summary>
        /// 团队分国家显示
        /// </summary>
        /// <returns></returns>
        List<JiaJiNewWebModel.TeamIndexModel> CountryTeamList(string countryname);



        ///<summary>
        ///顾问内页
        ///<para>Id:顾问ID</para>
        /// </summary>
        Team TeamShow(int Id);
        /// <summary>
        /// 顾问内容
        /// </summary>
        /// <param name="Id">顾问ID</param>
        /// <returns></returns>
        List<TeamInfor> ContentShow(int Id);

        //List<Team_Title> TitleShow(int Id);

        ///<summary>
        ///成功案列
        ///<param name="Id">顾问ID</param>
        /// </summary>
        string SuccessCount(int Id);

        /// <summary>
        /// 北京团队
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        List<Team> GetBeiJingTeam();

        /// <summary>
        /// 西安团队
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        List<Team> GetXiAnTeam();


    }
}
