using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Postgres.Business.Entites.PacketAggregate;
using Postgres.Data.Config;

namespace Postgres.Data
{
    public class PacketContext : DbContext
    {
        public DbSet<Packet> Packets {set; get;}
        public DbSet<Feature> Features {set; get;}

        public PacketContext(DbContextOptions<PacketContext> Options) : base(Options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.HasDefaultSchema("public");
            // builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.ApplyConfiguration(new FeatureConfiguration());
            builder.ApplyConfiguration(new PacketConfiguration());
        }
    }
}