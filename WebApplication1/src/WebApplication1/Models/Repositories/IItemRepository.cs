﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public interface IItemRepository
    {
        IQueryable<Item> Items { get; }
        Item Save(Item item);
        Item Edit(Item item);
        void Remove(Item item);
    }
}
