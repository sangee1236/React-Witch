using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResourceManagement.Data.UnitOfWork;
using ResourceManagement.Model;

namespace ResourceManagement.Data.Model
{
    public class TimeSheetEntryModel  : ITimeSheetEntryService
    {

        public IUnitOfWork _unitOfWork;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="TimeSheetController"></param>
        public TimeSheetEntryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region  GetlogTime
        public IEnumerable<object> GetLogTimeList(int resourceId)
        {
            IEnumerable<object> LogTimeEntryDetails ;
            //try
            //{
                LogTimeEntryDetails = from e in _unitOfWork.TimeSheetEntryRepository.FindBy(x => x.ResourceInfoId == resourceId)
                                      join d in _unitOfWork.TimeSheetInfoRepository.GetAll() on e.ResourceInfoId equals d.ResourceId
                                      join f in _unitOfWork.ProjectsRepository.GetAll() on d.ProjectId equals f.Id
                                      select new
                                      {
                                          ProjectTitle = f.Name,
                                          BillingStatus = d.BillingStatus,
                                          Date = d.Date,
                                          Hours = d.Hours,
                                          ProjectId = d.ProjectId,
                                          ResourceId = d.ResourceId,
                                          Task = d.Task,
                                          TaskDetails = d.TaskDetails
                                      };

                return LogTimeEntryDetails;
            //}
            //catch (Exception ex) { return LogTimeEntryDetails; }
        }
        #endregion

        #region TimeSheet entry
        /// <summary>
        /// CreatedBy : sangee
        /// CreatedOn : 15 Jan, 2017
        /// Description : Add Time Sheet Entry 
        /// </summary>
        /// <param name="TimeSheetInfo"></param>
        /// <returns></returns>
        public bool AddLogTime(TimeSheetInfo TimeSheetInfo)
        {
            TimeSheetEntry timeSheetEntry = new TimeSheetEntry();
            try
            {
                if (TimeSheetInfo == null)
                    return false;

                _unitOfWork.TimeSheetInfoRepository.Add(TimeSheetInfo);
                _unitOfWork.Commit();
                timeSheetEntry.ResourceInfoId = TimeSheetInfo.ResourceId;
                timeSheetEntry.TimeSheetInfoId = TimeSheetInfo.Id;
                _unitOfWork.TimeSheetEntryRepository.Add(timeSheetEntry);
                _unitOfWork.Commit();

                if (TimeSheetInfo.Id > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// CreatedBy : sangee
        /// CreatedOn : 15 Jan, 2017
        /// Description : Update time sheet entry
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeSheetInfo"></param>
        /// <returns></returns>
        public bool UpdateLogTimeSheetEntry(TimeSheetInfo timeSheetInfo)
        {
            try
            {
                TimeSheetInfo _timeSheetInfoDb = _unitOfWork.TimeSheetInfoRepository.GetSingle(timeSheetInfo.Id);
                if (_timeSheetInfoDb == null)
                    return false;

                _timeSheetInfoDb.ProjectId = timeSheetInfo.ProjectId;
                _timeSheetInfoDb.Date = timeSheetInfo.Date;
                _timeSheetInfoDb.Task = timeSheetInfo.Task;
                _timeSheetInfoDb.TaskDetails = timeSheetInfo.TaskDetails;
                _timeSheetInfoDb.Hours = timeSheetInfo.Hours;
                _timeSheetInfoDb.BillingStatus = timeSheetInfo.BillingStatus;
                _unitOfWork.TimeSheetInfoRepository.Update(_timeSheetInfoDb);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// Delete a timesheet entry by a resource
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public bool DeleteTimeSheetEntry(int id, int resourceId)
        {
            try
            {
                TimeSheetEntry _timeSheetEntryDb = _unitOfWork.TimeSheetEntryRepository.GetSingle(id);
                if (_timeSheetEntryDb == null)
                    return false;

                _unitOfWork.TimeSheetInfoRepository.DeleteWhere(x => x.Id == _timeSheetEntryDb.TimeSheetInfoId);
                _unitOfWork.TimeSheetEntryRepository.Delete(_timeSheetEntryDb);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        #endregion
    }
}
