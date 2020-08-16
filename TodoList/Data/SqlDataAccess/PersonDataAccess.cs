using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TodoDataAccess.DataAccess;
using TodoDataAccess.Models;
using TodoList.ViewModels;
using TodoList.Data.SqlDataAccess;

namespace TodoList.Data.SqlDataAccess
{
    public class PersonDataAccess : IPersonDataAccess
    {
        //This is another example of dependency injection. the constructor signature acts as a dependency list and the IServicesCollection list is the list of services that can fulfill these dependencies when each service gets initialized by the ConfigureServices method in Startup.
        private IPersonData _personData;
        public PersonDataAccess(IPersonData personData)
        {
            _personData = personData;
        }

        public async Task<List<PersonModel>> GetPeople()
        {
            List<PersonModel> peopleModels = new List<PersonModel>();

            List<Person> people = await _personData.GetPeople();

            if (people != null && people.Count > 0)
            {
                foreach (var p in people)
                {
                    peopleModels.Add(MapPersonToPersonModel(p));
                }
            }

            return peopleModels;
        }

        public async Task<PersonModel> GetPersonByEmail(string emailAddress)
        {
            Person p = await _personData.GetPersonByEmail(emailAddress);

            if (p != null)
            {
                return MapPersonToPersonModel(p);
            }
            return null;
        }

        public async Task<PersonModel> GetPersonByName(string firstName, string lastName)
        {
            Person p = await _personData.GetPersonByName(firstName, lastName);

            if (p != null)
            {
                return MapPersonToPersonModel(p);
            }
            return null;
        }

        public async Task<List<PersonModel>> SearchPeopleByName(string firstName, string lastName)
        {
            List<PersonModel> peopleModels = new List<PersonModel>();

            List<Person> people = await _personData.SearchPeopleByName(firstName, lastName);

            if (people != null && people.Count > 0)
            {
                foreach (var p in people)
                {
                    peopleModels.Add(MapPersonToPersonModel(p));
                }
            }

            return peopleModels;
        }

        public Task InsertPerson(string lastName, string firstName, string emailAddress = null, string birthDate = null)
        {
            return _personData.InsertPerson(lastName, firstName, emailAddress, birthDate);
        }

        private PersonModel MapPersonToPersonModel(Person p)
        {
            return new PersonModel
            {
                PersonID = p.PersonID,
                LastName = p.LastName,
                FirstName = p.FirstName,
                EmailAddress = p.EmailAddress,
                BirthDate = p.BirthDate
            };
        }
    }
}
