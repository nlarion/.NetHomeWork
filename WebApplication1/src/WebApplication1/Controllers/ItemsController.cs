﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoApp.Models;
using Microsoft.Data.Entity;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            db.Items.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ToggleDone(int id)
        {
            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            thisItem.Done = !thisItem.Done;
            db.Entry(thisItem).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
