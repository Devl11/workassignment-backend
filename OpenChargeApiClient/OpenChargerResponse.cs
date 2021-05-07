using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenChargeApiClient
{
    public class OpenChargerResponse
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("UUID")]
        public string Uuid { get; set; }
        [JsonProperty("DataProviderID")]
        public int DataProviderId { get; set; }
        [JsonProperty("DataQualityLevel")]
        public int DataQualityLevel { get; set; }
        [JsonProperty("DateCreated")]
        public string DateCreated { get; set; }
        [JsonProperty("DateLastStatusUpdate")]
        public string DateLastStatusUpdate { get; set; }
        [JsonProperty("GeneralComments")]
        public string GeneralComments { get; set; }
        [JsonProperty("IsRecentlyVerified")]
        public bool IsRecentlyVerified { get; set; }
        [JsonProperty("NumberOfPoints")]
        public int NumberOfPoints { get; set; }
        [JsonProperty("OperatorID")]
        public int OperatorId { get; set; }
        [JsonProperty("OperatorsReference")]
        public string OperatorsReference { get; set; }
        [JsonProperty("StatusTypeID")]
        public int StatusTypeId { get; set; }
        [JsonProperty("SubmissionStatusTypeID")]
        public int SubmissionStatusTypeId { get; set; }
        [JsonProperty("UsageTypeID")]
        public int UsageTypeId { get; set; }
        
        [JsonProperty("AddressInfo")]
        public OpenChargerAddressResponse AddressInfo { get; set; }
        [JsonProperty("Connections")]
        public IList<OpenChargerConnectionsResponse> Connections { get; set; }
        [JsonProperty("MediaItems")]
        public IList<OpenChargerMediaResponse> MediaItems { get; set; }
    }

    public class OpenChargerAddressResponse
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("AddressLine1")]
        public string StreetName { get; set; }
        [JsonProperty("Town")]
        public string Town { get; set; }
        [JsonProperty("Postcode")]
        public string Postcode { get; set; }
        [JsonProperty("Latitude")]
        public string Latitude { get; set; }
        [JsonProperty("Longitude")]
        public string Longitude { get; set; }
        [JsonProperty("CountryID")]
        public int CountryId { get; set; }
        [JsonProperty("ContactTelephone1")]
        public string ContactPhoneNumber { get; set; }
        [JsonProperty("DistanceUnit")]
        public int DistanceUnit { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        
    }

    public class OpenChargerConnectionsResponse
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("ConnectionTypeID")]
        public int ConnectionTypeId { get; set; }
        [JsonProperty("CurrentTypeID")]
        public int CurrentTypeId { get; set; }
        [JsonProperty("LevelID")]
        public int LevelId { get; set; }
        [JsonProperty("Amps")]
        public int Amps { get; set; }
        [JsonProperty("PowerKW")]
        public string PowerKw { get; set; }
        [JsonProperty("Voltage")]
        public int Voltage { get; set; }
        [JsonProperty("Quantity")]
        public int Quantity { get; set; }
        [JsonProperty("Comments")]
        public string Comments { get; set; }
    }

    public class OpenChargerMediaResponse
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("ChargePointID")]
        public int ChargePointId { get; set; }
        [JsonProperty("DateCreated")]
        public string DateCreated { get; set; }
        [JsonProperty("IsEnabled")]
        public bool IsEnabled { get; set; }
        [JsonProperty("IsExternalResource")]
        public bool IsExternalResource { get; set; }
        [JsonProperty("IsFeaturedItem")]
        public bool IsFeaturedItem { get; set; }
        [JsonProperty("IsVideo")]
        public bool IsVideo { get; set; }
        [JsonProperty("ItemThumbnailURL")]
        public string MediaThumbnailUrl { get; set; }
        [JsonProperty("ItemURL")]
        public string MediaUrl { get; set; }
        [JsonProperty("Comment")]
        public string Comment { get; set; }
        [JsonProperty("User")]
        public OpenChargerUserResponse User { get; set; }
    }

    public class OpenChargerUserResponse
    {
        [JsonProperty("ID")]
        public long Id { get; set; }
        [JsonProperty("Username")]
        public string Username { get; set; }
        [JsonProperty("ReputationPoints")]
        public int ReputationPoints { get; set; }
        [JsonProperty("ProfileImageUrl")]
        public string ProfileImageUrl { get; set; }
    }
}