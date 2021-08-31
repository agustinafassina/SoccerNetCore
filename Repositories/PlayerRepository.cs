using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SoccerNetCore.Context;
using SoccerNetCore.Models;

namespace SoccerNetCore.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly SoccerNetCoreDbContext _dbContext = null;

        public PlayerRepository(SoccerNetCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Player player)
        {
            _dbContext.Add(player);
            _dbContext.SaveChanges();
        }

        public void Remove(Player player)
        {
            _dbContext.Remove(player);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Player> ListAll()
        {
            var players = _dbContext.Player.Include(c => c.Team).ToList();
            return players.AsEnumerable();
        }

        public Player GetById(int id) => _dbContext.Player.Find(id);

        public void Update(Player player, int playerId)
        {
            var players = _dbContext.Player.Find(playerId);
            players.LastName = player.LastName;
            players.Name = player.Name;
            players.Country = player.Country;
            player.TeamId = player.TeamId;
            player.Email = player.Email;
            player.StartDate = player.StartDate;
            player.EndDate = player.EndDate;

            _dbContext.SaveChanges();
        }
    }
}