using System.Collections.Generic;
using TodoDataAccess.Models;

namespace TodoDataAccess.DataAccess
{
    public interface ITodoItemData
    {
        List<TodoItem> GetTodoItemsByPerson(int personID);
        void InsertTodoItem(int personID, string title, int categoryID = 0, string desc = null);
    }
}