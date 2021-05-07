using System.Collections.Generic;
using System.Threading.Tasks;
using WorkAssignment.API.Entities;
using WorkAssignment.DB.Models;

namespace WorkAssignment.API.Services
{
    public interface IChargerService
    {
        public Task<IList<ChargerLocationResponse>> GetChargersLocations(string boundingBox);
        public Task<ChargerResponse> GetCharger(int chargerId);
    }
}