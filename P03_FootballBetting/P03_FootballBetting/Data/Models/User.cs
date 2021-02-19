using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        public string Password { get; set; } 
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } 
        public decimal Balance { get; set; }
    }
}