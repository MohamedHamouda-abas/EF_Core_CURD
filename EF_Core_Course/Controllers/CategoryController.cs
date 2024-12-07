using EF_Core_Course_DataAccess.Data;
using EF_Core_Course_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_Course.Controllers
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
            List<SubCategory> objList = _context.SubCategories.Where(c => c.Status == 0).ToList();
            return View(objList);
        }
        public IActionResult Upsert(int? id)
        {
            SubCategory objCategory = new();
            if (id == 0 || id == null)
            {
                //Create
                return View(objCategory);
            }
            else
            {
                //Update
                var cat = _context.SubCategories.FirstOrDefault(c => c.SubCategory_Id == id);
                if (cat == null )
                {
                    return NotFound();

                }
                return View(cat);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SubCategory model)
        {
            if (ModelState.IsValid)
            {
                if (model.SubCategory_Id == 0 || model.SubCategory_Id == null)
                {
                    //Create
                    _context.SubCategories.Add(model);
                }
                else
                {
                    //Update                 
                    _context.SubCategories.Update(model);
                    if (model == null)
                    {
                        return NotFound();
                    }
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var cat = _context.SubCategories.FirstOrDefault(c => c.SubCategory_Id == id);
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(SubCategory model)
        {
            model.Status = 1;
            _context.SubCategories.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
