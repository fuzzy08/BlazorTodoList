using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using TodoDataAccess.Models;

namespace TodoDataAccess.DataAccess
{
    public class SqlCategoryData : ICategoryData
    {
        private IConfiguration _config;

        public SqlCategoryData(IConfiguration config)
        {
            _config = config;
        }


        #region gets
        /// <summary>
        /// Gets All Categories for a PersonID
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public async Task<List<Category>> GetCategoriesByPerson(int personID) //Todo: Allow for a TodoItem to have more than one Category (Many to Many)
        {
            string sql = "SELECT * FROM CATEGORIES WHERE PersonID = @PersonID";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                var output = await connection.QueryAsync<Category>(sql, new { PersonID = personID });

                if (output.Count() != 0)
                    return output.ToList();
            }
            return null;
        }
        #endregion gets
        #region sets
        /// <summary>
        /// Insert a Category for a person's Todo List.
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="title"></param>
        /// <param name="desc">optional</param>
        public Task InsertCategory(int personID, string title, string desc = null)
        {
            //This method returns a task 
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                List<Category> categories = new List<Category>();

                 return connection.ExecuteAsync("dbo.INSERT_CATEGORY @PersonID, @Title, @Description", categories);
            }
        }
        #endregion sets 
    }
}
