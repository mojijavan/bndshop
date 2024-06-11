

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteManagement.Domain.NoteAgg;

namespace NoteManagement.Infrastructure.EFCore.Mapping
{
    public class NoteMapping : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
