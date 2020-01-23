using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Postgres.Business.Entites.PacketAggregate;
using Npgsql.EntityFrameworkCore;

namespace Postgres.Data.Config
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityByDefaultColumn();
            
            builder.Property(e => e.Description).IsRequired();

        }
    }
}