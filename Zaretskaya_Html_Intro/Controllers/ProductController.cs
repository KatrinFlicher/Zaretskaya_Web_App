using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Zaretskaya_Html_Intro.DAL.Data;
using Zaretskaya_Html_Intro.DAL.Entities;
using Zaretskaya_Html_Intro.Extensions;
using Zaretskaya_Html_Intro.Models;

namespace Zaretskaya_Html_Intro.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;

        int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo=1)
        {
            var drugsFiltered = _context.Drugs
                .Where(d => !group.HasValue || d.GroupId == group.Value);

            ViewData["Groups"] = _context.DrugGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Drug>.GetModel(drugsFiltered, pageNo, _pageSize);
         

            if (Request.IsAjaxRequest()) {
                return PartialView("_listpartial", model);
            }
            else
            {
                return View(model);
            }
        }
    }
}