using System.Collections.Generic;
using System.Linq;
using SoccerNetCore.Context;
using SoccerNetCore.Models;

namespace SoccerNetCore.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly SoccerNetCoreDbContext _dbContext = null;

        public TeamRepository(SoccerNetCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Team team)
        {
            _dbContext.Add(team);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Team> ListAll() => _dbContext.Team.ToList();
        public Team GetById(int id) => _dbContext.Team.Find(id);
    }
}