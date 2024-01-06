

using AddressManagement.Domain.ProvineAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressManagement.Infrastructure.EFCore.Mapping
{
    public class ProvinceMapping : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Provinces");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Pname).HasMaxLength(500).IsRequired();
            builder.HasMany(x => x.Cities)
                .WithOne(x => x.Province)
                .HasForeignKey(x => x.ProvinceId);
            builder.HasMany(x => x.Addresses)
                .WithOne(x => x.Province)
                .HasForeignKey(x => x.ProvinceId);

        }
    }
}
