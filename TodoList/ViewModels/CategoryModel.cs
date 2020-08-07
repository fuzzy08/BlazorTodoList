using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.ViewModels
{
    public class CategoryModel : ICategoryModel
    {
        public int CategoryID { get; set; }
        public int PersonID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
