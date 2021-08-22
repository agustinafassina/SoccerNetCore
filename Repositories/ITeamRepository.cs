using System.Collections.Generic;
using SoccerNetCore.Models;

namespace SoccerNetCore.Repository
{
    public interface ITeamRepository
    {
        void Add(Team team);
        IEnumerable<Team> ListAll();
        Team GetById(int id);
    }
}