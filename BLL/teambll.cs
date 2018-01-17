using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiaJiDAL;
using JiaJiModels;

namespace JiaJiBLL
{
   public class teambll
    {
       
        #region 团队标题信息

        public List<JiaJiModels.Team> Titleshow()
        {
            return new JiaJiDAL.teamdal().Titleshow();

        }


        /// <summary>
        /// 获取团队标题
        /// </summary>
        /// <returns></returns>
        public List<JiaJiModels.Team> showTitle()
        {
            try
            {
                return new JiaJiDAL.teamdal().showTitle();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 删除团队标题信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelTeamTitle(string ids)
        {
            try
            {
                return new JiaJiDAL.teamdal().DelTeamTitle(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改tuandui信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateTitle(JiaJiModels.Team model)
        {
            try
            {
                return new JiaJiDAL.teamdal().UpdateTitle(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion

        #region 精英团队

        public List<Team> Team()
        {
            try
            {
                return new JiaJiDAL.teamdal().Team();
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        /// <summary>
        /// 获取团队基本信息
        /// </summary>
        /// <returns></returns>
        public List<Team> GetTeam()
        {
            try
            {
                return new JiaJiDAL.teamdal().GetTeam();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 添加tuandui信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addTeam(JiaJiModels.Team model)
        {
            try
            {
                return new JiaJiDAL.teamdal().addTeam(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 删除团队信息
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public bool DelTeamInfo(string ids)
        {
            try
            {
                return new JiaJiDAL.teamdal().DelTeamInfo(ids);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改团队信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateTeam(JiaJiModels.Team model)
        {
            try
            {
                return new JiaJiDAL.teamdal().UpdateTeam(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 添加标题内容
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int InsertTitle(Team t)
        {
            try
            {
                return new JiaJiDAL.teamdal().InsertTitle(t);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion

    }
}
