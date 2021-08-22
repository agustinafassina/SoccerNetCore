using System.Collections.Generic;

namespace SoccerNetCore.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }
        public int Id {get;set;}
        public string Name {get;set;}
        public string Country {get;set;}
        public virtual ICollection<Player> Players { get; set; }
    }
}