using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.ViewModels;

namespace TodoList.Data.SqlDataAccess
{
    public interface IPersonDataAccess
    {
        Task<List<PersonModel>> GetPeople();
        Task<PersonModel> GetPersonByEmail(string emailAddress);
        Task<PersonModel> GetPersonByName(string firstName, string lastName);
        Task<List<PersonModel>> SearchPeopleByName(string firstName, string lastName);
        Task InsertPerson(string lastName, string firstName, string emailAddress = null, string birthDate = null);
    }
}