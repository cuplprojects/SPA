using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SPA.Services;
using System;
using SPA.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SPA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SyncController : ControllerBase
    {
        private readonly FirstDbContext _firstDbContext;
        private readonly SecondDbContext _secondDbContext;
        private readonly IConfiguration _configuration;

        public SyncController(FirstDbContext firstDbContext, SecondDbContext secondDbContext, IConfiguration configuration)
        {
            _firstDbContext = firstDbContext;
            _secondDbContext = secondDbContext;
            _configuration = configuration;
        }

        [HttpPost("SyncLogs")]
        public async Task<IActionResult> SyncDatabase()
        {
            try
            {
                var itemsToSync = await _firstDbContext.ChangeLogs.Where(u => u.IsSynced == false).ToListAsync();

                foreach (var item in itemsToSync)
                {
                    var entityType = GetEntityType(item.Table);
                    if (entityType == null)
                    {
                        Console.WriteLine($"Entity type {item.Table} not found.");
                        continue;
                    }

                    var entity = JsonConvert.DeserializeObject(item.LogEntry, entityType);

                    SyncTables syncTables = new SyncTables(_configuration);
                    syncTables.InsertOrUpdate(item.Table, entity, _secondDbContext);

                    item.IsSynced = true; // Mark the item as synced
                }

                await _secondDbContext.SaveChangesAsync();
                await _firstDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return BadRequest("An error occurred while syncing databases");
            }

            try
            {
                var itemsToSync = await _secondDbContext.ChangeLogs.Where(u => u.IsSynced == false).ToListAsync();

                foreach (var item in itemsToSync)
                {
                    var entityType = GetEntityType(item.Table);
                    if (entityType == null)
                    {
                        Console.WriteLine($"Entity type {item.Table} not found.");
                        continue;
                    }

                    var entity = JsonConvert.DeserializeObject(item.LogEntry, entityType);

                    SyncTables syncTables = new SyncTables(_configuration);
                    syncTables.InsertOrUpdate(item.Table, entity, _firstDbContext);

                    item.IsSynced = true; // Mark the item as synced
                }

                await _firstDbContext.SaveChangesAsync();
                await _secondDbContext.SaveChangesAsync();

                return Ok("Database Synced Successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return BadRequest("An error occurred while syncing second database to first database");
            }
        }

        private Type GetEntityType(string tableName)
        {
            // Assuming all entity types are in the same namespace and assembly
            var assembly = Assembly.GetExecutingAssembly();

            // Adjust the table name to match the entity type name
            var entityTypeName = tableName.TrimEnd('s');

            var entityType = assembly.GetTypes().FirstOrDefault(t => t.Name == entityTypeName);
            return entityType;
        }
    }
}
