

using _0_Framework.Domain;
using NoteManagement.Domain.NoteAgg;
using System.Collections.Generic;

namespace NoteManagement.Domain.NoteCategoryAgg
{
    public class NoteCategory:EntityBase
    {
        public string Title { get; private set; }        
        public int Priority { get; private set; }
        public string Description { get; private set; }     
        public List<Note> Notes { get; set; }
        public NoteCategory(string title,int priority,string description)
        {
            Title = title;Priority = priority;Description = description;CreationDate = System.DateTime.Now;


        }
        public void Edit(string title, int priority, string description)
        {
            Title = title; Priority = priority; Description = description;
        }
        //public NoteCategory()
        //{
        //    Notes = new List<Note>; 
        //}
    }
   
}
