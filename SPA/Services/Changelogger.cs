using SPA.Data;
using SPA.Models;

namespace SPA.Services
{
    public class Changelogger : IChangeLogger
    {
        private readonly FirstDbContext _firstDbContext;
        private readonly SecondDbContext _secondDbContext;

        public Changelogger(FirstDbContext firstDbContext, SecondDbContext secondDbContext)
        {
            _firstDbContext = firstDbContext;
            _secondDbContext = secondDbContext;
        }

        public void LogForDBSync(string Category,string Table ,string LogEntry, string WhichDatabase)
        {
            int ChangeLogID = Randomizer.Randomize(10000000);
            ChangeLog log = new ChangeLog()
            {
                ChangeLog_Id = ChangeLogID,
                Category = Category,
                Table = Table,
                LogEntry = LogEntry
                
            };

            if (WhichDatabase == "Local")
            {
                _firstDbContext.ChangeLogs.Add(log);
                _firstDbContext.SaveChanges();
            }
            else if (WhichDatabase == "Online")
            {
                _secondDbContext.ChangeLogs.Add(log);
                _secondDbContext.SaveChanges();
            }

        }
    }
}
