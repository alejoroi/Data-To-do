using System;

namespace webapp.Models{
    public class TodoItem{
        public long Id {get;set;}
        public string Name{get;set;}
        public bool IsComplete{get;set;}

        public DateTime DeadLine{get;set;}

        public string Description {get;set;}
    }
}