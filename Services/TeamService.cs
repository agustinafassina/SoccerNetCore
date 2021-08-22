using System.Collections.Generic;
using SoccerNetCore.Models;
using SoccerNetCore.Repository;

namespace SoccerNetCore.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public List<Team> GetList()
        {
            return (List<Team>)_teamRepository.ListAll();
        }

        public Team Get(int TeamId)
        {
            return _teamRepository.GetById(TeamId);
        }

        public void Post(Team request)
        {
            _teamRepository.Add(request);
        }
    }
}