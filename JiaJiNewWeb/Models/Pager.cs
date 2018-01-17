using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JiaJiNewWeb.Models
{
    public class Pager<T>
    {
        public int PageIndex { set; get; }
        public int PageSize { set; get; }
        public int PageTotal { set; get; }
        public List<T> Model { set; get; }
    }
}