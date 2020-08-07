using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using TodoDataAccess.Models;

namespace TodoDataAccess.DataAccess
{
    public class SqlTodoItemData : ITodoItemData
    {
        private IConfiguration _config;
        public SqlTodoItemData(IConfiguration config)
        {
            _config = config;
        }
        #region gets
        /// <summary>
        /// Gets all todo list items given a person's ID
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public List<TodoItem> GetTodoItemsByPerson(int personID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                var output = connection.Query<TodoItem>("dbo.GET_TODOITEMSBYPERSON @PersonID", new { PersonID = personID }).ToList();

                return output;
            }
        }

        #endregion gets
        /// <summary>
        /// Inserts a Todo Item for a given person
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="categoryID">optional</param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        #region sets
        public void InsertTodoItem(int personID, string title, int categoryID = 0, string desc = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                List<TodoItem> todoItems = new List<TodoItem>();

                todoItems.Add(new TodoItem { PersonID = personID, CategoryID = categoryID, Title = title, Description = desc });

                connection.Execute("dbo.INSERT_TODOITEM @PersonID, CategoryID, @Title, @Description", todoItems);
            }
        }

        #endregion sets
    }
}
