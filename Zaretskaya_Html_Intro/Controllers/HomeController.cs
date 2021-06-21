using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zaretskaya_Html_Intro.Controllers
{
    public class HomeController : Controller
    {
        private List<Demo> _listDemo;

        public HomeController()
        {
            _listDemo = new List<Demo>
            {
                new Demo{ItemValue=1, ItemText="Item 1"},
                new Demo{ItemValue=2, ItemText="Item 2"},
                new Demo{ItemValue=3, ItemText="Item 3"},
            };
        }

        [ViewData]
        public string Text { get; set; }
        public IActionResult Index()
        {
            Text = "Лабораторная работа № 2";
            ViewData["DropdowmList"] = new SelectList(_listDemo, "ItemValue", "ItemText");

            
            return View();
        }
    }


    public class Demo
    {
        public int ItemValue { get; set; }
        public string ItemText { get; set; }
    }
}
