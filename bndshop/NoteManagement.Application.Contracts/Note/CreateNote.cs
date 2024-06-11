
namespace NoteManagement.Application.Contracts.Note
{
   public class CreateNote
    {
        public string Title { get;  set; }
        public long CategoryId { get;  set; }
        public int Priority { get;  set; }
        public string Description { get;  set; }
        public bool Status { get;  set; }
        public string DeadLine { get;  set; }
        
    }
}
