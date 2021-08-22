using System.Collections.Generic;
using SoccerNetCore.Models;

namespace SoccerNetCore.Repository
{
    public interface IPlayerRepository
    {
        void Add(Player player);
        void Remove(Player player);
        IEnumerable<Player> ListAll();
        Player GetById(int id);
        void Update(Player player, int playerId);
    }
}