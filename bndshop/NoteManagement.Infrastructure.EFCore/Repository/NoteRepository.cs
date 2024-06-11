

using NoteManagement.Application.Contracts.Note;
using NoteManagement.Domain.NoteAgg;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NoteManagement.Infrastructure.EFCore.Repository
{
    class NoteRepository : INoteRepository
    {
        public void Create(Note entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Note, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Note Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<Note> Get()
        {
            throw new NotImplementedException();
        }

        public EditNote GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<NoteViewModel> GetNotes()
        {
            throw new NotImplementedException();
        }

        public Note GetNoteWithCategory(long id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<NoteViewModel> Search(NoteSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
