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
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name must not match the display order");
            }
            
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category CategoryFromDb = _context.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid) { 
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id) { 
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category CategoryFromDb= _context.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(CategoryFromDb);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
