using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        Category Save(Category item);
        Category Edit(Category item);
        void Remove(Category item);
    }
}
