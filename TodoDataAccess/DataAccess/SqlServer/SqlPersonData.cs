using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using TodoDataAccess.Models;

namespace TodoDataAccess.DataAccess
{

    /*
     * Notes on Async methods:
     * - the await keyword frees up the caller to continue executing code after the call.
     * - you can use a Task.Run(syncMethod) to turn a sync method call into an async call 
     * - Task.WhenAll is used to await for a list of tasks to be completed
     */

    public class SqlPersonData : IPersonData
    {

        //This is dependency injection. it seems you can specify dependencies in the constructor and the application will inject whatever properties it has that match the dependency.
        //The referenced dependency "must be registered in the service container." https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1
        //The IConfiguration dependency is automatically registered in the service container. This happens in Startup.ConfigureServices()
        private IConfiguration _config;
        public SqlPersonData(IConfiguration config)
        {
            _config = config;
        }

        #region gets
        /// <summary>
        /// Returns all person rows in the Person table.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Person>> GetPeople()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                //unfortunately, we need to return a list, not an IEnumerable, and therefore have to await the output so we can return a different type
                var output = await connection.QueryAsync<Person>("dbo.GET_PEOPLE");

                return output.ToList();
            }
        }
        /// <summary>
        /// Returns the first person from the Person table with a matching email address.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public async Task<Person> GetPersonByEmail(string emailAddress)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                //the query always returns an IEnumerable, but it's understood that this query will only ever return one result.
                var output = await connection.QueryAsync<Person>("dbo.GET_PERSONBYEMAIL @Email", new { Email = emailAddress });

                return output.ToList().First();
            }
        }
        /// <summary>
        /// returns the first person from the Person table that matches the supplied first and last name.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public async Task<Person> GetPersonByName(string firstName, string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                //the query always returns an IEnumerable, but it's understood that this query will only ever return one result.
                var output = await connection.QueryAsync<Person>("dbo.GET_PERSONBYNAME @LastName, @FirstName", new { LastName = lastName, FirstName = firstName });

                return output.ToList().First();
            }
        }
        /// <summary>
        /// returns a list of people from the Person table that matches the supplied first and last name.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public async Task<List<Person>> SearchPeopleByName(string firstName, string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                var output = await connection.QueryAsync<Person>("dbo.SEARCH_PEOPLEBYNAME @LastName, @FirstName", new { LastName = lastName, FirstName = firstName });

                return output.ToList();
            }
        }

        #endregion gets

        #region sets
        /// <summary>
        /// Inserts a new row into the Person table with the supplied parameters.
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="emailAddress">optional</param>
        /// <param name="birthDate">optional</param>
        public Task InsertPerson(string lastName, string firstName, string emailAddress = null, string birthDate = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConfigurationManagerHelper.DBConn("Person")))
            {
                List<Person> people = new List<Person>();
                //Todo: figure out the mumbo jumbo about converting a string to a date or just fucking make the prop a date?
                people.Add(new Person { LastName = lastName, FirstName = firstName, EmailAddress = emailAddress, BirthDate = birthDate });

                //the parameters are filled in by the properties in the class if the names match up.
                //returning this instead of awaiting it frees up this singleton to handle other requests.
                return connection.ExecuteAsync("dbo.PERSON_INSERTPERSON @LastName, @FirstName, @emailAddress, @BirthDate", people);
            }
        }
        #endregion sets
    }
}
