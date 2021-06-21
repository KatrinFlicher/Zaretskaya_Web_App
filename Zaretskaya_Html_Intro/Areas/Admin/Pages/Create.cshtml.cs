using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zaretskaya_Html_Intro.DAL.Data;
using Zaretskaya_Html_Intro.DAL.Entities;

namespace Zaretskaya_Html_Intro.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Zaretskaya_Html_Intro.DAL.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
        ViewData["GroupId"] = new SelectList(_context.DrugGroups, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Drug Drug { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Drugs.Add(Drug);
            await _context.SaveChangesAsync();

            if(Image != null)
            {
                var fileName = $"{Drug.Id}" + Path.GetExtension(Image.FileName);
                Drug.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "images", fileName);
                using(var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
