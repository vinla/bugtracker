using System;

namespace Bugtracker.Core
{
    public class Bug : DataRecord
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsClosed { get; set;}
        public string AssignedTo { get; set; }
    }    
}
