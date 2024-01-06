

using AddressManagement.Domain.AddressAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressManagement.Infrastructure.EFCore.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PostalCode).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.City)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.CityId);

            builder.HasOne(x => x.Province)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.ProvinceId);
        }
    }
}
