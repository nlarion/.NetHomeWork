﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ToDoApp.Models;

namespace WebApplication1.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var item = new Item();
            item.Description = "Wash the dog";

            //Act
            var result = item.Description;

            //Assert
            Assert.Equal("Wash the dog", result);
        }
    }
}
