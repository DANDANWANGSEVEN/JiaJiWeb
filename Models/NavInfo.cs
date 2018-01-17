using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiaJiModels
{
   public class Country
    {
        public static Dictionary<int, string> Dictionary = new Dictionary<int, string> {
            {1,"美国" },{2,"加拿大" },{3,"英国" },{4,"澳洲" }
        };
    }

    public class NavInfo
    {

        public int NavID { set; get; }
        public string NavTitleOne { set; get; }
        public string NavContentOne { set; get; }
        public int NavParentID { set; get; }
        public string NavTypeID { set; get; }
        public int NavIsLevel { set; get; }
        public DateTime NavDate { set; get; }
        public string NavCreateBy { set; get; }
        public int NavHeat { set; get; }
        public string NavTitleTwo { set; get; }
        public string NavContentTwo { set; get; }
        public string GuoJia { set; get; }
        public string BuWei { set; get; }
        public int PaiXu { set; get; }
        public int depth { set; get; }
        public string LinkFor { set; get; }
        public string KeyWord { get; set; }
    }
}
