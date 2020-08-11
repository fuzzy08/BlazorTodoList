using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.ViewModels;

namespace TodoList.Data.SqlDataAccess
{
    public interface ITodoItemDataAccess
    {
        Task<List<TodoItemModel>> GetTodoItemsByPerson(int personID);
        Task InsertTodoItem(int personID, string title, int categoryID = 0, string desc = null);
    }
}