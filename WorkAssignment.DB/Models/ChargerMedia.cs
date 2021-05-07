using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAssignment.DB.Models
{
    public class ChargerMedia
    {
        [Key]
        public int Id { get; set; }
        public int ChargePointId { get; set; }
        public string DateCreated { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsExternalResource { get; set; }
        public bool IsFeaturedItem { get; set; }
        public bool IsVideo { get; set; }
        public string MediaThumbnailUrl { get; set; }
        public string MediaUrl { get; set; }
        public string Comment { get; set; }
        [ForeignKey("ChargerId")]
        public Charger Charger { get; set; } 
        public int ChargerId  { get; set; } 
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}