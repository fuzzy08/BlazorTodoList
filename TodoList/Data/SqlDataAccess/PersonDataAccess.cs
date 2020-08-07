using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TodoDataAccess.DataAccess;
using TodoDataAccess.Models;
using TodoList.ViewModels;

namespace TodoList.Data.SqlDataAccess
{
    public class PersonDataAccess
    {
        //public async List<PersonModel> GetPeople()
        //{
        //    List<PersonModel> peopleMods = new List<PersonModel>();
        //    SqlPersonData db = new SqlPersonData();

        //    List<Person> people = await db.GetPeople();

        //    if(people != null)
        //    {
        //        foreach (var p in people)
        //        {
        //            peopleMods.Add(new PersonModel
        //            {
        //                PersonID = p.PersonID,
        //                LastName = p.LastName,
        //                FirstName = p.FirstName,
        //                EmailAddress = p.EmailAddress,
        //                BirthDate = p.BirthDate
        //            });
        //        }
        //    }

        //    return peopleMods;
        //}


    }
}
