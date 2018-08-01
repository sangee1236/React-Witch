using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Model
{
    public class TimeSheetInfo : IEntityBase
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Date { get; set; }
        public string Task { get; set; }
        public string TaskDetails { get; set; }
        public int Hours { get; set; }
        public string BillingStatus { get; set; }

    }
}
