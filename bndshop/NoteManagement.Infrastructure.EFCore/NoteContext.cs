

using Microsoft.EntityFrameworkCore;
using NoteManagement.Domain.NoteAgg;
using NoteManagement.Domain.NoteCategoryAgg;

namespace NoteManagement.Infrastructure.EFCore
{
   public class NoteContext: DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {
        }
    }
}
