using EF_Core_Course_DataAccess.Data;
using EF_Core_Course_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_Course.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PublisherController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Publisher> objList = _context.Publishers.Where(c => c.Status == 0).ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher objPublisher = new();
            if (id == 0 || id == null)
            {
                //Create
                return View(objPublisher);
            }
            else
            {
                //Update
                var cat = _context.Publishers.FirstOrDefault(c => c.Publisher_Id == id);
                if (cat == null)
                {
                    return NotFound();

                }
                return View(cat);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher model)
        {
            if (ModelState.IsValid)
            {
                if (model.Publisher_Id == 0 || model.Publisher_Id == null)
                {
                    //Create
                    _context.Publishers.Add(model);
                }
                else
                {
                    //Update                 
                    _context.Publishers.Update(model);
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
            var cat = _context.Publishers.FirstOrDefault(c => c.Publisher_Id == id);
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Publisher model)
        {
            model.Status = 1;
            _context.Publishers.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
