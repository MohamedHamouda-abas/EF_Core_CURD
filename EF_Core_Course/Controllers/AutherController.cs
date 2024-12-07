using EF_Core_Course_DataAccess.Data;
using EF_Core_Course_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_Course.Controllers
{
    public class AutherController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AutherController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Auther> objList = _context.Authers.Where(c => c.Status == 0).ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Auther objAuther = new();
            if (id == 0 || id == null)
            {
                //Create
                return View(objAuther);
            }
            else
            {
                //Update
                var cat = _context.Authers.FirstOrDefault(c => c.Auther_Id == id);
                if (cat == null)
                {
                    return NotFound();

                }
                return View(cat);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Auther model)
        {
            if (ModelState.IsValid)
            {
                if (model.Auther_Id == 0 || model.Auther_Id == null)
                {
                    //Create
                    _context.Authers.Add(model);
                }
                else
                {
                    //Update                 
                    _context.Authers.Update(model);
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
            var cat = _context.Authers.FirstOrDefault(c => c.Auther_Id == id);
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Auther model)
        {
            model.Status = 1;
            _context.Authers.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
