

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManagement.Domain.NoteCategoryAgg;

namespace NoteManagement.Infrastructure.EFCore.Mapping
{
    public class NoteCategoryMapping : IEntityTypeConfiguration<NoteCategory>
    {
        public void Configure(EntityTypeBuilder<NoteCategory> builder)
        {
            builder.ToTable("NoteCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
           
            builder.HasMany(x => x.Notes)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
