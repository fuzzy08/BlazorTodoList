using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace TodoDataAccess.Models
{
    public class TodoItem
    {
        public int TodoItemID { get; set; }
        public int PersonID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public string CreatedDate { get; set; }
    }
}
