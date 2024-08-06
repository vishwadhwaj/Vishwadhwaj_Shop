using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vishwadhwaj_Razor.Data;
using Vishwadhwaj_Razor.Models;

namespace Vishwadhwaj_Razor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
                _context = context;
        }
        public Category category { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost() { 
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
