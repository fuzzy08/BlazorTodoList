using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.ViewModels
{
    public class TodoItemModel : ITodoItemModel
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
