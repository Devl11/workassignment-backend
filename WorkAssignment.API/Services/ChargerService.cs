using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using OpenChargeApiClient;
using WorkAssignment.API.Entities;
using WorkAssignment.API.Extensions;
using WorkAssignment.DB.Models;
using WorkAssignment.Migrations;

namespace WorkAssignment.API.Services
{
    public class ChargerService : IChargerService
    {
        private readonly IOpenChargeHttpClient _openChargeHttpClient;
        private readonly WorkDbContext _workDbContext;
        private readonly IMapper _mapper;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public ChargerService(IOpenChargeHttpClient openChargeHttpClient, WorkDbContext workDbContext, IMapper mapper, IBackgroundJobClient backgroundJobClient)
        {
            _openChargeHttpClient = openChargeHttpClient;
            _workDbContext = workDbContext;
            _mapper = mapper;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task<IList<ChargerLocationResponse>> GetChargersLocations(string boundingBox)
        {
            var chargersInBoundingBox = await _openChargeHttpClient.GetChargers(boundingBox);
            var chargerLocationsInBoundingBox = _mapper.Map<IList<ChargerLocationResponse>>(
                chargersInBoundingBox
            );
            var chargers = _mapper.Map<IList<Charger>>(
                chargersInBoundingBox
            );
            
            _backgroundJobClient.Enqueue<BackgroundDbWorker>(t => t.DoWork(chargers));

            return chargerLocationsInBoundingBox;
        }

        

        public async Task<ChargerResponse> GetCharger(int chargerId)
        {
            var data = await _workDbContext.Chargers
                .Include(c => c.AddressInfo)
                .Include(c => c.Connections)
                .Include(c => c.MediaItems)
                .FirstOrDefaultAsync(charger => charger.Id == chargerId);
            
            return _mapper.Map<ChargerResponse>(
                data
            );

        }
    }

    public class BackgroundDbWorker
    {
        private readonly WorkDbContext _workDbContext;
        public BackgroundDbWorker(WorkDbContext workDbContext)
        {
            _workDbContext = workDbContext;
        }

        public async Task DoWork(IList<Charger> chargers)
        {
            var (newChangers, address, connections, media) = chargers.GetUnique(_workDbContext);

            _workDbContext.MultiBulkMerge(newChangers, address, connections, media);

            await _workDbContext.BulkSaveChangesAsync();
        }
    }
}