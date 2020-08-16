using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using TodoDataAccess.Models;

namespace TodoDataAccess.DataAccess
{
    public interface IPersonData
    {
        Task<List<Person>> GetPeople();
        Task<Person> GetPersonByEmail(string emailAddress);
        Task<Person> GetPersonByName(string firstName, string lastName);
        Task<List<Person>> SearchPeopleByName(string firstName, string lastName);
        Task InsertPerson(string lastName, string firstName, string emailAddress = null, string birthDate = null);
    }
}