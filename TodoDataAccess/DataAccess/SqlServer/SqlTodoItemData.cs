using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<TodoItem> GetTodoItemByID(int todoItemID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                string sql = "SELECT * FROM TODOITEM WHERE ID = @todoItemID";
                var output = await connection.QueryAsync<TodoItem>(sql , new { TodoItemID = todoItemID });

                return output.ToList().First();
            }

        }

        /// <summary>
        /// Gets all todo list items given a person's ID
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public async Task<List<TodoItem>> GetTodoItemsByPerson(int personID, int categoryID = 0)
        {
            string sql = "SELECT * FROM TODOITEM WHERE PersonID = @PersonID";
            if (categoryID != 0)
                sql += " AND CategoryID = @CategoryID";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                var output = await connection.QueryAsync<TodoItem>(sql, new { PersonID = personID, CategoryID = categoryID });

                return output.ToList();
            }
        }

        #endregion gets
        #region sets
        /// <summary>
        /// Inserts a Todo Item for a given person
        /// </summary>
        /// <param name="personID"></param>
        /// <param name="categoryID">optional</param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        public Task InsertTodoItem(int personID, string title, int categoryID = 0, string desc = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("TodoList")))
            {
                List<TodoItem> todoItems = new List<TodoItem>();

                todoItems.Add(new TodoItem { PersonID = personID, CategoryID = categoryID, Title = title, Description = desc });

                return connection.ExecuteAsync("dbo.INSERT_TODOITEM @PersonID, CategoryID, @Title, @Description", todoItems);
            }
        }

        #endregion sets
    }
}
