using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.ViewModels;

namespace TodoList.Data.DataContracts
{
    public interface IPersonDataAccess
    {
        Task<List<PersonModel>> GetPeople();
    }
}