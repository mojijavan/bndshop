

using _0_Framework.Application;
using System.Collections.Generic;

namespace NoteManagement.Application.Contracts.NoteCategory
{
    public interface INoteCategoryApplication
    {
        OperationResult Create(CreateNoteCategory command);
        OperationResult Edit(EditNoteCategory command);
        List<NoteCategoryViewModel> Search(NoteCategorySearchModel searchModel);
        EditNoteCategory GetDetails(long id);
        List<NoteCategoryViewModel> GetNoteCategories();             
        public OperationResult Delete(NoteCategoryViewModel command);
    }
}
