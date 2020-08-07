using System;
using System.Collections.Generic;
using System.Text;

namespace TodoDataAccess.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string BirthDate { get; set; }
    }
}
