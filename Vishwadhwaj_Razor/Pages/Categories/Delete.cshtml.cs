using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vishwadhwaj_Razor.Data;
using Vishwadhwaj_Razor.Models;

namespace Vishwadhwaj_Razor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
        {
                _context = context;
        }
        public Category category { get; set; }
        public IActionResult OnGet(int? id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            category=_context.Categories.Find(id);
            if (category == null) {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
