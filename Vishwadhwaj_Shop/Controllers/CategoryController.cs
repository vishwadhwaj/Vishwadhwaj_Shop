using Microsoft.AspNetCore.Mvc;
using Vishwadhwaj_Shop.Data;
using Vishwadhwaj_Shop.Models;

namespace Vishwadhwaj_Shop.Controllers
{
    public class CategoryController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
