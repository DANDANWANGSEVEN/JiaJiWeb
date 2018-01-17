using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel
{
    public class NavInfoModel
    {
        public int NavId { get; set; }
        public string NavTitleOne { get; set; }
        public string NavContentOne { get; set; }
        public int NavParentId { get; set; }
        public string NavType { get; set; }
        public int NavIsLevel { get; set; }
        public DateTime NavDate { get; set; }
        public string NavCreateBy { get; set; }
        public int NavHeat { get; set; }
        public string NavTitleTwo { get; set; }
        public string NavContentTwo { get; set; }
        public string GuoJia { get; set; }
        public string BuWei { get; set; }
        public int PaiXu { get; set; }
        public int Depth { get; set; }
        public string LinkFor { get; set; }
        public string KeyWord { get; set; }
    }
}
