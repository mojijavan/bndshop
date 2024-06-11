using _0_Framework.Domain;
using FinanaceManagement.Domain.CostAgg;
using System;
using System.Collections.Generic;


namespace FinanaceManagement.Domain.CostCategoryAgg
{
   public  class CostCategory: EntityBase
    {
        public string Title { get; private set; }
        public int Priority { get; private set; }
        public string Description { get; private set; }
        public List<Cost> Costs { get; set; }
        public CostCategory(string title, int priority, string description)
        {
            Title = title; Priority = priority; Description = description; CreationDate = System.DateTime.Now;


        }
        public void Edit(string title, int priority, string description)
        {
            Title = title; Priority = priority; Description = description;
        }
    }
}
