using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    public class ItemsController : Controller
    {
        private ToDoAppContext db = new ToDoAppContext();
        public IActionResult Index()
        {
            return View(db.Items.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }
    }
}
