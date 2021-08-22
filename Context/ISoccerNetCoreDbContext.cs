using Microsoft.EntityFrameworkCore;
using SoccerNetCore.Models;

namespace SoccerNetCore.Context
{
    public interface ISoccerNetCoreDbContext
    {
        DbSet<Player> Player { get; set; }
        DbSet<Team> Team { get; set; }
    }
}
