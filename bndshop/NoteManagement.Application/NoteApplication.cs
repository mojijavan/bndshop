

using _0_Framework.Application;
using NoteManagement.Application.Contracts.Note;
using NoteManagement.Domain.NoteAgg;
using System.Collections.Generic;

namespace NoteManagement.Application
{
    public class NoteApplication : INoteApplication
    {
        private readonly INoteRepository _NoteRepository;

        public NoteApplication(INoteRepository noteRepository)
        {
            _NoteRepository = noteRepository;
        }

        public OperationResult Create(CreateNote command)
        {
            var operation = new OperationResult();
            if (_NoteRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            // var path = $"{categorySlug}/{slug}";


            var DeadLine = command.DeadLine.ToGeorgianDateTime();

            var Note = new Note(command.Title,command.CategoryId,command.Priority,command.Description,command.Status,DeadLine);

            _NoteRepository.Create(Note);
            _NoteRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Delete(NoteViewModel command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            if (!_NoteRepository.Exists(x => x.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);
            _NoteRepository.Delete(command.Id);
            
            _NoteRepository.SaveChanges();
            return operation;
        }

        public OperationResult Edit(EditNote command)
        {
            var operation = new OperationResult();
            var Note = _NoteRepository.GetNoteWithCategory(command.Id);
            if (Note == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_NoteRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
           
           
            var DeadLine = command.DeadLine.ToGeorgianDateTime();

            Note.Edit(command.Title, command.CategoryId, command.Priority, command.Description, command.Status, DeadLine);

            _NoteRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditNote GetDetails(long id)
        {
            return _NoteRepository.GetDetails(id);
        }

        public List<NoteViewModel> GetNotes()
        {
            return _NoteRepository.GetNotes();
        }

        public List<NoteViewModel> Search(NoteSearchModel searchModel)
        {
            return _NoteRepository.Search(searchModel);
        }
    }
}
