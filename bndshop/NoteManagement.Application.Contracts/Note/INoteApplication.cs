

using _0_Framework.Application;
using System.Collections.Generic;

namespace NoteManagement.Application.Contracts.Note
{
   public interface INoteApplication
    {
        OperationResult Create(CreateNote command);
        OperationResult Edit(EditNote command);
        EditNote GetDetails(long id);
       
        List<NoteViewModel> Search(NoteSearchModel searchModel);
        List<NoteViewModel> GetNotes();
        
        public OperationResult Delete(NoteViewModel command);
    }
}
