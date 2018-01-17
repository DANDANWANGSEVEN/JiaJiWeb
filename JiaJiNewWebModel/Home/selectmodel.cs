using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel.Home
{
    public class selectmodel
    {

        /// <summary>
        /// 活动表
        /// </summary>
        Active activetable = new Active();

        public Active Activetable
        {
            get
            {
                return activetable;
            }

            set
            {
                activetable = value;
            }
        }

        /// <summary>
        /// 资讯表
        /// </summary>
        Information infortable = new Information();
        public Information Infortable
        {
            get
            {
                return infortable;
            }

            set
            {
                infortable = value;
            }
        }



        /// <summary>
        /// 策略表
        /// </summary>
        Strategy strategytable = new Strategy();
        public Strategy Strategytable
        {
            get
            {
                return strategytable;
            }

            set
            {
                strategytable = value;
            }
        }

        
        /// <summary>
        /// 项目
        /// </summary>
        projectItem proitemtable = new projectItem();
        public projectItem Proitemtable
        {
            get
            {
                return proitemtable;
            }

            set
            {
                proitemtable = value;
            }
        }

       
        /// <summary>
        /// 移民项目
        /// </summary>
        Project protable = new Project();
        public Project Protable
        {
            get
            {
                return protable;
            }

            set
            {
                protable = value;
            }
        }

     

        NavInfoModel navtable = new NavInfoModel();
        public NavInfoModel Navtable
        {
            get
            {
                return navtable;
            }

            set
            {
                navtable = value;
            }
        }

    }
}
