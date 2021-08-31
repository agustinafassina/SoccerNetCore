using System.Collections.Generic;
using System.IO;
using SoccerNetCore.Models;

namespace SoccerNetCore.Services
{
    public interface IPlayerService
    {
        List<Player> GetList();
        Player Get(int id);
        void Post(Player request, Stream file);
        void Delete(int playerId);
        void Update(int playerId, Player body);
        void GetSendEmail(int id);
    }
}