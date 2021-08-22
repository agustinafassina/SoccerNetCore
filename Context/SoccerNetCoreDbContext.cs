using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoccerNetCore.Models;

namespace SoccerNetCore.Context
{
    public class SoccerNetCoreDbContext :  DbContext, ISoccerNetCoreDbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }

        public SoccerNetCoreDbContext(IConfiguration configuration)
         : base()
        {
            _configuration = configuration;
        }

        public SoccerNetCoreDbContext(IConfiguration configuration, DbContextOptions<SoccerNetCoreDbContext> options)
            : base(options)
        {
            _configuration = configuration;
        }

        public SoccerNetCoreDbContext(DbContextOptions<SoccerNetCoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=soccernetcore");
            }
        }
    }
}
