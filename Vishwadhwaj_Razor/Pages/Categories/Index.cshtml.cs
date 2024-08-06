using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vishwadhwaj_Razor.Data;
using Vishwadhwaj_Razor.Models;

namespace Vishwadhwaj_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public List<Category> categories { get; set; }  
        public void OnGet()
        {
            categories=_context.Categories.ToList();
        }
    }
}
