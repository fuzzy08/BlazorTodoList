using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TodoDataAccess.DataAccess;
using TodoDataAccess.Models;
using TodoList.ViewModels;

namespace TodoList.Data.SqlDataAccess
{
    public class CategoryDataAccess : ICategoryDataAccess
    {
        private ICategoryData _catData;
        public CategoryDataAccess(ICategoryData catData)
        {
            _catData = catData;
        }

        public async Task<List<CategoryModel>> GetCategoriesByPerson(int personID)
        {
            List<CategoryModel> catModels = new List<CategoryModel>();

            List<Category> cats = await _catData.GetCategoriesByPerson(personID);

            if (cats != null && cats.Count > 0)
            {
                foreach (var c in cats)
                {
                    catModels.Add(MapCategoryToCategoryModel(c));
                }
            }
            return catModels;
        }

        public Task InsertCategory(int personId, string title, string desc = null)
        {
            return _catData.InsertCategory(personId, title, desc);
        }

        private CategoryModel MapCategoryToCategoryModel(Category c)
        {
            if (c != null)
            {
                return new CategoryModel
                {
                    CategoryID = c.CategoryID,
                    PersonID = c.PersonID,
                    Title = c.Title,
                    Description = c.Description
                };
            }
            return null;
        }
    }
}
