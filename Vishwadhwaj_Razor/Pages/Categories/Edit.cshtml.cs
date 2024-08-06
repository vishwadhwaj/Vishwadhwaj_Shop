using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vishwadhwaj_Razor.Data;
using Vishwadhwaj_Razor.Models;

namespace Vishwadhwaj_Razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
                _context = context;
        }

        public Category category { get; set; }
        public void OnGet(int? id)
        {
            if(id!=0 || id != null)
            {
                category = _context.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }   
    }
}
