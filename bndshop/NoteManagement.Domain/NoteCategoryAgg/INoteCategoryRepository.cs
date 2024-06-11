

using _0_Framework.Domain;
using NoteManagement.Application.Contracts.NoteCategory;
using System.Collections.Generic;

namespace NoteManagement.Domain.NoteCategoryAgg
{
    public interface INoteCategoryRepository : IRepository<long, NoteCategory>
    {
        EditNoteCategory GetDetails(long id);
        List<NoteCategoryViewModel> Search(NoteCategorySearchModel searchModel);
        List<NoteCategoryViewModel> GetNoteCategories();
       NoteCategoryViewModel GetNoteModelWith(long id);
    }
}
