using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Data.Common;
using System.Linq;

namespace SPA.Services
{
    public class SyncTables
    {
        private readonly IConfiguration _configuration;

        public SyncTables(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void InsertOrUpdate(string tableName, object entity, DbContext dbContext)
        {
            string query = GenerateInsertOrUpdateQuery(tableName, entity);
            var cmd = dbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = query;

            foreach (var property in entity.GetType().GetProperties())
            {
                var parameter = cmd.CreateParameter();
                parameter.ParameterName = $"@{property.Name}";
                parameter.Value = property.GetValue(entity) ?? DBNull.Value;
                cmd.Parameters.Add(parameter);
            }

            // Log the query and parameters for debugging
            Console.WriteLine($"Executing SQL Query: {cmd.CommandText}");
            foreach (DbParameter param in cmd.Parameters)
            {
                Console.WriteLine($"Parameter: {param.ParameterName}, Value: {param.Value}");
            }

            try
            {
                dbContext.Database.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing the query: {ex.Message}");
            }
            finally
            {
                dbContext.Database.CloseConnection();
            }
        }

        private string GenerateInsertOrUpdateQuery(string tableName, object entity)
        {
            var properties = entity.GetType().GetProperties();
            var columns = string.Join(", ", properties.Select(p => p.Name));
            var parameters = string.Join(", ", properties.Select(p => $"@{p.Name}"));
            var updates = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

            return $@"INSERT INTO {tableName} ({columns}) 
                      VALUES ({parameters}) 
                      ON DUPLICATE KEY UPDATE {updates}";
        }
    }
}
