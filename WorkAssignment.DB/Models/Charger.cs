using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkAssignment.DB.Models
{
    public class Charger
    {
        [Key]
        public int Id { get; set; }
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
        [ForeignKey("AddressId")]
        public ChargerAddress AddressInfo { get; set; }
        public int AddressId { get; set; }
        public IList<ChargerConnection> Connections { get; set; }
        public IList<ChargerMedia> MediaItems { get; set; }
    }
}