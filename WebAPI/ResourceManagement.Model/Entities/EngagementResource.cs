using System;
using System.Collections.Generic;
using System.Text;


namespace ResourceManagement.Model
{
    public class EngagementResource : IEntityBase
    {
        public int Id { get; set; }
        
        public int ResourceId { get; set; }
        public ResourceInfo resource { get; set; }

        public int ProjectId { get; set; }
        public Projects project { get; set; }
    }
}
