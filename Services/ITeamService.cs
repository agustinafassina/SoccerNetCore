using System.Collections.Generic;
using SoccerNetCore.Models;

namespace SoccerNetCore.Services
{
    public interface ITeamService
    {
        List<Team> GetList();
        Team Get(int id);
        void Post(Team request);
    }
}