using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;
using WorkAssignment.DB.Models;
using WorkAssignment.Migrations;

namespace WorkAssignment.API.Extensions
{
    public static class ChargerExtensions
    {
        public static (IList<Charger>, IList<ChargerAddress>, IList<ChargerConnection>, IList<ChargerMedia>) 
            GetUnique(this IList<Charger> chargers, WorkDbContext workDbContext)
        {
            var newChangers = chargers.Where(c =>
                !workDbContext.Chargers.Any() || workDbContext.Chargers.Any(cDb => cDb.Id != c.Id)).ToList();
            var address = newChangers.Select(c => c.AddressInfo)
                .Where(a => !workDbContext.ChargerAddresses.Any() ||
                            workDbContext.ChargerAddresses.Any(ca => ca.Id != a.Id))
                .ToList();
            var connections = newChangers.SelectMany(c =>
                {
                    c.Connections.ForAll(con => con.ChargerId = c.Id);
                    return c.Connections;
                }).Where(c =>
                    !workDbContext.ChargerConnections.Any() ||
                    workDbContext.ChargerConnections.Any(cc => cc.Id != c.Id))
                .ToList();
            var media = newChangers.SelectMany(c =>
                {
                    c.MediaItems.ForAll(con => con.ChargerId = c.Id);
                    return c.MediaItems;
                }).Where(m =>
                    !workDbContext.ChargerMedias.Any() || workDbContext.ChargerMedias.Any(cm => cm.Id != m.Id))
                .ToList();

            return (newChangers, address, connections, media);
        }
    }
}