using SoccerNetCore.Models;

namespace SoccerNetCore.Services
{
    public interface ISendEmailService
    {
        void SendEmail(Player player, string TeamName);
    }
}