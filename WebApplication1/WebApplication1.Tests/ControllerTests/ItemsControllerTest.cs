using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Mvc.Rendering;
using ToDoApp.Controllers;
using ToDoApp.Models;
using Xunit;
using Moq;

namespace WebApplication1.Tests
{
    public class ItemsControllerTest : IDisposable
    {

        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        EFItemRepository db = new EFItemRepository(new TestDbContext());
        EFCategoryRepository db2 =  new EFCategoryRepository(new TestDbContext());
        private void DbSetup()
        {
            Category MyCategory = new Category { CategoryId = 1, Name = "Sweet" };
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Description = "Wash the dog" ,CategoryId=1, Category=MyCategory},
                new Item {ItemId = 2, Description = "Do the dishes",CategoryId=1, Category=MyCategory },
                new Item {ItemId = 3, Description = "Sweep the floor",CategoryId=1, Category=MyCategory }
            }.AsQueryable());
        }

        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ModelList_Index_Test()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public void Post_MethodAddsItem_Test()
        {
            // Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);
            Item testItem = new Item();
            testItem.Description = "Wash the dog";
            testItem.ItemId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            // Assert
            Assert.Contains<Item>(testItem, collection);
        }

        [Fact]
        public void DB_CreateNewEntry_Test()
        {
            // Arrange
            ItemsController controller = new ItemsController(db);
            CategoryController controller2 = new CategoryController(db2);
            Category testCategory = new Category();
            testCategory.Name = "Test Category";
            controller2.Create(testCategory);
            Item testItem = new Item();
            testItem.Description = "TestDb Item";

            testItem.CategoryId = testCategory.CategoryId;
            testItem.Category = testCategory;

            // Act
            controller.Create(testItem);
            var collection = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Item>;

            // Assert
            Assert.Contains<Item>(testItem, collection);
        }

        public void Dispose()
        {
            db.DeleteAll();
        }
    }
}
