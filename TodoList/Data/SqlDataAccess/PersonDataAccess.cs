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
using TodoList.Data.DataContracts;

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
            
            if (people != null)
            {
                foreach (var p in people)
                {
                    peopleModels.Add(new PersonModel
                    {
                        PersonID = p.PersonID,
                        LastName = p.LastName,
                        FirstName = p.FirstName,
                        EmailAddress = p.EmailAddress,
                        BirthDate = p.BirthDate
                    });
                }
            }

            return peopleModels;
        }


    }
}
