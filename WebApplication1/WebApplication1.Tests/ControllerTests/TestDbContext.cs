using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace ToDoApp.Models
{
    public class TestDbContext : ToDoAppContext
    {
        public override DbSet<Item> Items { get; set; }
        public override DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoAppTest;integrated security = True");
        }
    }

}
