using System.Collections.Generic;
using WorkAssignment.DB.Models;

namespace WorkAssignment.API.Entities
{
    public class ChargerResponse
    {
        public int ChargerId { get; set; }
        public string Uuid { get; set; }
        public int DataProviderId { get; set; }
        public int DataQualityLevel { get; set; }
        public string DateCreated { get; set; }
        public string DateLastStatusUpdate { get; set; }
        public string GeneralComments { get; set; }
        public bool IsRecentlyVerified { get; set; }
        public int NumberOfPoints { get; set; }
        public int OperatorId { get; set; }
        public string OperatorsReference { get; set; }
        public int StatusTypeId { get; set; }
        public int SubmissionStatusTypeId { get; set; }
        public int UsageTypeId { get; set; }
        public AddressResponse AddressInfo { get; set; }
        public int AddressId { get; set; }
        public IList<ConnectionResponse> Connections { get; set; }
        public IList<MediaResponse> MediaItems { get; set; }
    }
}