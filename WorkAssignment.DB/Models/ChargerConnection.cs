using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAssignment.DB.Models
{
    public class ChargerConnection
    {
        [Key]
        public int Id { get; set; }
        public int ConnectionTypeId { get; set; }
        public int Amps { get; set; }
        public string PowerKw { get; set; }
        public int Voltage { get; set; }
        public int Quantity { get; set; }
        public string Comments { get; set; }
        [ForeignKey("ChargerId")]
        public Charger Charger { get; set; } 
        public int ChargerId { get; set; }
    }
}