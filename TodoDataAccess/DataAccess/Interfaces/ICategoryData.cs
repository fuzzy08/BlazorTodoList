using System.Collections.Generic;
using System.Threading.Tasks;
using TodoDataAccess.Models;

namespace TodoDataAccess.DataAccess
{
    public interface ICategoryData
    {
        Task<List<Category>> GetCategoriesByPerson(int personID);
        Task InsertCategory(int personID, string title, string desc = null);
    }
}