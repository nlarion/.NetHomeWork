using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        ToDoAppContext db2 = new ToDoAppContext();
        public EFCategoryRepository(ToDoAppContext connection = null)
        {
            if (connection == null)
            {
                this.db2 = new ToDoAppContext();
            }
            else
            {
                this.db2 = connection;
            }
        }

        public IQueryable<Category> Categories
        { get { return db2.Categories; } }

        public Category Save(Category category)
        {
            db2.Categories.Add(category);
            db2.SaveChanges();
            return category;
        }

        public Category Edit(Category category)
        {
            db2.Entry(category).State = EntityState.Modified;
            db2.SaveChanges();
            return category;
        }

        public void Remove(Category category)
        {
            db2.Categories.Remove(category);
            db2.SaveChanges();
        }

        public void DeleteAll()
        {
            foreach (Category category in db2.Categories)
            {
                db2.Categories.Remove(category);
            }
            db2.SaveChanges();
        }
    }
}