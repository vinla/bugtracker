namespace Bugtracker.Core
{
    public class Bug : DataRecord
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsClosed { get; set;}
    }    
}
