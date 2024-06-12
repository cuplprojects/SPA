using Microsoft.EntityFrameworkCore;
using SPA.Models;

namespace SPA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet <User> Users { get; set; }
        public DbSet <UserAuth> UserAuths { get; set; }
        public DbSet <Role> Roles { get; set; }
        public DbSet <Modules> Module {  get; set; }
        public DbSet <Score> Scores { get; set; }
        public DbSet <Reports> Report {  get; set; }
        public DbSet <ResponseConfig> ResponseConfigs { get; set; }
        public DbSet <RegistrationData> RegistrationData { get; set; }
        public DbSet <Project> Projects { get; set; }
        public DbSet <Permission> Permissions { get; set; }
        public DbSet <OMRdata> OMRdata { get; set; }
        public DbSet <CorrectedOMRData> CorrectedOMRData { get; set; }
        public DbSet <Keys> Key {  get; set; }  
        public DbSet <ImageConfig> ImageConfigs { get; set; }
        public DbSet <Absentee> Absentees {  get; set; }
        public DbSet <AmbiguousQues> AmbiguousQue {  get; set; }
        public DbSet <Field> Fields { get; set; }
        public DbSet <Flags> Flag { get; set; }
        public DbSet <FieldConfiguration> FieldsConfig { get; set; }
        public DbSet <MarkingRule> MarkingRules { get; set; }
    }
}
