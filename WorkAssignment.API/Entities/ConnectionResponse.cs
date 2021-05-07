namespace WorkAssignment.API.Entities
{
    public class ConnectionResponse
    {
        public int Amps { get; set; }
        public string PowerKw { get; set; }
        public int Voltage { get; set; }
        public int Quantity { get; set; }
        public string Comments { get; set; }
    }
}