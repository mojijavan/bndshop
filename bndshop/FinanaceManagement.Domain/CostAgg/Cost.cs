

using _0_Framework.Domain;
using FinanaceManagement.Domain.CostCategoryAgg;
using System;

namespace FinanaceManagement.Domain.CostAgg
{
   public class Cost: EntityBase
    {
        public string Title { get; private set; }
        public long CategoryId { get; private set; }
        public int Priority { get; private set; }
        public string Description { get; private set; }
       
        public DateTime DeadLine { get; private set; }
        public CostCategory Category { get; set; }
        public Cost(string title, long categoryId, int priority, string description, DateTime deadline)
        {
            Title = title;
            CategoryId = categoryId;
            Priority = priority;
            Description = description;
           
            DeadLine = deadline;
            CreationDate = DateTime.Now;
        }
        public void Edit(string title, long categoryId, int priority, string description, DateTime deadline)
        {
            Title = title;
            CategoryId = categoryId;
            Priority = priority;
            Description = description;
            
            DeadLine = deadline;
            //CreationDate = DateTime.Now;
        }
      
    }
}
