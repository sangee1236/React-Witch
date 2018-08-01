using System;
using System.Collections.Generic;
using System.Text;
using ResourceManagement.Model;
namespace ResourceManagement.Data.Model 
{
    public interface ITimeSheetEntryService
    {
        IEnumerable<object> GetLogTimeList(int resourceId);
        bool AddLogTime(TimeSheetInfo TimeSheetInfo);
        bool UpdateLogTimeSheetEntry(TimeSheetInfo timeSheetInfo);
        bool DeleteTimeSheetEntry(int id, int resourceId);

    }
}
