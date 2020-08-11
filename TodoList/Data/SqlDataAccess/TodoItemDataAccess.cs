using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoDataAccess.DataAccess;
using TodoDataAccess.Models;
using TodoList.ViewModels;

namespace TodoList.Data.SqlDataAccess
{
    public class TodoItemDataAccess : ITodoItemDataAccess
    {
        private ITodoItemData _todoData;

        public TodoItemDataAccess(ITodoItemData todoData)
        {
            _todoData = todoData;
        }

        public async Task<List<TodoItemModel>> GetTodoItemsByPerson(int personID)
        {
            List<TodoItemModel> todoModels = new List<TodoItemModel>();

            List<TodoItem> todos = await _todoData.GetTodoItemsByPerson(personID);

            if (todos != null && todos.Count > 0)
            {
                foreach (var t in todos)
                {
                    todoModels.Add(MapTodoItemToTodoItemModel(t));
                }
            }

            return todoModels;
        }

        public Task InsertTodoItem(int personID, string title, int categoryID = 0, string desc = null)
        {
            //you could change the parameter of the data access method to be just TodoItem but that's not really making the code easier, just shifting where the object is instantiated, so I guess don't do it. 
            return _todoData.InsertTodoItem(personID, title, categoryID, desc);
        }

        private TodoItemModel MapTodoItemToTodoItemModel(TodoItem t)
        {
            if (t != null)
            {
                return new TodoItemModel
                {
                    TodoItemID = t.TodoItemID,
                    PersonID = t.PersonID,
                    CategoryID = t.CategoryID,
                    Title = t.Title,
                    Description = t.Description,
                    Completed = t.Completed,
                    CreatedDate = t.CreatedDate
                };
            }
            return null;
        }
    }
}
