using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.ViewModels;

namespace TodoList.Data.SqlDataAccess
{
    public interface ICategoryDataAccess
    {
        Task<List<CategoryModel>> GetCategoriesByPerson(int personID);
        Task InsertCategory(int personId, string title, string desc = null);
    }
}