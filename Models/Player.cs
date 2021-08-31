using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerNetCore.Models
{
    public class Player
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string LastName {get;set;}
        public string Logo {get;set;}
        public string LogoNameUniq {get;set;}
        public DateTime? Birthday {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}
        public string Email {get;set;}
        public string Country {get;set;}
        [ForeignKey("TeamId")]
        public int TeamId {get;set;}
        public virtual Team Team { get; set; }
    }
}