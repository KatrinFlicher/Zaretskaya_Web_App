using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zaretskaya_Html_Intro.Models
{
    public class MenuItem
    {
        //Is it page or controller method?
        public bool IsPage { get; set; } = false;

        //Area name
        public string Area { get; set; } = "";

        //Controller action name
        public string Action { get; set; } = "";

        //Controller name
        public string Controller { get; set; } = "";

        //Page name
        public string Page { get; set; } = "";

        //CSS class for current menu item
        public string Active { get; set; } = "";

        //Item content
        public string Text { get; set; } = "";
    }
}
