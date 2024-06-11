

using NoteManagement.Application.Contracts.NoteCategory;
using NoteManagement.Domain.NoteCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NoteManagement.Infrastructure.EFCore.Repository
{
    public class NoteCategoryRepository : INoteCategoryRepository
    {
        public void Create(NoteCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<NoteCategory, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public NoteCategory Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<NoteCategory> Get()
        {
            throw new NotImplementedException();
        }

        public EditNoteCategory GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<NoteCategoryViewModel> GetNoteCategories()
        {
            throw new NotImplementedException();
        }

        public NoteCategoryViewModel GetNoteModelWith(long id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public List<NoteCategoryViewModel> Search(NoteCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
