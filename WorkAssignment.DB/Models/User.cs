using System.ComponentModel.DataAnnotations;

namespace WorkAssignment.DB.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public int ReputationPoints { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}