using System;
using Microsoft.EntityFrameworkCore;
using WorkAssignment.DB.Models;

namespace WorkAssignment.Migrations
{
    public class WorkDbContext : DbContext
    {
        public WorkDbContext() { }
        public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options) { }
        
        public virtual DbSet<Charger> Chargers { get; set; }
        public virtual DbSet<ChargerAddress> ChargerAddresses { get; set; }
        public virtual DbSet<ChargerConnection> ChargerConnections { get; set; }
        public virtual DbSet<ChargerMedia> ChargerMedias { get; set; }
        public virtual DbSet<User> Users { get; set; }
        
    }
}