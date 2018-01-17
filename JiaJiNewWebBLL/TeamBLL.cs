using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiNewWebModel;
namespace JiaJiNewWebBLL
{
    public class TeamBLL
    {
        JiaJiNewWebIDAL.ITeamDAL tdal = JiaJiNewWeb.DALFactory.Factory<JiaJiNewWebIDAL.ITeamDAL>.Create("TeamDAL");
        /// <summary>
        /// 团队列表
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        public List<Team> GetTeam(int areaid,int pageindex)
        {
            return tdal.GetTeam(areaid,pageindex);
        }

        /// <summary>
        /// 团队显示成功案例文章
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Team TeamSuccessContent(int Id)
        {
            try
            {
                return tdal.TeamSuccessContent(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// js获取团队行数
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        public int GetRowCounts(int areaid)
        {
            return tdal.GetRowCounts(areaid);
        }
        /// <summary>
        /// 通过团队ID查找其成功案例
        /// </summary>
        /// <param name="teamid">团队ID</param>
        /// <returns></returns>
        public List<SuccessfulAnLi> GetAnliByTeam(int teamid)
        {
            return tdal.GetAnliByTeam(teamid);
        }
     

        public int GetSuccessCount(int Id)
        {
            return tdal.GetSuccessCount(Id);
        }

        public List<Team> SuccessCountList(int pageindex, int teamid)
        {
            try
            {
                return tdal.SuccessCountList(pageindex,teamid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取地区
        /// </summary>
        /// <returns></returns>
        public List<Area> GetArea()
        {
            return tdal.GetArea();
        }
        /// <summary>
        /// 团队首页介绍信息
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.TeamIndexModel> TeamindexList()
        {
            try
            {
                return tdal.TeamindexList();
            }
            catch (System.Exception ex)
            {
                return null;

            }
        }

        /// <summary>
        /// 团队分国家显示
        /// </summary>
        /// <returns></returns>
        public List<JiaJiNewWebModel.TeamIndexModel> CountryTeamList(string countryname)
        {
            try
            {
                return tdal.CountryTeamList(countryname);
            }
            catch (System.Exception ex)
            {
                return null;

            }
        }



        ///<summary>
        ///顾问内页
        ///<para>Id:顾问ID</para>
        /// </summary>
        public Team TeamShow(int Id)
        {
            return tdal.TeamShow(Id);
        }

        /// <summary>
        /// 顾问内容
        /// </summary>
        /// <param name="Id">顾问ID</param>
        /// <returns></returns>
        public List<TeamInfor> ContentShow(int Id)
        {
            return tdal.ContentShow(Id);
        }
        ///<summary>
        ///成功案列
        ///<param name="Id">顾问ID</param>
        /// </summary>
        public string SuccessCount(int Id)
        {
            return tdal.SuccessCount(Id);
        }
       


        /// <summary>
        /// 北京团队
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        public List<Team> GetBeiJingTeam()
        {
            try
            {
                return tdal.GetBeiJingTeam();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 西安团队
        /// </summary>
        /// <param name="areaid">地区ID</param>
        /// <returns></returns>
        public List<Team> GetXiAnTeam()
        {
            try
            {
                return tdal.GetXiAnTeam();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
