using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postgres.Business.Entites.PacketAggregate;

namespace Postgres.Data.Config
{
    public class PacketConfiguration : IEntityTypeConfiguration<Packet>
    {
       public void Configure(EntityTypeBuilder<Packet> builder)
       {
           builder.HasKey(e => e.Id);
           builder.Property(e => e.Id).UseIdentityByDefaultColumn();

            builder.Property(e => e.Name).IsRequired();

            builder.HasMany(p => p.Features).WithOne();        
       }
    }
}