

using _0_Framework.Domain;
using NoteManagement.Application.Contracts.Note;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NoteManagement.Domain.NoteAgg
{
    public interface INoteRepository : IRepository<long, Note>
    {
        Note GetNoteWithCategory(long id);
        EditNote GetDetails(long id);
        List<NoteViewModel> Search(NoteSearchModel searchModel);
        List<NoteViewModel> GetNotes();
    }
}
