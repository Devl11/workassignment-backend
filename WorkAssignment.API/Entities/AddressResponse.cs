namespace WorkAssignment.API.Entities
{
    public class AddressResponse
    {
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CountryId { get; set; }
        public string ContactPhoneNumber { get; set; }
        public int DistanceUnit { get; set; }
        public string Title { get; set; }
    }
}