using System;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
       public int BetId { get; set; }
       public int Amount { get; set; }
        [MaxLength(250)]
        public string Prediction { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}