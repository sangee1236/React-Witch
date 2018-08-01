using System;
using System.Collections.Generic;
using System.Text;
using ResourceManagement.Model;
using ResourceManagement.Data.Abstract;

namespace ResourceManagement.Data.Repositories
{
  public class TimeSheetRepository : EntityBaseRepository<TimeSheetInfo> , ITimeSheetInfoRepository
    {
        public TimeSheetRepository(ResourceManagementContext context)
            : base(context)
        { }
    }

    public class TimeSheetEntryRepository : EntityBaseRepository<TimeSheetEntry>, ITimeSheetEntryRepository
    {
        public TimeSheetEntryRepository(ResourceManagementContext context) : base(context) { }
    }
}
