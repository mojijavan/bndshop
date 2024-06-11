

using _0_Framework.Domain;
using NoteManagement.Domain.NoteCategoryAgg;
using System;

namespace NoteManagement.Domain.NoteAgg
{
    public class Note : EntityBase
    {
        public string Title { get; private set; }
        public long CategoryId { get; private set; }
        public int Priority { get; private set; }
        public string Description { get; private set; }
        public bool Status { get; private set; }
        public DateTime DeadLine { get; private set; }
        public NoteCategory Category { get; set; }
        public Note(string title,long categoryId,int priority,string description,bool status,DateTime deadline)
        {
            Title = title;
            CategoryId = categoryId;
            Priority = priority;
            Description = description;
            Status = status;
            DeadLine = deadline;
            CreationDate = DateTime.Now;
        }
        public void Edit(string title, long categoryId, int priority, string description, bool status, DateTime deadline)
        {
            Title = title;
            CategoryId = categoryId;
            Priority = priority;
            Description = description;
            Status = status;
            DeadLine = deadline;
            //CreationDate = DateTime.Now;
        }
        public void FinishJob() 
        {
            Status = true;
        }
        public void NotFinishJob()
        {
            Status = false;
        }

    }
}
