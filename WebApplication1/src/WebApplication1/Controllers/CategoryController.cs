using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoApp.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    public class CategoryController : Controller
    {
        private ToDoAppContext db = new ToDoAppContext();
        private ICategoryRepository categoryRepo;
        //private EFCategoryRepository db2;

        public CategoryController(ICategoryRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.categoryRepo = new EFCategoryRepository();
            }
            else
            {
                this.categoryRepo = thisRepo;
            }
        }

 

        public ViewResult Index()
        {
            return View(categoryRepo.Categories.ToList());
            //return View(itemRepo.Items.Include(x => x.Category).ToList());

        }

        public IActionResult Details(int id)
        {
            var thisItem = categoryRepo.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View(thisItem);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category item)
        {
            categoryRepo.Save(item);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Category thisItem = categoryRepo.Categories.FirstOrDefault(x => x.CategoryId == id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View(thisItem);
        }

        [HttpPost]
        public ActionResult Edit(Category item)
        {
            categoryRepo.Edit(item);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Category thisItem = categoryRepo.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category thisItem = categoryRepo.Categories.FirstOrDefault(x => x.CategoryId == id);
            categoryRepo.Remove(thisItem);
            return RedirectToAction("Index");
        }

        public ActionResult ToggleDone(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            thisItem.Done = !thisItem.Done;
            db.Entry(thisItem).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
