

using _0_Framework.Application;
using NoteManagement.Application.Contracts.NoteCategory;
using System.Collections.Generic;

namespace NoteManagement.Application
{
    public class NoteCategoryApplication : INoteCategoryApplication
    {
        public OperationResult Create(CreateNoteCategory command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Delete(NoteCategoryViewModel command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Edit(EditNoteCategory command)
        {
            throw new System.NotImplementedException();
        }

        public EditNoteCategory GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<NoteCategoryViewModel> GetNoteCategories()
        {
            throw new System.NotImplementedException();
        }

        public List<NoteCategoryViewModel> Search(NoteCategorySearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
