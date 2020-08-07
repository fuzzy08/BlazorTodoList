using System;
using System.Collections.Generic;
using System.Text;

namespace TodoDataAccess.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public int PersonID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
