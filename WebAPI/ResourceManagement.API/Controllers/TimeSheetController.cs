using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Model;
using ResourceManagement.Data.UnitOfWork;
using ResourceManagement.Data.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResourceManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class TimeSheetController : Controller
    {
        //private IUnitOfWork _unitOfWork;
        //TimeSheetEntryModel _timeSheetEntryModel;
        private ITimeSheetEntryService _ITimeSheetEntryService;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="TimeSheetController"></param>
        public TimeSheetController(ITimeSheetEntryService ITimeSheetEntryService)
        {
            _ITimeSheetEntryService = ITimeSheetEntryService;
          //  _unitOfWork = unitOfWork;
            //_timeSheetEntryModel = new TimeSheetEntryModel(_unitOfWork);
        }
        #endregion

        [HttpGet]
        [Route("logtimelistbyid")]
        public IActionResult GetLogTimeList(int resourceId)
        {
            try
            {
                IEnumerable<object> listLogEntry = _ITimeSheetEntryService.GetLogTimeList(resourceId);
                return Ok(listLogEntry);
            }
            catch (Exception ex) { return BadRequest(); }
        }

        #region TimeSheet entry

        /// <summary>
        /// CreatedBy : sangee
        /// CreatedOn : 15 Jan, 2017
        /// Description : Add Time Sheet Entry 
        /// </summary>
        /// <param name="TimeSheetInfo"></param>
        /// <returns></returns>
        [HttpPost("AddTimeSheetEntry")]
        public IActionResult AddLogTime([FromBody]TimeSheetInfo TimeSheetInfo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                bool status = _ITimeSheetEntryService.AddLogTime(TimeSheetInfo);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        /// <summary>
        /// CreatedBy : sangee
        /// CreatedOn : 15 Jan, 2017
        /// Description: Update time sheet entry
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timeSheetInfo"></param>
        /// <returns></returns>
        [HttpPut("UpdateTimeSheetEntry")]
        public IActionResult UpdateLogTimeSheetEntry([FromBody]TimeSheetInfo timeSheetInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                bool status = _ITimeSheetEntryService.UpdateLogTimeSheetEntry(timeSheetInfo);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return BadRequest(ex); }
        }


        /// <summary>
        /// CreatedBy : sangee
        /// CreatedOn : 15 Jan, 2017
        /// Description : Delete a timesheet entry by a resource
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteLogTimeSheetEntry")]
        public IActionResult DeleteTimeSheetEntry(int id, int resourceId)
        {
            try
            {
                bool status = _ITimeSheetEntryService.DeleteTimeSheetEntry(id, resourceId);
                if (status)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex) { return NotFound(ex); }
        }
        #endregion
    }
}
