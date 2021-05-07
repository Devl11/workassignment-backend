using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkAssignment.API.Entities;
using WorkAssignment.API.Services;

namespace WorkAssignment.API.Controllers
{
    public class ChargerController : ApiControllerBase
    {
        private readonly IChargerService _chargerService;

        public ChargerController(IChargerService chargerService)
        {
            _chargerService = chargerService;
        }
        
        [HttpGet("chargerLocations")]
        public async Task<ActionResult<IList<ChargerLocationResponse>>>GetChargers([FromQuery]string boundingBox)
        {

            var data = await _chargerService.GetChargersLocations(boundingBox);
            return Ok(data);
        }
        
        [HttpGet("charger")]
        public async Task<ActionResult<ChargerResponse>>GetChargers([FromQuery]int chargerId)
        {
            var data = await _chargerService.GetCharger(chargerId);

            return Ok(data);
        }
        
    }
}