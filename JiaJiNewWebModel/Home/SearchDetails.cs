using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiaJiNewWebModel.Home
{
    public class SearchDetails
    {
        public int ActiveID { set; get; }
        public string ActiveTitle { set; get; }
        public string Datails { set; get; }
        public string activetable { set; get; }


        //public static string active = "/Content/ActiveShow";
        //public static string information = "/Content/ContentShow";
        //public static string strategy = "/Content/Strategy";

        string[] keys = { "active", "information", "strategy", "navinfo" };
        string[] values = { "/Content/Active", "/Content/Content", "/Content/StrategyShow", "/NavLinks/NavLinks" };
        // This method finds the day or returns -1
        private string GetDay(string key)
        {

            for (int j = 0; j < keys.Length; j++)
            {
                if (keys[j] == key)
                {
                    return values[j];
                }
            }

            throw new System.ArgumentOutOfRangeException(key, "testDay must be in the form \"Sun\", \"Mon\", etc");
        }

        // The get accessor returns an integer for a given string
        public string this[string key]
        {
            get
            {
                return (GetDay(key));
            }
        }
    }
}
