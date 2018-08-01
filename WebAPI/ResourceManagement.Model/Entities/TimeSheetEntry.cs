using System;
using System.Collections.Generic;
using System.Text;
//using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceManagement.Model
{
    public class TimeSheetEntry : IEntityBase
    {
        public int Id { get; set; }

        public int ResourceInfoId{ get; set; }
        public ResourceInfo ResourceInfo { get; set; }

        public int TimeSheetInfoId { get; set; }
        public TimeSheetInfo TimeSheetInfo { get; set ; }

       
    }
}
