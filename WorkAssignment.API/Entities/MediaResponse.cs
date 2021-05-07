namespace WorkAssignment.API.Entities
{
    public class MediaResponse
    {
        public int ChargePointId { get; set; }
        public string DateCreated { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsExternalResource { get; set; }
        public bool IsFeaturedItem { get; set; }
        public bool IsVideo { get; set; }
        public string MediaThumbnailUrl { get; set; }
        public string MediaUrl { get; set; }
        public string Comment { get; set; }
        public UserResponse User { get; set; }
    }
}