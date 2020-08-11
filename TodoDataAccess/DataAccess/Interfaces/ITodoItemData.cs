﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TodoDataAccess.Models;

namespace TodoDataAccess.DataAccess
{
    public interface ITodoItemData
    {
        Task<List<TodoItem>> GetTodoItemsByPerson(int personID);
        Task InsertTodoItem(int personID, string title, int categoryID = 0, string desc = null);
    }
}