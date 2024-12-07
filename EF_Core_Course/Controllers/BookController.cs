using EF_Core_Course_DataAccess.Data;
using EF_Core_Course_Model.Models;
using EF_Core_Course_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Course.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Book> objList = _context.Books.Include(u=>u.Publisher).ToList();
            //foreach (var pub in objList)
            //{
                //this is old way
                //pub.Publisher=_context.Publishers.Find(pub.Publisher_Id);
                //To push all the recored at the same time
                //_context.Entry(pub).Reference(u => u.Publisher).Load();
            //}
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM objBook = new();

            objBook.PuplisherList = _context.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });
            if (id == 0 || id == null)
            {
                //Create
                return View(objBook);
            }
            else
            {
                //Update
                objBook.Book = _context.Books.FirstOrDefault(c => c.BookId == id);
                if (objBook == null)
                {
                    return NotFound();

                }
                return View(objBook);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM model)
        {
            if (model.Book.BookId == 0 || model.Book.BookId == null)
            {
                //Create
                _context.Books.Add(model.Book);
            }
            else
            {
                //Update                 
                _context.Books.Update(model.Book);
                if (model == null)
                {
                    return NotFound();
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            BookDetila objBook = new();
            objBook = _context.bookDetilas.Include(u=>u.Book).FirstOrDefault(c => c.BookDetila_Id == id);
            //Update
                if (objBook == null)
                {
                    return NotFound();

                }
                return View(objBook);          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookDetila model)
        {
            if (model.BookDetila_Id == 0)
            {
                _context.bookDetilas.Add(model);
            }
            else
            {
                //Update                 
                _context.bookDetilas.Update(model);
                if (model == null)
                {
                    return NotFound();
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            var cat = _context.Books.FirstOrDefault(c => c.BookId == id);
            _context.Books.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
